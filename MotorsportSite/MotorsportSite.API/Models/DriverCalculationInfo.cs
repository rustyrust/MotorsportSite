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
    }
}
