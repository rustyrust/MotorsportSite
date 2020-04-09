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

        public async Task<Team> GetTeamById(int id)
        {
            const string sql = @"SELECT
                                   [Id], 
                                   [TeamName], 
                                   [EntryDate], 
                                   [LeaveDate],
                                   [TeamColours]
                                 FROM [dbo].Teams
                                 WHERE id = @id
                                ";

            using (var conn = _connectionProvider.Get())
            {
                return await conn.QuerySingleOrDefaultAsync<Team>(sql, new { id }).ConfigureAwait(false);
            }

        }
    }
}
