using System;
using System.Collections.Generic;
using System.Text;

namespace MotorsportSite.DataLevel.Drivers.Models
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
        public DateTime StartDate { get; set; }
        public int LapsLead { get; set; }
        public int Overtakes { get; set; }
    }
}
