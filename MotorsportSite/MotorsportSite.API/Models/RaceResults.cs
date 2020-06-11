using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotorsportSite.API.Models
{
    public class RaceResults
    {
        public int DriverId { get; set; } 
        public int LapsCompleted { get; set; } 
        public bool IsChampion { get; set; } 
        public decimal Points { get; set; } 
        public int Position { get; set; } 
        public bool FastestLap { get; set; }
        public string TrackName { get; set; }
        public string TrackCountry { get; set; }
        public DateTime StartDate { get; set; }
        public int LapsLead { get; set; }
        public int Overtakes { get; set; }

        public static RaceResults MapFromDb(DataLevel.Drivers.Models.RaceResults dataModel)
        {
            return new RaceResults
            {
                DriverId = dataModel.DriverId,
                LapsCompleted = dataModel.LapsCompleted,
                IsChampion = dataModel.IsChampion,
                Points = dataModel.Points,
                Position = dataModel.Position,
                FastestLap = dataModel.FastestLap,
                TrackName = dataModel.TrackName,
                TrackCountry = dataModel.TrackCountry,
                StartDate = dataModel.StartDate,
                LapsLead = dataModel.LapsLead,
                Overtakes = dataModel.Overtakes
            };
        }
    }
}
