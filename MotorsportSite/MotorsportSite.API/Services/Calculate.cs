using MotorsportSite.API.Models;
using MotorsportSite.API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace MotorsportSite.API.Services
{
    public class Calculate : ICalculate
    {

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

            var numFastLaps = raceResults.Where(x => x.StartDate.Year == seasonYear && x.FastestLap == true).Count();
            return TotalPoints + numFastLaps;

        }

        public int RacePositionCount(List<RaceResults> raceResults, int position)
        {
            var total = raceResults.Where(x => x.Position == position).Count();
            return total;
        }

        public int TopTenPositionCount(List<RaceResults> raceResults)
        {
  
                var total = raceResults.Where(x => x.Position <= 10 && x.Position != 0).Count();
                return total;
  
        }

        public int LapsLead(List<RaceResults> raceResults)
        {

                var result = raceResults.Select(x => x.LapsLead).Sum();
                return result;

        }

        public int Overtakes(List<RaceResults> raceResults)
        {

                var result = raceResults.Select(x => x.Overtakes).Sum();
                return result;

        }

        public int HighestResult(List<RaceResults> raceResults)
        {
            if (raceResults != null)
            {
                var position = raceResults.Min(x => x.Position);
                return position;
            }
            return 0;
        }

        public string DriversBestTrack(List<RaceResults> raceResults)
        {
            var totalPositionsForTracks = raceResults.GroupBy(x => x.TrackName)
                                                     .Select(y => new
                                                     {
                                                         trackName = y.Key,
                                                         total = y.Sum(x => x.Position)
                                                     });
            var bestTrack = totalPositionsForTracks.OrderBy(x => x.total).Select(x => x.trackName).FirstOrDefault();
            return bestTrack ?? "Not enough information";
        }

        public int NumberOfRaceFastestLaps(List<RaceResults> raceResults)
        {
            if (raceResults != null)
            {
                var amount = raceResults.Count(x => x.FastestLap == true);
                return amount;
            }
            return 0;
        }

        public int NumberOfRacesCompleted(List<RaceResults> raceResults)
        {
            if (raceResults != null)
            {
                var amount = raceResults.Count();
                return amount;
            }
            return 0;
        }

        public int NumberOfDnfs(List<RaceResults> raceResults)
        {
            if (raceResults != null)
            {
                var amount = raceResults.Count(x => x.Position == 0);
                return amount;
            }
            return 0;
        }

        public int TotalNumberOfLapsCompleted(List<RaceResults> raceResults)
        {
            if (raceResults != null)
            {
                var amount = raceResults.Sum(x => x.LapsCompleted);
                return amount;
            }
            return 0;
        }

        public int BestSeason(List<RaceResults> raceResults)
        {
            if (raceResults != null)
            {
                var totalPointsPerSeason = raceResults.GroupBy(x => x.StartDate.Year)
                                                  .Select(y => new
                                                  {
                                                      season = y.Key,
                                                      total = y.Sum(x => x.Points)
                                                  });
                var bestSeason = totalPointsPerSeason.OrderByDescending(x => x.total).Select(x => x.season).FirstOrDefault();
                return bestSeason;
            }
            return 0;
        }

        public int NumberOfChampionshipsWon(List<RaceResults> raceResults)
        {
            if (raceResults != null)
            {
                var amount = raceResults.Count(x => x.IsChampion == true);
                return amount;
            }
            return 0;
        }

        //Starting postition to final race positon



        //Calculations for Qually
    }
}
