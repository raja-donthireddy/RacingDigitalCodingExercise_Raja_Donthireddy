using RacingDigital.API.Data;
using RacingDigital.API.Models;

namespace RacingDigital.API.Services
{
    public class RaceService
    {
        private readonly ApplicationDbContext _context;

        public RaceService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<RaceResult> GetAll() => _context.RaceResults.ToList();

        public RaceResult? GetById(int id) => _context.RaceResults.Find(id);

        public void UpdateNote(int raceId, string note)
        {
            var race = _context.RaceResults.Find(raceId);
            if (race != null)
            {
                race.Notes = note;
                _context.SaveChanges();
            }
        }

        public string? GetBestJockey(string horseName)
        {
            return _context.RaceResults
                .Where(r => r.Horse == horseName)
                .GroupBy(r => r.Jockey)
                .OrderBy(g => g.Average(r => r.FinishingPosition))
                .Select(g => g.Key)
                .FirstOrDefault();
        }
    }

}
