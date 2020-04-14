using Dapper;
using MotorsportSite.DataLevel.Services.Interfaces;
using MotorsportSite.DataLevel.TeamPrinciples.Interfaces;
using MotorsportSite.DataLevel.TeamPrinciples.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotorsportSite.DataLevel.TeamPrinciples.DataAccess
{
    public class TeamPrincipleDataWriter : ITeamPrincipleDataWriter
    {
        private readonly IConnectionProvider _connectionProvider;

        public TeamPrincipleDataWriter(IConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        public async Task<int> AddATeamPrinciple(TeamPrinciple teamPrinciple)
        {
            var sql = @"INSERT INTO [dbo].TeamPrinciple (FirstName, LastName, Nationality, DOB, EntryDate, LeaveDate)
                            VALUES (@FirstName, @LastName, @Nationality, @DOB, @EntryDate, @LeaveDate)
                         SELECT CAST (SCOPE_IDENTITY() as int);";

            using (var conn = _connectionProvider.Get())
            {
                return await conn.ExecuteScalarAsync<int>(sql, teamPrinciple);
            }
        }
    }
}
