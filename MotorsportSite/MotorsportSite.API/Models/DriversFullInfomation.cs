using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotorsportSite.API.Models
{
    public class DriversFullInfomation
    {
        public Driver DriverBio { get; set; }
        public DriverStats DriverSeasonStats { get; set; }
        public DriverStats DriverCareerStats { get; set; }

    }
}
