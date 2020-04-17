using Dapper;
using MotorsportSite.DataLevel.Drivers.Interfaces;
using MotorsportSite.DataLevel.Drivers.Models;
using MotorsportSite.DataLevel.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MotorsportSite.DataLevel.Drivers.DataAccess
{
    public class DriverReader : IDriverReader
    {
        private readonly IConnectionProvider _connectionProvider;

        public DriverReader(IConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        public async Task<List<Driver>> GetAllDrivers()
        {
            const string sql = @"SELECT
                                   Id,
                                   CatagoryId,
                                   FirstName, 
                                   LastName, 
                                   ShortName,
                                   DriverNumber,
                                   DOB,
                                   Country,
                                   PlaceOfBirth
                                 FROM [dbo].Drivers
                                ";

            using (var conn = _connectionProvider.Get())
            {
                var data = await conn.QueryAsync<Driver>(sql);
                return data.AsList();
            }
        }

        public async Task<Driver> GetDriverById(int id)
        {
            const string sql = @"SELECT
                                   Id,
                                   CatagoryId,
                                   FirstName, 
                                   LastName, 
                                   ShortName,
                                   DriverNumber,
                                   DOB,
                                   Country,
                                   PlaceOfBirth
                                 FROM [dbo].Drivers
                                 WHERE Id = @id
                                ";

            using (var conn = _connectionProvider.Get())
            {
                return await conn.QuerySingleAsync<Driver>(sql, new { id });
            }
        }

        public async Task<List<DriverPoints>> GetDriverPoints(int id)
        {
            const string sql = @"SELECT
                                    R.DriverId,
                                    P.Points,
                                    P.Position,
                                    R.FastestLap
                                 FROM [dbo].RaceResults R
                                 INNER JOIN [dbo].Points P  ON P.Id = R.PointsId
                                 WHERE R.DriverId = @id
                                ";

            using (var conn = _connectionProvider.Get())
            {
                var data = await conn.QueryAsync<DriverPoints>(sql, new { id });
                return data.AsList();
            }
        }
    }
}
