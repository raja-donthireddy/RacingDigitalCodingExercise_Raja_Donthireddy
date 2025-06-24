using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using RacingDigital.API.Models;
using System.Formats.Asn1;
using System.Globalization;

namespace RacingDigital.API.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());

            if (context.RaceResults.Any())
                return; // DB has been seeded

            var path = Path.Combine(AppContext.BaseDirectory, "Data", "RaceAndResults.csv");

            if (!File.Exists(path))
                throw new FileNotFoundException("CSV file not found.", path);

            using var reader = new StreamReader(path);
            using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HeaderValidated = null,
                MissingFieldFound = null
            });

            var records = csv.GetRecords<RaceResultCsv>().ToList();
            var results = records.Select(r => r.ToEntity()).ToList();

            context.RaceResults.AddRange(results);
            context.SaveChanges();

        }
    }
}
