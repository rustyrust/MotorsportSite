using MotorsportSite.DataLevel.Drivers.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MotorsportSite.DataLevel.Drivers.Interfaces
{
    public interface IDriverReader
    {
        Task<List<int>> GetAllDriverIds();
        Task<List<Driver>> GetAllDrivers();
        Task<Driver> GetDriverById(int id);
        Task<List<RaceResults>> GetAllDriversRaceResults();
        Task<List<RaceResults>> GetDriversRaceResults(int id);
        Task<List<RaceResults>> GetDriversSeasonRaceResults(int season);
        Task<List<DriverChampionship>> GetDriversChampionships();
    }
}
