using MotorsportSite.API.Models;
using MotorsportSite.API.Services.Interfaces;
using MotorsportSite.DataLevel.Drivers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace MotorsportSite.API.Services
{
    public class DriverInformationService : IDriverInformationService
    {
        private readonly IDriverReader _driverReader;
        private readonly ICalculate _calculate;

        public DriverInformationService(IDriverReader driverReader, ICalculate calculate)
        {
            _driverReader = driverReader;
            _calculate = calculate;
        }

        public async Task<DriverInformation> BuildDriverInfo(int driverid)
        {
            var driverData = await _driverReader.GetDriverById(driverid);
            var raceData = await _driverReader.GetDriversRaceResults(driverid);
            var results = raceData.Select(x => RaceResults.MapFromDb(x)).ToList();

            var bestTrack = _calculate.DriversBestTrack(results);
            var totalPoints = _calculate.TotalDriverPoints(results);
            var currentSeasonPoints = _calculate.TotalDriverPointsOfASeason(results, DateTime.Now.Year);
            var highestResult = _calculate.HighestResult(results);
            var totalNumOfHighestResult = _calculate.RacePositionCount(results, highestResult);

            var driverInfo = DriverInformation.Mapper(driverData, bestTrack, totalPoints, currentSeasonPoints, highestResult, totalNumOfHighestResult);
            return driverInfo;
        }

        public List<DriverInformation> BuildDriversInfo()
        {
            return new List<DriverInformation>();
        }
    }
}
