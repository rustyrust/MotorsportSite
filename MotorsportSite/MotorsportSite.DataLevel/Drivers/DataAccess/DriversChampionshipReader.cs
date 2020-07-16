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
    public class DriversChampionshipReader : IDriversChampionshipReader
    {
        private readonly IConnectionProvider _connectionProvider;

        public DriversChampionshipReader(IConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        public async Task<List<DriverRaceDataForChampionship>> GetSeasonsChampionshipResults(int season)
        {
            const string sql = @"  SELECT R.DriverId,
                                          P.Points,
                                   		  R.FastestLap,
                                   		  D.DriverNumber,
                                   		  D.FirstName,
                                   		  D.LastName,
                                   		  D.Country,
                                   		  T.TeamName
                                    FROM RaceResults R
                                    INNER JOIN RaceCalendar C  ON C.Id = R.CalId
                                    INNER JOIN Points P        ON P.Id = R.PointsId
                                    INNER JOIN Drivers D       ON D.Id = R.DriverId
                                    INNER JOIN DriverMarket DM ON DM.DriverId = D.Id
                                    INNER JOIN Teams T         ON T.Id = DM.TeamId
                                    WHERE YEAR(C.StartDate) = @season";

            using (var conn = _connectionProvider.Get())
            {
                var data = await conn.QueryAsync<DriverRaceDataForChampionship>(sql, new {season});
                return data.AsList();
            }
        }
    }
}
