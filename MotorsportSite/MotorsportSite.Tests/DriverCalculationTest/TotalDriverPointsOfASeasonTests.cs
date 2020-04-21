using System;
using System.Collections.Generic;
using MotorsportSite.API.Services;
using System.Text;
using Xunit;
using MotorsportSite.API.Models;

namespace MotorsportSite.Tests.DriverCalculationTest
{
    public class TotalDriverPointsOfASeasonTests
    {
        [Fact]
        public void TotalDriverPointsOfASeasonTests_Calc2019SeasonForHamilton()
        {
            Calculate calculate = new Calculate();

            //Arange            
            int expected = 51;

            int season = 2019;
            List<RaceResults> raceResults = new List<RaceResults>
            {
                new RaceResults
                {
                     DriverId = 1,
                     Points = 25,
                     FastestLap = true,
                     StartDate = new DateTime(2019, 07, 27)
                },
                new RaceResults
                {
                     DriverId = 1,
                     Points = 25,
                     FastestLap = false,
                     StartDate = new DateTime(2019, 08, 27)
                }
            };

            //Act
            decimal actual = calculate.TotalDriverPointsOfASeason(raceResults, season);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TotalDriverPointsOfASeasonTests_CalcMixSeasonForHamilton()
        {
            Calculate calculate = new Calculate();

            //Arange            
            int expected = 51;

            int season = 2019;
            List<RaceResults> raceResults = new List<RaceResults>
            {
                new RaceResults
                {
                     DriverId = 1,
                     Points = 25,
                     FastestLap = true,
                     StartDate = new DateTime(2019, 07, 27)
                },
                new RaceResults
                {
                     DriverId = 1,
                     Points = 25,
                     FastestLap = false,
                     StartDate = new DateTime(2019, 08, 27)
                },
                new RaceResults
                {
                     DriverId = 1,
                     Points = 25,
                     FastestLap = true,
                     StartDate = new DateTime(2018, 07, 27)
                },
                new RaceResults
                {
                     DriverId = 1,
                     Points = 25,
                     FastestLap = false,
                     StartDate = new DateTime(2018, 08, 27)
                }
            };

            //Act
            decimal actual = calculate.TotalDriverPointsOfASeason(raceResults, season);

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
