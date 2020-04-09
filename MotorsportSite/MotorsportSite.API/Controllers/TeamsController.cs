using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotorsportSite.API.Models;
using MotorsportSite.DataLevel.DataAccess.Interfaces;

namespace MotorsportSite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly IDataReader _dataReader;
        public TeamsController(IDataReader dataReader)
        {
            _dataReader = dataReader;
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult<Team>> GetATeamById(int id)
        {
            var result = await _dataReader.GetTeamById(id);
            return Team.Map(result);
        }
    }
}