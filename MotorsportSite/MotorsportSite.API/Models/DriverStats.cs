using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotorsportSite.API.Models
{
    public class DriverStats
    {
        public int Id { get; set; }
        public decimal TotalPoints { get; set; } = 0;
        public decimal TotalPointsOfCurrentSeason { get; set; } = 0;
        public int HighestResult { get; set; } = 0;
        public int TotalNumOfHighestResult { get; set; } = 0;
        public string BestTrack { get; set; }
        public int NumRaceFastestLaps { get; set; } = 0;
        public int NumOfRacesCompleted { get; set; } = 0;
        public int NumDNFs { get; set; } = 0;
        public int TotalLapsComplete { get; set; } = 0;
        public int BestSeason { get; set; } = 0;
        public int NumChapionships { get; set; } = 0;


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
