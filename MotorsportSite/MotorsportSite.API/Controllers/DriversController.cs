using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotorsportSite.API.Models;
using MotorsportSite.API.Services.Interfaces;
using MotorsportSite.DataLevel.Drivers.Interfaces;


namespace MotorsportSite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly IDriverReader _dataReader;
        private readonly ICalculate _calculate;
        private readonly IDriverInformationService _driverInformationService;

        public DriversController(IDriverReader dataReader, ICalculate calculate, IDriverInformationService driverInformationService)
        {
            _dataReader = dataReader;
            _calculate = calculate;
            _driverInformationService = driverInformationService;
        }

        [Route("")]
        [HttpGet]
        public async Task<ActionResult<List<Driver>>> GetAllDrivers()
        {
            var result = await _dataReader.GetAllDrivers();

            return result.Select(x => Driver.MapFromDb(x)).ToList();
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult<Driver>> GetDriverById(int id)
        {
            var result = await _dataReader.GetDriverById(id);
            return Driver.MapFromDb(result);
        }

        [Route("{id}/TotalPoints")]
        [HttpGet]
        public async Task<ActionResult<decimal>> GetDriverTotalPointsById(int id)
        {
            var result = await _dataReader.GetDriversRaceResults(id);
            var points = result.Select(x => RaceResults.MapFromDb(x)).ToList();
            return _calculate.TotalDriverPoints(points);
        }

        [Route("{id}/RacePositionTotal/{position}")]
        [HttpGet]
        public async Task<ActionResult<int>> GetDriversRacePositionTotalById(int id, int position)
        {
            var result = await _dataReader.GetDriversRaceResults(id);
            var mappedData = result.Select(x => RaceResults.MapFromDb(x)).ToList();
            return _calculate.RacePositionCount(mappedData, position);
        }

        [Route("Bio")]
        [HttpGet]
        public async Task<ActionResult<List<Driver>>> GetAllDriversBio()
        {
            var result = await _driverInformationService.BuildAllDriversBio();
            return result;
        }

        [Route("CareerStats")]
        [HttpGet]
        public async Task<ActionResult<List<DriverStats>>> GetAllDriversStats()
        {
            var result = await _driverInformationService.BuildDriversCareerStats();
            return result;
        }

        [Route("SeasonStats/{season}")]
        [HttpGet]
        public async Task<ActionResult<List<DriverStats>>> GetAllDriversSeasonStats(int season)
        {
            var result = await _driverInformationService.BuildDriversSeasonStats(season);
            return result;
        }

        [Route("FullInformation/{season}")]
        [HttpGet]
        public async Task<ActionResult<List<DriversFullInfomation>>> GetAllDriversFullInfo(int season)
        {
            var result = await _driverInformationService.BuildDriversFullInformation(season);
            return result;
        }

        [Route("Championships")]
        [HttpGet]
        public async Task<ActionResult<List<DriverChampionship>>> GetAllDriversChampionships()
        {
            var result = await _driverInformationService.GetAllDriversChampionships();
            return result;
        }

        [Route("{season}/RaceResults")]
        [HttpGet]
        public async Task<ActionResult<List<RaceResults>>> GetAllDriversRaceResultsForASeason(int season)
        {
            var result = await _driverInformationService.GetAllDriversRaceResultsForASeason(season);
            return result;
        }

        [Route("{season}/CurrentSeasonVsPreviousSeason")]
        [HttpGet]
        public async Task<ActionResult<List<RaceResults>>> GetDriversCurrentSeasonResultsVsPreviousSeason(int season)
        {
            var result = await _driverInformationService.GetDriversCurrentSeasonVsLastSeasonResults(season);
            return result;
        }


    }
}