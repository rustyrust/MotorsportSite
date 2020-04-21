using MotorsportSite.API.Models;
using MotorsportSite.API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotorsportSite.API.Services
{
    public class Calculate : ICalculate
    {
        const int _topTen = 10;

        public decimal TotalDriverPoints(List<RaceResults> raceResults)
        {
            var TotalPoints = raceResults.Select(x => x.Points).Sum();
            var numFastLaps = raceResults.Where(x => x.FastestLap == true).Count();

            return TotalPoints + numFastLaps;
        }

        public decimal TotalDriverPointsOfASeason(List<RaceResults> raceResults, int seasonYear)
        {
            var TotalPoints = raceResults.Where(x => x.StartDate.Year == seasonYear)
                                         .Select(x => x.Points).Sum();

            var numFastLaps = raceResults.Where(x => x.StartDate.Year == seasonYear)
                                         .Select(x => x.FastestLap == true).Count();

            return TotalPoints + numFastLaps;
        }

        public int RacePositionCount(List<RaceResults> raceResults, int position)
        {
            var total = 0;

            if (position == _topTen)
            {
                total = raceResults.Where(x => x.Position <= _topTen).Count();
            }
            total = raceResults.Where(x => x.Position == position).Count();
            return total;
        }

        public int HighestResult(List<RaceResults> raceResults)
        {
            var position = raceResults.Max(x => x.Position);
            return position;
        }

        public string DriversBestTrack(List<RaceResults> raceResults)
        {
            var totalPositionsForTracks = raceResults.GroupBy(x => x.TrackName)
                                                     .Select(y => new { trackName = y.Key,
                                                                        total = y.Sum(x => x.Position)
                                                                      });
            var bestTrack = totalPositionsForTracks.OrderBy(x => x.total).Select(x => x.trackName).FirstOrDefault();

            return bestTrack;
        }


    }
}
