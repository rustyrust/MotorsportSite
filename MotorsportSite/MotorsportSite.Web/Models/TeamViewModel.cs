using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotorsportSite.Web.Models
{
    public class TeamViewModel
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public string PrimaryColourName { get; set; }
        public string PrimaryColour { get; set; }
        public string SecondaryColourName { get; set; }
        public string SecondaryColour { get; set; }
    }
}
