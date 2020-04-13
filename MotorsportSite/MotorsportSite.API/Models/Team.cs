using System;

namespace MotorsportSite.API.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime? LeaveDate { get; set; }
        public string Livery { get; set; }

        public static Team MapFromDb(MotorsportSite.DataLevel.Models.Team dataModel)
        {
            return new Team
            {
                Id = dataModel.Id,
                TeamName = dataModel.TeamName,
                EntryDate = dataModel.EntryDate,
                LeaveDate = dataModel.LeaveDate,
                Livery = dataModel.Livery
            };
        }
    }
}