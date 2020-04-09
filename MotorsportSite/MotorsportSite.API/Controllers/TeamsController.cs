using Microsoft.AspNetCore.Mvc;
using MotorsportSite.API.Models;
using MotorsportSite.DataLevel.DataAccess.Interfaces;
using System.Threading.Tasks;

namespace MotorsportSite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly IDataReader _dataReader;
        private readonly IDataWriter _dataWriter;

        public TeamsController(IDataReader dataReader, IDataWriter dataWriter)
        {
            _dataReader = dataReader;
            _dataWriter = dataWriter;
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult<Team>> GetATeamById(int id)
        {
            var result = await _dataReader.GetTeamById(id);
            return Team.MapFromDb(result);
        }

        [Route("")]
        [HttpPost]
        public async Task<ActionResult> InsertATeam([FromBody]InsertTeam team)
        {
            var mappedData = InsertTeam.MapFromAPI(team);
            var teamId = await _dataWriter.CreateTeam(mappedData);

            return CreatedAtAction(nameof(GetATeamById), new { id = teamId }, null);
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<ActionResult> InsertATeam(int id)
        {
            await _dataWriter.UpdateTeamDeletedStatus(id, true);

            return Ok();
        }
    }
}