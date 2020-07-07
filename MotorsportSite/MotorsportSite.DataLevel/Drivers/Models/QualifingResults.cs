using System;
using System.Collections.Generic;
using System.Text;

namespace MotorsportSite.DataLevel.Drivers.Models
{
    public class QualifingResults
    {
        public int DriverId { get; set; }
        public DateTime StartDate { get; set; }
        public string TrackName { get; set; }
        public string Country { get; set; }
        public string Q1Time { get; set; }
        public string Q2Time { get; set; }
        public string Q3Time { get; set; }
        public int Position { get; set; }
    }
}
