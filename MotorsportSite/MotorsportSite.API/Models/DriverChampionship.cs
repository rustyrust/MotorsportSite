using System;
using System.Collections.Generic;
using System.Text;

namespace MotorsportSite.API.Models
{
    public class DriverChampionship
    {
        public int DriverId { get; set; }
        public string TeamName { get; set; }
        public int Season { get; set; }


        public static DriverChampionship MapFromDB(MotorsportSite.DataLevel.Drivers.Models.DriverChampionship dbModel)
        {
            return new DriverChampionship
            {
                DriverId = dbModel.DriverId,
                TeamName = dbModel.TeamName,
                Season = dbModel.Season
            };
        }


    }
}
