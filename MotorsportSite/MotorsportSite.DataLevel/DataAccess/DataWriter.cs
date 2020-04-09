﻿using Dapper;
using MotorsportSite.DataLevel.DataAccess.Interfaces;
using MotorsportSite.DataLevel.Models;
using System.Threading.Tasks;

namespace MotorsportSite.DataLevel.DataAccess
{
    public class DataWriter : IDataWriter
    {
        private readonly IConnectionProvider _connectionProvider;

        public DataWriter(IConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        public async Task<int> CreateTeam(Team team)
        {
            var sql = @"INSERT INTO [dbo].Teams (TeamName, EntryDate, LeaveDate, TeamColours)
                            VALUES (@TeamName, @EntryDate, @LeaveDate, @TeamColours)
                         SELECT CAST (SCOPE_IDENTITY() as int);";

            using (var conn = _connectionProvider.Get())
            {
                return await conn.ExecuteScalarAsync<int>(sql, team).ConfigureAwait(false);                
            }
        }
    }
}