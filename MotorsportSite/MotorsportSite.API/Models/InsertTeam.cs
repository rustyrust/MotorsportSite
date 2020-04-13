using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotorsportSite.API.Models
{
    public class InsertTeam
    {
        public string TeamName { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime? LeaveDate { get; set; }
        public string Livery { get; set; }

        public static MotorsportSite.DataLevel.Models.Team MapFromAPI(InsertTeam dataModel)
        {
            return new MotorsportSite.DataLevel.Models.Team
            {
                TeamName = dataModel.TeamName,
                EntryDate = dataModel.EntryDate,
                LeaveDate = dataModel.LeaveDate,
                Livery = dataModel.Livery
            };
        }

    }

}
