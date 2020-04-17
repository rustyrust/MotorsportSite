using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotorsportSite.API.Models
{
    public class DriverPoints
    {
        public int DriverId { get; set; }
        public decimal Points { get; set; }
        public int Position { get; set; }
        public bool FastestLap { get; set; }

        public static DriverPoints MapFromDb(DataLevel.Drivers.Models.DriverPoints dataModel)
        {
            return new DriverPoints
            {
                DriverId = dataModel.DriverId,
                Points = dataModel.Points,
                Position = dataModel.Position,
                FastestLap = dataModel.FastestLap
            };
        }
    }
}
