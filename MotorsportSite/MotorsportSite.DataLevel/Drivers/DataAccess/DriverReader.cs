﻿using Dapper;
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
                                   D.Id,
                                   CatagoryId,
                                   FirstName, 
                                   LastName, 
                                   ShortName,
                                   DriverNumber,
                                   DOB,
                                   Country,
                                   PlaceOfBirth,
                                   T.TeamName,
                                   T.PrimaryColour AS TeamColour
                                 FROM [dbo].Drivers D
                                 INNER JOIN [dbo].DriverMarket M ON M.DriverId = D.ID
                                 INNER JOIN [dbo].Teams T        ON T.id = M.TeamId
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
                                   D.Id,
                                   CatagoryId,
                                   FirstName, 
                                   LastName, 
                                   ShortName,
                                   DriverNumber,
                                   DOB,
                                   Country,
                                   PlaceOfBirth,
                                   T.TeamName,
                                   T.PrimaryColour AS TeamColour
                                 FROM [dbo].Drivers D
                                 INNER JOIN [dbo].DriverMarket M ON M.DriverId = D.ID
                                 INNER JOIN [dbo].Teams T        ON T.id = M.TeamId
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
                                    C.StartDate,
                                    R.LapsLead,
                                    R.Overtakes
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
                                    T.Country,
                                    C.StartDate,
                                    R.LapsLead,
                                    R.Overtakes
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
                                    D.Id AS DriverId,
                                    ISNULL(R.LapsCompleted, 0) LapsCompleted,
                                    ISNULL(R.IsChampion, 0) IsChampion,
                                    ISNULL(P.Points, 0) Points,
                                    ISNULL(P.Position, 0) Position,
                                    ISNULL(R.FastestLap, 0) FastestLap,
                                    ISNULL(T.TrackName, 'None') TrackName,
                                    ISNULL(T.Country, 'None') TrackCountry,
                                    C.StartDate,
                                    ISNULL(R.LapsLead, 0) LapsLead,
                                    ISNULL(R.Overtakes, 0) Overtakes
                                 FROM [dbo].Drivers D
								 LEFT JOIN [dbo].RaceResults R	  ON R.DriverId = D.Id AND R.CalId IN (
								                                                                        SELECT Id 
																									    FROM [dbo].RaceCalendar
																									    WHERE YEAR(StartDate) = @season 
																										   AND EventName = 'Race'
                                                                                                       )
								 LEFT JOIN [dbo].Points P         ON P.Id = R.PointsId
								 LEFT JOIN [dbo].RaceCalendar C   ON C.Id = R.CalId
								 LEFT JOIN [dbo].RaceTracks T     ON T.Id = C.TrackId 
                                ";

            using (var conn = _connectionProvider.Get())
            {
                var data = await conn.QueryAsync<RaceResults>(sql, new { season });
                return data.AsList();
            }
        }

        public async Task<List<DriverChampionship>> GetDriversChampionships()
        {
            const string sql = @"SELECT 
                                   R.DriverId,
                     		       T.TeamName,
                     		       Year(C.StartDate) AS Season
                                 FROM [dbo].RaceResults R
                                 INNER JOIN [dbo].DriverMarket M ON M.DriverId = R.DriverId
                                 INNER JOIN [dbo].Teams T ON T.Id = M.TeamId
                                 INNER JOIN [dbo].RaceCalendar C ON C.Id = R.CalId
                                 WHERE R.IsChampion = 1
                                 GROUP BY Year(C.StartDate),
                                          R.DriverId,
                     		              T.TeamName";

            using (var conn = _connectionProvider.Get())
            {
                var data = await conn.QueryAsync<DriverChampionship>(sql);
                return data.AsList();
            }
        }

        public async Task<List<RaceResults>> GetDriversCurrentSeasonVsLastSeasonResults(int season)
        {
            const string sql = @"SELECT 
                                     D.Id AS DriverId,
                                     ISNULL(RR.LapsCompleted, 0) LapsCompleted,
                                     ISNULL(RR.IsChampion, 0) IsChampion,
                                     ISNULL(P.Points, 0) Points,
                                     ISNULL(P.Position, 0) Position,
                                     ISNULL(RR.FastestLap, 0) FastestLap,
                                     ISNULL(T.TrackName, 'None') TrackName,
                                     ISNULL(T.Country, 'None') TrackCountry,
                                     RC.StartDate,
                                     ISNULL(RR.LapsLead, 0) LapsLead,
                                     ISNULL(RR.Overtakes, 0) Overtakes
                                FROM RaceCalendar RC
                                LEFT JOIN RaceResults RR      ON RR.CalId = RC.Id
                                LEFT JOIN Drivers D	          ON D.Id = RR.DriverId
                                LEFT JOIN [dbo].RaceTracks T  ON T.Id = RC.TrackId 
                                LEFT JOIN [dbo].Points P      ON P.Id = RR.PointsId
                                WHERE RC.TrackId IN (
                                                       SELECT DISTINCT TrackId
                                                       FROM RaceCalendar RC
                                                       LEFT JOIN RaceResults RR ON RR.CalId = RC.Id
                                                       WHERE YEAR(RC.StartDate) = 2020
                                                         AND RC.EventName = 'Race'       
                                                     )
                                		AND RC.EventName = 'Race' 
                                		AND YEAR(RC.StartDate) BETWEEN 2019 AND 2020
                                		AND D.Id IS NOT NULL
                                ORDER BY RC.StartDate
                                ";

            using (var conn = _connectionProvider.Get())
            {
                var data = await conn.QueryAsync<RaceResults>(sql, new { season });
                return data.AsList();
            }
        }
    }
}
