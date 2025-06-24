using Microsoft.EntityFrameworkCore;
using RacingDigital.API.Models;

namespace RacingDigital.API.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<RaceResult> RaceResults { get; set; }

    }
}
