using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotorsportSite.API.Models
{
    public class DriverCalculationInfo
    {
        public decimal TotalPoints { get; set; }
        public decimal TotalPointsOfCurrentSeason { get; set; }
        public int HighestResult { get; set; }
        public int TotalNumOfHighestResult { get; set; }
        public string BestTrack { get; set; }
        public int NumRaceFastestLaps { get; set; }
        public int NumOfRacesCompleted { get; set; }
        public int NumDNFs { get; set; }
        public int TotalLapsComplete { get; set; }
        public int BestSeason { get; set; }
        public int NumChapionships { get; set; }
        public int TopTenFinishes { get; set; }
        public int NumOfRaceWins { get; set; }
        public int LeadLaps { get; set; }
        public int Overtakes { get; set; }
    }
}
