using MotorsportSite.API.Models;
using MotorsportSite.API.Services.Interfaces;
using MotorsportSite.DataLevel.DataAccess.Interfaces;
using MotorsportSite.DataLevel.Drivers.Interfaces;
using MotorsportSite.DataLevel.Models;
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
        private readonly IDataReader _dataReader;
        private readonly IDriverQualifyingReader _driverQualifyingReader;

        public DriverInformationService(IDriverReader driverReader, ICalculate calculate, IDataReader dataReader, IDriverQualifyingReader driverQualifyingReader)
        {
            _driverReader = driverReader;
            _calculate = calculate;
            _dataReader = dataReader;
            _driverQualifyingReader = driverQualifyingReader;
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

            var calcData = new DriverCalculationInfo
            {
                BestTrack = bestTrack,
                TotalPoints = totalPoints,
                TotalPointsOfCurrentSeason = currentSeasonPoints,
                HighestResult = highestResult,
                TotalNumOfHighestResult = totalNumOfHighestResult,
                NumRaceFastestLaps = numRaceFastestLaps,
                NumChapionships = numChapionships,
                BestSeason = bestSeason,
                NumDNFs = numDNFs,
                NumOfRacesCompleted = numOfRacesCompleted,
                TotalLapsComplete = totalLapsComplete,
                TopTenFinishes = TopTenFinishes,
                NumOfRaceWins = numOfWins,
                LeadLaps = numOfLapsLead,
                Overtakes = numOfOvertakes
            };

            return calcData;
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

        public async Task<List<DriverChampionship>> GetAllDriversChampionships()
        {
            var result = await _driverReader.GetDriversChampionships();

            return result.Select(x => DriverChampionship.MapFromDB(x)).ToList();
        }

        public async Task<List<RaceResults>> GetAllDriversRaceResultsForASeason(int season)
        {
            var raceData = await _driverReader.GetDriversSeasonRaceResults(season);
            var orderedData = raceData.OrderBy(x => x.StartDate);

            return raceData.Select(x => RaceResults.MapFromDb(x)).ToList();
        }

        public async Task<List<RaceResults>> GetDriversCurrentSeasonVsLastSeasonResults(int season)
        {
            var raceData = await _driverReader.GetDriversCurrentSeasonVsLastSeasonResults(season);
            return await BuildRaceWeekendDataIfRacingAtSamePlaceMoreThanOnce(raceData, season);
            //var calender = await _dataReader.GetRaceCalander(season);
            //var raceDates = calender.Where(x => x.EventName == "Race").ToList();

            //if (calender.Where(x => x.EventName == "Race").GroupBy(n => n.EventName).Any(x => x.Count() > 1))
            //{
            //    var raceResults = new List<RaceResults>();
            //    foreach (var date in raceDates)
            //    {
            //        foreach (var data in raceData)
            //        {
            //            if (date.TrackName == data.TrackName && data.StartDate.Year != season)
            //            {
            //                raceResults.Add(RaceResults.MapFromDb(data));
            //            }
            //            else if (date.TrackName == data.TrackName && date.StartDate == data.StartDate)
            //            {
            //                raceResults.Add(RaceResults.MapFromDb(data));
            //            }
            //        }
            //    }

            //    return raceResults;
            //    //return BuildRaceWeekendDataIfRacingAtSamePlaceMoreThanOnce(raceData, raceDates, season);
            //}
            //else
            //{
            //    /// need to write something to pick the best result of the dupe if there is one for the previous season
            //    return raceData.Select(x => RaceResults.MapFromDb(x)).ToList();
            //}

        }

        public async Task<> GetDriversCurrentAndLastSeasonsQuallyResults(int season)
        {
            var quallyData = _driverQualifyingReader.GetDriversCurrentSeasonVsLastSeasonQualifingResults(season);
            return await BuildRaceWeekendDataIfRacingAtSamePlaceMoreThanOnce(quallyData, season);
        }

        private async Task<List<RaceCalendar>> GetTheRaceCalanderForASeason(int season)
        {
            var calender = await _dataReader.GetRaceCalander(season);
            return calender.Where(x => x.EventName == "Race").ToList();
        }

        private async Task<List<T>> BuildRaceWeekendDataIfRacingAtSamePlaceMoreThanOnce<T>(int season) where T: class, new()
        {
            var raceDates = await GetTheRaceCalanderForASeason(season);

            if (raceDates.GroupBy(n => n.EventName).Any(x => x.Count() > 1))
            {
                var raceResults = new List<T>();
                foreach (var date in raceDates)
                {
                    foreach (var data in T)
                    {
                        if (date.TrackName == data.TrackName && data.StartDate.Year != season)
                        {
                            raceResults.Add(data);
                        }
                        else if (date.TrackName == data.TrackName && date.StartDate == data.StartDate)
                        {
                            raceResults.Add(data);
                        }
                    }
                }
                return raceResults;
            }
            else
            {
                /// need to write something to pick the best result of the dupe if there is one for the previous season
                return raceData;
            }
        }
    }
}
