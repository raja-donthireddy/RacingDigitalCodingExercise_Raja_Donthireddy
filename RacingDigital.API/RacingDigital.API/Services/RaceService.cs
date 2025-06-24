using Microsoft.AspNetCore.Mvc;
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

        public BestJockey? GetBestJockeyForHorse(string horseName)
        {
            var result = _context.RaceResults
                .Where(r => r.Horse == horseName && r.FinishingPosition == 1)
                .GroupBy(r => r.Jockey)
                .Select(g => new BestJockey
                {
                    Horse = horseName,
                    Jockey = g.Key,
                    Wins = g.Count()
                })
                .OrderByDescending(j => j.Wins)
                .FirstOrDefault();

            return result;
        }

        public IEnumerable<string> GetAllHorseNames()
        {
            var horses = _context.RaceResults
                .Select(r => r.Horse)
                .Distinct()
                .OrderBy(h => h)
                .ToList();

            return horses;
        }
    }

}
