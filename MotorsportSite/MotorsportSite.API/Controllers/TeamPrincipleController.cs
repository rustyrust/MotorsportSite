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
    public class TeamPrincipleController : ControllerBase
    {
        private readonly IDataReader _dataReader;
        private readonly IDataWriter _dataWriter;

        public TeamPrincipleController(IDataReader dataReader, IDataWriter dataWriter)
        {
            _dataReader = dataReader;
            _dataWriter = dataWriter;
        }

        [Route("")]
        [HttpGet]
        public async Task<ActionResult<List<TeamPrinciple>>> GetAllTeamPrinciples()
        {
            var result = await _dataReader.GetAllTeamPrinciples();

            return result.Select(x => TeamPrinciple.MapFromDb(x)).ToList();
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult<TeamPrinciple>> GetATeamById(int id)
        {
            var result = await _dataReader.GetTeamPrincipleById(id);
            return TeamPrinciple.MapFromDb(result);
        }
    }
}