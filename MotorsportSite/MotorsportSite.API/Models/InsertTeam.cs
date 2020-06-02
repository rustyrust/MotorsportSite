using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotorsportSite.API.Models
{
    public class InsertTeam
    {
        public string TeamName { get; set; }
        public string PrimaryColourName { get; set; }
        public string PrimaryColour { get; set; }
        public string SecondaryColourName { get; set; }
        public string SecondaryColour { get; set; }

        public static MotorsportSite.DataLevel.Models.Team MapFromAPI(InsertTeam dataModel)
        {
            return new MotorsportSite.DataLevel.Models.Team
            {
                TeamName = dataModel.TeamName,
                PrimaryColour = dataModel.PrimaryColour,
                PrimaryColourName = dataModel.PrimaryColourName,
                SecondaryColour = dataModel.SecondaryColour,
                SecondaryColourName = dataModel.SecondaryColourName
            };
        }

    }

}
