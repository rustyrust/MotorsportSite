﻿using MotorsportSite.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotorsportSite.API.Services.Interfaces
{
    public interface IDriverInformationService
    {
        Task<List<Driver>> BuildAllDriversBio();
        Task<List<DriverStats>> BuildDriversSeasonStats(int season);
        Task<List<DriverStats>> BuildDriversCareerStats();
        Task<List<DriversFullInfomation>> BuildDriversFullInformation(int season);
        Task<List<DriverChampionship>> GetAllDriversChampionships();
        Task<List<RaceResults>> GetAllDriversRaceResultsForASeason(int season);
        Task<List<RaceResults>> GetDriversCurrentSeasonVsLastSeasonResults(int season);
    }
}
