using System;

namespace MotorsportSite.API.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public string PrimaryColourName { get; set; }
        public string PrimaryColour { get; set; }
        public string SecondaryColourName { get; set; }
        public string SecondaryColour { get; set; }

        public static Team MapFromDb(MotorsportSite.DataLevel.Models.Team dataModel)
        {
            return new Team
            {
                Id = dataModel.Id,
                TeamName = dataModel.TeamName,
                PrimaryColourName = dataModel.PrimaryColourName,
                PrimaryColour = dataModel.PrimaryColour,
                SecondaryColourName = dataModel .SecondaryColourName,
                SecondaryColour = dataModel.SecondaryColour
            };
        }
    }
}