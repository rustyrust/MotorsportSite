using Dapper;
using MotorsportSite.DataLevel.DataAccess.Interfaces;
using MotorsportSite.DataLevel.Models;
using System;
using System.Collections.Generic;
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

        public async Task<List<Team>> GetAllTeams()
        {
            const string sql = @"SELECT
                                   Id, 
                                   TeamName, 
                                   EntryDate, 
                                   LeaveDate,
                                   Livery
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
                                   LeaveDate,
                                   Livery
                                 FROM [dbo].Teams
                                 WHERE id = @id
                                ";

            using (var conn = _connectionProvider.Get())
            {
                return await conn.QuerySingleOrDefaultAsync<Team>(sql, new { id });
            }

        }

        public async Task<List<TeamPrinciple>> GetAllTeamPrinciples()
        {
            const string sql = @"SELECT
                                   Id, 
                                   FirstName,
                                   Nationality,
                                   DOB,
                                   LastName,
                                   EntryDate,
                                   LeaveDate
                                 FROM [dbo].TeamPrinciple
                                ";

            using (var conn = _connectionProvider.Get())
            {
                var data = await conn.QueryAsync<TeamPrinciple>(sql);
                return data.AsList();
            }
        }

        public async Task<TeamPrinciple> GetTeamPrincipleById(int id)
        {
            const string sql = @"SELECT
                                   Id, 
                                   FirstName,
                                   Nationality,
                                   DOB,
                                   LastName,
                                   EntryDate,
                                   LeaveDate
                                 FROM [dbo].TeamPrinciple
                                 WHERE Id = @Id
                                ";

            using (var conn = _connectionProvider.Get())
            {
                return await conn.QuerySingleOrDefaultAsync<TeamPrinciple>(sql, new { id });
            }
        }

        public async Task<List<Team>> GetAllTeamsInfo()
        {
            const string sql = @"SELECT
                                   T.Id, 
                                   T.TeamName, 
                                   T.EntryDate, 
                                   T.LeaveDate,
                                   T.Livery,
                                   TP.FirstName,
                                   TP.LastName,
                                   M.Name
                                 FROM [dbo].Teams T
                                 INNER JOIN [dbo].TeamPrinciple TP  ON TP.Id = T.TeamPrincipleId
                                 INNER JOIN [dbo].TeamsPowerUnit PU ON PU.TeamId = T.Id
                                 INNER JOIN [dbo].Manufactures M    ON M.Id = PU.ManufactureId
                                ";

            using (var conn = _connectionProvider.Get())
            {
                var data = await conn.QueryAsync<Team>(sql);
                return data.AsList();
            }
        }
    }
}
