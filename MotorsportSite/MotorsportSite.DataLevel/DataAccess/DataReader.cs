using Dapper;
using MotorsportSite.DataLevel.DataAccess.Interfaces;
using MotorsportSite.DataLevel.Models;
using MotorsportSite.DataLevel.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorsportSite.DataLevel.DataAccess
{
    public class DataReader : IDataReader
    {
        private readonly IConnectionProvider _connectionProvider;

        public DataReader(IConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        public async Task<List<RaceCalendar>> GetRaceCalander(int season)
        {
            const string sql = @"SELECT 
                                 	RT.TrackName,
                                 	RT.Location,
                                 	RC.StartDate,
                                 	RC.EventName
                                 FROM RaceCalendar RC
                                 INNER JOIN RaceTracks RT ON RT.Id = RC.TrackId
                                 WHERE YEAR(StartDate) = @season
                                ";

            using (var conn = _connectionProvider.Get())
            {
                var data = await conn.QueryAsync<RaceCalendar>(sql, new { season });
                return data.ToList();
            }
        }

        public async Task<List<Team>> GetAllTeams()
        {
            const string sql = @"SELECT
                                   Id, 
                                   TeamName, 
                                   EntryDate,
                                   PrimaryColourName,
                                   PrimaryColour,
                                   SecondaryColourName,
                                   SecondaryColour
                                 FROM [dbo].Teams
                                ";

            using (var conn = _connectionProvider.Get())
            {
                var data =  await conn.QueryAsync<Team>(sql);
                return data.AsList();
            }
        }

        public async Task<Team> GetTeamById(int id)
        {
            const string sql = @"SELECT
                                   Id, 
                                   TeamName, 
                                   EntryDate,
                                   PrimaryColourName,
                                   PrimaryColour,
                                   SecondaryColourName,
                                   SecondaryColour
                                 FROM [dbo].Teams
                                 WHERE id = @id
                                ";

            using (var conn = _connectionProvider.Get())
            {
                return await conn.QuerySingleOrDefaultAsync<Team>(sql, new { id });
            }

        }

    }
}
