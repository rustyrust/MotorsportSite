using Dapper;
using MotorsportSite.DataLevel.Services.Interfaces;
using MotorsportSite.DataLevel.TeamPrinciples.Interfaces;
using MotorsportSite.DataLevel.TeamPrinciples.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotorsportSite.DataLevel.TeamPrinciples.DataAccess
{
    public class TeamPrincipleDataReader : ITeamPrincipleDataReader
    {
        private readonly IConnectionProvider _connectionProvider;

        public TeamPrincipleDataReader(IConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
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
    }
}
