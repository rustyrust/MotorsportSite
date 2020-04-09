using System;
using System.Collections.Generic;
using System.Text;

namespace MotorsportSite.DataLevel.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime? LeaveDate { get; set; }
        public string TeamColours { get; set; }
    }
}
