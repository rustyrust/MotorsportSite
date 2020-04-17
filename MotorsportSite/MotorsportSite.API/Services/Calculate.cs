using MotorsportSite.API.Models;
using MotorsportSite.API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotorsportSite.API.Services
{
    public class Calculate : ICalculate
    {
        public decimal TotalDriverPoints(List<DriverPoints> driverPoints)
        {
            var TotalPoints = driverPoints.Select(x => x.Points).Sum();
            var numFastLaps = driverPoints.Where(x => x.FastestLap == true).Count();

            return TotalPoints + numFastLaps;
        }

        public int RacePositionCount(List<DriverPoints> driverPoints, int position)
        {
            return driverPoints.Where(x => x.Position == position).Count();
        }
    }
}
