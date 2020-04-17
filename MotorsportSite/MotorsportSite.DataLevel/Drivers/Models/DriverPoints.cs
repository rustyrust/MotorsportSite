using System;
using System.Collections.Generic;
using System.Text;

namespace MotorsportSite.DataLevel.Drivers.Models
{
    public class DriverPoints
    {
        public int DriverId { get; set; }
        public decimal Points { get; set; }
        public int Position { get; set; }
        public bool FastestLap { get; set; }
    }
}
