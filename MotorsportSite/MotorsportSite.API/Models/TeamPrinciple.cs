using System;

namespace MotorsportSite.API.Models
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

        public static TeamPrinciple MapFromDb(MotorsportSite.DataLevel.Models.TeamPrinciple dataModel)
        {
            return new TeamPrinciple
            {
                Id = dataModel.Id,
                FirstName = dataModel.FirstName,
                LastName = dataModel.LastName,
                Nationality = dataModel.Nationality,
                DOB = dataModel.DOB,
                EntryDate = dataModel.EntryDate,
                LeaveDate = dataModel.LeaveDate
            };
        }
    }
}
