using MotorsportSite.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotorsportSite.API.Services.Interfaces
{
    public interface ICalculate
    {
        decimal TotalDriverPoints(List<RaceResults> driverPoints);
        int RacePositionCount(List<RaceResults> driverPoints, int position);
        decimal TotalDriverPointsOfASeason(List<RaceResults> raceResults, int seasonYear);
        int HighestResult(List<RaceResults> raceResults);
        string DriversBestTrack(List<RaceResults> raceResults);


    }
}
