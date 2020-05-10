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

            //var driverInfo = DriverInformation.Mapper(driverData, bestTrack, totalPoints, currentSeasonPoints, highestResult, totalNumOfHighestResult);
            return new DriverInformation();
        }

        public async Task<List<DriverInformation>> BuildDriversInfo()
        {
            List<DriverInformation> driverInformation = new List<DriverInformation>();

            var alldriversData = await _driverReader.GetAllDrivers();

            foreach (var driver in alldriversData)
            {

                var raceData = await _driverReader.GetDriversRaceResults(driver.Id);
                var results = raceData.Select(x => RaceResults.MapFromDb(x)).ToList();
                var calcData = CalculateDriverData(results);

                driverInformation.Add(DriverInformation.Mapper(driver, calcData));
            }

            return driverInformation;
        }

        private DriverCalculationInfo CalculateDriverData(List<RaceResults> driverResults)
        {
            var bestTrack = _calculate.DriversBestTrack(driverResults);
            var totalPoints = _calculate.TotalDriverPoints(driverResults);
            var currentSeasonPoints = _calculate.TotalDriverPointsOfASeason(driverResults, DateTime.Now.Year);
            var highestResult = _calculate.HighestResult(driverResults);
            var totalNumOfHighestResult = _calculate.RacePositionCount(driverResults, highestResult);

            var calcData = new DriverCalculationInfo { BestTrack = bestTrack, TotalPoints = totalPoints, TotalPointsOfCurrentSeason = currentSeasonPoints, HighestResult = highestResult, 
                                                       TotalNumOfHighestResult = totalNumOfHighestResult };

            return calcData;
        }
    }
}
