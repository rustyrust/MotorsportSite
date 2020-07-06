using MotorsportSite.DataLevel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MotorsportSite.DataLevel.DataAccess.Interfaces
{
    public interface IDataReader
    {
        Task<List<RaceCalendar>> GetRaceCalander(int season);
        Task<Team> GetTeamById(int id);
        Task<List<Team>> GetAllTeams();
    }
}
