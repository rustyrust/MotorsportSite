using Dapper;
using MotorsportSite.DataLevel.DataAccess.Interfaces;
using MotorsportSite.DataLevel.Models;
using MotorsportSite.DataLevel.Services.Interfaces;
using System;
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
            var sql = @"INSERT INTO [dbo].Teams (TeamName, EntryDate, LeaveDate, Livery)
                            VALUES (@TeamName, @EntryDate, @LeaveDate, @Livery)
                         SELECT CAST (SCOPE_IDENTITY() as int);";

            using (var conn = _connectionProvider.Get())
            {
                return await conn.ExecuteScalarAsync<int>(sql, team);                
            }
        }

        public async Task UpdateTeamDeletedStatus(int id, DateTime deletedDate)
        {
            var sql = @"UPDATE [dbo].Teams
                        SET LeaveDate = @deletedDate
                        WHERE id = @id";

            using (var conn = _connectionProvider.Get())
            {
                await conn.ExecuteAsync(sql, new { id, deletedDate });
            }
        }
    }
}