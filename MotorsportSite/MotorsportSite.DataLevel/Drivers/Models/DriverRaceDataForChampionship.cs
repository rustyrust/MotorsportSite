using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace MotorsportSite.DataLevel.Drivers.Models
{
    public class DriverRaceDataForChampionship
    {
        public int DriverId { get; set; }
        public decimal Points { get; set; }
        public bool FastestLap { get; set; }
        public int DriverNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string TeamName { get; set; }
    }
}
