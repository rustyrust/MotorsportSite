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

        public async Task<List<Driver>> BuildAllDriversBio()
        {
            var result = await _driverReader.GetAllDrivers();

            return result.Select(x => Driver.MapFromDb(x)).ToList();
        }

        public async Task<List<DriversFullInfomation>> BuildDriversFullInformation(int season)
        {
            var allDriversInfo = new List<DriversFullInfomation>();
            var bio = await BuildAllDriversBio();
            var seasonStats = await BuildDriversSeasonStats(season);
            var careerStats = await BuildDriversCareerStats();

            foreach (var driver in bio)
            {
                var driverInfo = new DriversFullInfomation();
                driverInfo.DriverBio = driver;

                foreach (var driverSeason in seasonStats)
                {
                    if (driverSeason.Id == driver.Id)
                    {
                        driverInfo.DriverSeasonStats = driverSeason;
                    }
                }

                foreach (var driverCareer in careerStats)
                {
                    if (driverCareer.Id == driver.Id)
                    {
                        driverInfo.DriverCareerStats = driverCareer;
                    }
                }

                allDriversInfo.Add(driverInfo);
            }
                        
            return allDriversInfo;
        }

        public async Task<List<DriverStats>> BuildDriversCareerStats()
        {
            List<DriverStats> driverStats = new List<DriverStats>();

            var raceData = await _driverReader.GetAllDriversRaceResults();
            var driverData = raceData.GroupBy(x => x.DriverId);

            foreach (var driver in driverData)
            {
                var result = driver.Select(x => RaceResults.MapFromDb(x)).ToList();
                var calcData = CalculateDriverData(result);

                driverStats.Add(DriverStats.Mapper(driver.Key, calcData));
            }

            return driverStats;
        }

        public async Task<List<DriverStats>> BuildDriversSeasonStats(int season)
        {
            List<DriverStats> driverStats = new List<DriverStats>();

            var raceData = await _driverReader.GetDriversSeasonRaceResults(season);
            var driverData = raceData.GroupBy(x => x.DriverId);

            foreach (var driver in driverData)
            {
                var result = driver.Select(x => RaceResults.MapFromDb(x)).ToList();
                var calcData = CalculateDriverData(result);

                driverStats.Add(DriverStats.Mapper(driver.Key, calcData));
            }

            return driverStats;
        }


        private DriverCalculationInfo CalculateDriverData(List<RaceResults> driverResults)
        {
            var bestTrack = _calculate.DriversBestTrack(driverResults);
            var totalPoints = _calculate.TotalDriverPoints(driverResults);
            var currentSeasonPoints = _calculate.TotalDriverPointsOfASeason(driverResults, DateTime.Now.Year);
            var highestResult = _calculate.HighestResult(driverResults);
            var totalNumOfHighestResult = _calculate.RacePositionCount(driverResults, highestResult);
            var numRaceFastestLaps = _calculate.NumberOfRaceFastestLaps(driverResults);
            var numOfRacesCompleted = _calculate.NumberOfRacesCompleted(driverResults);
            var numDNFs = _calculate.NumberOfDnfs(driverResults);
            var totalLapsComplete = _calculate.TotalNumberOfLapsCompleted(driverResults);
            var bestSeason = _calculate.BestSeason(driverResults);
            var numChapionships = _calculate.NumberOfChampionshipsWon(driverResults);
            var TopTenFinishes = _calculate.TopTenPositionCount(driverResults);
            var numOfWins = _calculate.RacePositionCount(driverResults, 1);
            var numOfLapsLead = _calculate.LapsLead(driverResults);
            var numOfOvertakes = _calculate.Overtakes(driverResults);

            var calcData = new DriverCalculationInfo { BestTrack = bestTrack, TotalPoints = totalPoints, TotalPointsOfCurrentSeason = currentSeasonPoints, HighestResult = highestResult, 
                                                       TotalNumOfHighestResult = totalNumOfHighestResult, NumRaceFastestLaps = numRaceFastestLaps, NumChapionships = numChapionships,
                                                       BestSeason = bestSeason, NumDNFs = numDNFs, NumOfRacesCompleted = numOfRacesCompleted, TotalLapsComplete = totalLapsComplete,
                                                       TopTenFinishes = TopTenFinishes, NumOfRaceWins = numOfWins, LeadLaps = numOfLapsLead, Overtakes = numOfOvertakes
            };

            return calcData;
        }
    }
}
