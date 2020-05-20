using MotorsportSite.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotorsportSite.API.Services.Interfaces
{
    public interface IDriverInformationService
    {
        Task<List<Driver>> BuildAllDriversBio();
        Task<List<DriverInformation>> BuildDriversStats();
        Task<List<DriverStats>> BuildDriversSeasonStats(int season);
    }
}
