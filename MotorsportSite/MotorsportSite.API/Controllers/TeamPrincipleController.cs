using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotorsportSite.API.Models;
using MotorsportSite.DataLevel.TeamPrinciples.Interfaces;

namespace MotorsportSite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamPrincipleController : ControllerBase
    {
        private readonly ITeamPrincipleDataReader _dataReader;
        private readonly ITeamPrincipleDataWriter _dataWriter;


        public TeamPrincipleController(ITeamPrincipleDataReader dataReader, ITeamPrincipleDataWriter dataWriter)
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
        public async Task<ActionResult<TeamPrinciple>> GetTeamPrincipleById(int id)
        {
            var result = await _dataReader.GetTeamPrincipleById(id);
            return TeamPrinciple.MapFromDb(result);
        }

        [Route("")]
        [HttpPost]
        public async Task<ActionResult> InsertATeamPrincple([FromBody]InsertTeamPrincple teamPrincple)
        {
            var mappedData = InsertTeamPrincple.MapFromAPI(teamPrincple);
            var teamPrincipleId = await _dataWriter.AddATeamPrinciple(mappedData);

            return CreatedAtAction(nameof(GetTeamPrincipleById), new { id = teamPrincipleId }, null);
        }
    }
}