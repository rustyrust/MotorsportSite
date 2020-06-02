using System;
using System.Collections.Generic;
using System.Text;

namespace MotorsportSite.DataLevel.Drivers.Models
{
    public class Driver
    {
        public int Id { get; set; }
        public int CatagoryId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ShortName { get; set; }
        public int DriverNumber { get; set; }
        public DateTime DOB { get; set; }
        public string Country { get; set; }
        public string PlaceOfBirth { get; set; }
        public string TeamName { get; set; }
        public string TeamColour { get; set; }
    }
}
