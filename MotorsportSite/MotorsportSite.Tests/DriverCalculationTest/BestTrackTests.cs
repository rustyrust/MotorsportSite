using System;
using System.Collections.Generic;
using MotorsportSite.API.Services;
using System.Text;
using Xunit;
using MotorsportSite.API.Models;

namespace MotorsportSite.Tests
{
    public class BestTrackTests
    {
        [Fact]
        public void DriversBestTrack_CalcBetweenTwoTracks()
        {
            Calculate calculate = new Calculate();

            //Arange
            string expected = "Silverstone";

            List<RaceResults> raceResults = new List<RaceResults>
            {
                new RaceResults
                {
                     DriverId = 1,
                     Position = 1,
                     TrackName = "Silverstone",
                     StartDate = new DateTime(2019, 07, 27)
                },
                new RaceResults
                {
                     DriverId = 1,
                     Position = 1,
                     TrackName = "Silverstone",
                     StartDate = new DateTime(2018, 07, 27)
                },
                new RaceResults
                {
                     DriverId = 1,
                     Position = 2,
                     TrackName = "Monza",
                     StartDate = new DateTime(2019, 07, 27)
                },
                new RaceResults
                {
                     DriverId = 1,
                     Position = 2,
                     TrackName = "Monza",
                     StartDate = new DateTime(2018, 07, 27)
                }
            };

            //Act
            string actual = calculate.DriversBestTrack(raceResults);

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
