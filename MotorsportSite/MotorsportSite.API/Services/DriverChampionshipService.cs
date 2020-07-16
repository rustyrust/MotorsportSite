using MotorsportSite.API.Models;
using MotorsportSite.DataLevel.Drivers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotorsportSite.API.Services
{
    public class DriverChampionshipService
    {
        private readonly IDriversChampionshipReader _driversChampionshipReader;

        public DriverChampionshipService(IDriversChampionshipReader driversChampionshipReader)
        {
            _driversChampionshipReader = driversChampionshipReader;
        }

        public async Task<List<DriverChampionshipStandings>> CalcDriversChampionship(int season)
        {
            var seasonData = await _driversChampionshipReader.GetSeasonsChampionshipResults(season);
            var champResults = new List<DriverChampionshipStandings>();

            foreach (var driver in seasonData)
            {
                var driverChampResults = new DriverChampionshipStandings();
                driverChampResults.DriverId = driver.DriverId;
                driverChampResults.Points = driver.FastestLap == true ? driver.Points + 1.0M : driver.Points;

                champResults.Add(driverChampResults);
            }

            ///need to group by and sum the points before returning the data

            return champResults.OrderBy(x => x.Points).ToList();
        }


    }
}
