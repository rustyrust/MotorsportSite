using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotorsportSite.API.Models;
using MotorsportSite.DataLevel.Drivers.Interfaces;


namespace MotorsportSite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly IDriverReader _dataReader;


        public DriversController(IDriverReader dataReader)
        {
            _dataReader = dataReader;
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
    }
}