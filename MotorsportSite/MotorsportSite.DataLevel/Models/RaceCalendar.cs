using System;
using System.Collections.Generic;
using System.Text;

namespace MotorsportSite.DataLevel.Models
{
    public class RaceCalendar
    {
        public string TrackName { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public string EventName { get; set; }
    }
}
