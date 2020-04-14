using System;

namespace MotorsportSite.API.Models
{
    public class InsertTeamPrincple
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nationality { get; set; }
        public DateTime DOB { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime? LeaveDate { get; set; }

        public static MotorsportSite.DataLevel.TeamPrinciples.Models.TeamPrinciple MapFromAPI(InsertTeamPrincple dataModel)
        {
            return new MotorsportSite.DataLevel.TeamPrinciples.Models.TeamPrinciple
            {
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
