using System;
using System.Collections.Generic;
using System.Text;

namespace MotorsportSite.DataLevel.Models
{
    public class TeamPrinciple
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nationality { get; set; }
        public DateTime DOB { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime? LeaveDate { get; set; }
    }
}
