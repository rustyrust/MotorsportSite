using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotorsportSite.API.Models
{
    public class DriverChampionshipStandings
    {
        public int DriverId { get; set; }
        public decimal Points { get; set; }
        public int DriverNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string TeamName { get; set; }

        public static DriverChampionshipStandings MapFromDB(MotorsportSite.DataLevel.Drivers.Models.DriverRaceDataForChampionship dbModel)
        {
            return new DriverChampionshipStandings
            {
                DriverId = dbModel.DriverId,
                TeamName = dbModel.TeamName,
                Points = dbModel.Points,
                DriverNumber = dbModel.DriverNumber,
                FirstName = dbModel.FirstName,
                LastName = dbModel.LastName,
                Country = dbModel.Country
            };
        }
    }
}
