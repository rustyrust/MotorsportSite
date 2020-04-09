using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotorsportSite.API.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? LeaveDate { get; set; }
        public string TeamColour { get; set; }


        public static Team Map(MotorsportSite.DataLevel.Models.Team dataModel)
        {
            return new Team
            {
                Id = dataModel.Id,
                TeamName = dataModel.TeamName,
                StartDate = dataModel.EntryDate,
                LeaveDate = dataModel.LeaveDate,
                TeamColour = dataModel.TeamColours
            };
        }


    }

}
