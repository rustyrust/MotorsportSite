using System;

namespace MotorsportSite.API.Models
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

        public static Driver MapFromDb(MotorsportSite.DataLevel.Drivers.Models.Driver dataModel)
        {
            return new Driver
            {
                Id = dataModel.Id,
                CatagoryId = dataModel.CatagoryId,
                FirstName = dataModel.FirstName,
                LastName = dataModel.LastName,
                ShortName = dataModel.ShortName,
                DriverNumber = dataModel.DriverNumber,
                DOB = dataModel.DOB,
                Country = dataModel.Country,
                PlaceOfBirth = dataModel.PlaceOfBirth
            };
        }
    }

}
