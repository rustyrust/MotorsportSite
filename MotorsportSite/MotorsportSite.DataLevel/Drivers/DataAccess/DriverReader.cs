using Dapper;
using MotorsportSite.DataLevel.Drivers.Interfaces;
using MotorsportSite.DataLevel.Drivers.Models;
using MotorsportSite.DataLevel.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<int>> GetAllDriverIds()
        {
            const string sql = @"SELECT Id
                                 FROM [dbo].Drivers";

            using (var conn = _connectionProvider.Get())
            {
                var data = await conn.QueryAsync<int>(sql);
                return data.ToList();
            }
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

        public async Task<List<RaceResults>> GetAllDriversRaceResults()
        {
            const string sql = @"SELECT
                                    R.DriverId,
                                    R.LapsCompleted,
                                    R.IsChampion,
                                    P.Points,
                                    P.Position,
                                    R.FastestLap,
                                    T.TrackName,
                                    C.StartDate
                                 FROM [dbo].RaceResults R
                                 INNER JOIN [dbo].Points P        ON P.Id = R.PointsId
                                 INNER JOIN [dbo].RaceCalendar C  ON C.Id = R.CalId
								 INNER JOIN [dbo].RaceTracks T    ON T.Id = C.TrackId
                                ";

            using (var conn = _connectionProvider.Get())
            {
                var data = await conn.QueryAsync<RaceResults>(sql);
                return data.AsList();
            }
        }

        public async Task<List<RaceResults>> GetDriversRaceResults(int id)
        {
            const string sql = @"SELECT
                                    R.DriverId,
                                    R.LapsCompleted,
                                    R.IsChampion,
                                    P.Points,
                                    P.Position,
                                    R.FastestLap,
                                    T.TrackName,
                                    C.StartDate
                                 FROM [dbo].RaceResults R
                                 INNER JOIN [dbo].Points P        ON P.Id = R.PointsId
                                 INNER JOIN [dbo].RaceCalendar C  ON C.Id = R.CalId
								 INNER JOIN [dbo].RaceTracks T    ON T.Id = C.TrackId
                                 WHERE R.DriverId = @id
                                ";

            using (var conn = _connectionProvider.Get())
            {
                var data = await conn.QueryAsync<RaceResults>(sql, new { id });
                return data.AsList();
            }
        }

        public async Task<List<RaceResults>> GetDriversSeasonRaceResults(int season)
        {
            const string sql = @"SELECT
                                    R.DriverId,
                                    R.LapsCompleted,
                                    R.IsChampion,
                                    P.Points,
                                    P.Position,
                                    R.FastestLap,
                                    T.TrackName,
                                    C.StartDate
                                 FROM [dbo].RaceResults R
                                 INNER JOIN [dbo].Points P        ON P.Id = R.PointsId
                                 INNER JOIN [dbo].RaceCalendar C  ON C.Id = R.CalId
								 INNER JOIN [dbo].RaceTracks T    ON T.Id = C.TrackId
                                 WHERE YEAR(C.StartDate) = @season
                                ";

            using (var conn = _connectionProvider.Get())
            {
                var data = await conn.QueryAsync<RaceResults>(sql, new { season });
                return data.AsList();
            }
        }
    }
}
