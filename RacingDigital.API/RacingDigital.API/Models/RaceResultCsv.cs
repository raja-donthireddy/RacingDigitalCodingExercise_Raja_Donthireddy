using System.Globalization;

namespace RacingDigital.API.Models
{
    public class RaceResultCsv
    {
        public string Race { get; set; }
        public string RaceDate { get; set; }
        public string RaceTime { get; set; }
        public string Racecourse { get; set; }
        public double RaceDistance { get; set; }
        public string Jockey { get; set; }
        public string Trainer { get; set; }
        public string Horse { get; set; }
        public int FinishingPosition { get; set; }
        public decimal? DistanceBeaten { get; set; }
        public decimal? TimeBeaten { get; set; }

        public RaceResult ToEntity() => new RaceResult
        {
            Race = Race,
            //RaceDate = DateTime.TryParse(RaceDate, "MM/dd/yyyy", out var date) ? date : default,
            RaceDate = DateTime.TryParseExact(RaceDate, "MM/dd/yyyy",
                                        CultureInfo.InvariantCulture, 
                                        DateTimeStyles.None,
                                        out var date) ? date : default,
            RaceTime = RaceTime,
            Racecourse = Racecourse,
            RaceDistance = RaceDistance,
            Jockey = Jockey,
            Trainer = Trainer,
            Horse = Horse,
            FinishingPosition = FinishingPosition,
            DistanceBeaten = DistanceBeaten,
            TimeBeaten = TimeBeaten
        };

    }
}
