using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotorsportSite.API.Models
{
    public class DriverStats
    {
        public int Id { get; set; }
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


        public static DriverStats Mapper(int driverId, DriverCalculationInfo calcInfo)
        {
            return new DriverStats
            {
                Id = driverId,
                TotalPoints = calcInfo.TotalPoints,
                TotalPointsOfCurrentSeason = calcInfo.TotalPointsOfCurrentSeason,
                HighestResult = calcInfo.HighestResult,
                TotalNumOfHighestResult = calcInfo.TotalNumOfHighestResult,
                BestTrack = calcInfo.BestTrack,
                NumRaceFastestLaps = calcInfo.NumRaceFastestLaps,
                NumOfRacesCompleted = calcInfo.NumOfRacesCompleted,
                NumDNFs = calcInfo.NumDNFs,
                TotalLapsComplete = calcInfo.TotalLapsComplete,
                BestSeason = calcInfo.BestSeason,
                NumChapionships = calcInfo.NumChapionships
            };
        }
    }
}
