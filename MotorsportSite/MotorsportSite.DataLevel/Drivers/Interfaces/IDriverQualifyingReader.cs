using MotorsportSite.DataLevel.Drivers.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MotorsportSite.DataLevel.Drivers.Interfaces
{
    public interface IDriverQualifyingReader
    {
        Task<List<QualifingResults>> GetDriversCurrentSeasonVsLastSeasonQualifingResults(int season);
    }
}
