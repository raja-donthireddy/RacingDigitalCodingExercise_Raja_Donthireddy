using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace RacingDigital.API.Models
{
    public class RaceResult
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Race { get; set; }
        public DateTime RaceDate { get; set; }
        public string RaceTime { get; set; }

        public string Racecourse { get; set; }
        public double RaceDistance { get; set; }
        public string Jockey { get; set; }
        public string Trainer { get; set; }
        public string Horse { get; set; }
        public int FinishingPosition { get; set; }

        public decimal? DistanceBeaten { get; set; }
        public decimal? TimeBeaten { get; set; }
        public string? Notes { get; set; }
    }
}
