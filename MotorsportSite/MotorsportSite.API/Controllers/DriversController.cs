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

        //[Route("{id}/TotalPoints/Season/{year}")]
        //[HttpGet]
        //public async Task<ActionResult<decimal>> GetDriverTotalPointsByIdAndSeason(int id)
        //{
 
        //}

        [Route("{id}/RacePositionTotal/{position}")]
        [HttpGet]
        public async Task<ActionResult<int>> GetDriversRacePositionTotalById(int id, int position)
        {
            var result = await _dataReader.GetDriversRaceResults(id);
            var mappedData = result.Select(x => RaceResults.MapFromDb(x)).ToList();
            return _calculate.RacePositionCount(mappedData, position);
        }

        [Route("{id}/Information")]
        [HttpGet]
        public async Task<ActionResult<DriverInformation>> GetDriversInformation(int id)
        {
            var result = await _driverInformationService.BuildDriverInfo(id);
            return result;
        }

        [Route("Information")]
        [HttpGet]
        public async Task<ActionResult<List<DriverInformation>>> GetAllDriversInformation()
        {
            var result = await _driverInformationService.BuildDriversInfo();
            return result;
        }

    }
}