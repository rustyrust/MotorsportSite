using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotorsportSite.API.Models
{
    public class DriverInformation
    {
        public int Id { get; set; }
        public int CatagoryId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ShortName { get; set; }
        public int DriverNumber { get; set; }
        public DateTime DOB { get; set; }
        public string Country { get; set; }
        public string PlaceOfBirth { get; set; }
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


        public static DriverInformation Mapper(MotorsportSite.DataLevel.Drivers.Models.Driver dataModel, DriverCalculationInfo calcInfo)
        {
            return new DriverInformation
            {
                Id = dataModel.Id,
                CatagoryId = dataModel.CatagoryId,
                FirstName = dataModel.FirstName,
                LastName = dataModel.LastName,
                ShortName = dataModel.ShortName,
                DriverNumber = dataModel.DriverNumber,
                DOB = dataModel.DOB,
                Country = dataModel.Country,
                PlaceOfBirth = dataModel.PlaceOfBirth,
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
