using Dapper;
using MotorsportSite.DataLevel.Drivers.Models;
using MotorsportSite.DataLevel.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MotorsportSite.DataLevel.Drivers.DataAccess
{
    public class DriverQualifyingReader
    {
        private readonly IConnectionProvider _connectionProvider;

        public DriverQualifyingReader(IConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        public async Task<List<QualifingResults>> GetDriversCurrentSeasonVsLastSeasonQualifingResults(int season)
        {
            const string sql = @"  SELECT D.Id AS DriverId,
                                  	 RC.StartDate,
                                  	 RT.TrackName,
                                  	 RT.Country,
                                  	 Q1Time,
                                  	 Q2Time,
                                  	 Q3Time,
                                  	 Q.Position
                                   FROM Qualifying Q
                                   INNER JOIN Drivers D       ON D.Id = Q.DriverId
                                   INNER JOIN RaceCalendar RC ON RC.Id = Q.CalId
                                   INNER JOIN Tires T		 ON T.Id = Q.TireId
                                   INNER JOIN RaceTracks RT	 ON RT.Id = RC.TrackId
                                ";

            using (var conn = _connectionProvider.Get())
            {
                var data = await conn.QueryAsync<QualifingResults>(sql, new { season });
                return data.AsList();
            }
        }
    }
}
