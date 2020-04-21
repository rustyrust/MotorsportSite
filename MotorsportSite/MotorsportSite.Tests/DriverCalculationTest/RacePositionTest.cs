using System;
using System.Collections.Generic;
using MotorsportSite.API.Services;
using System.Text;
using Xunit;
using MotorsportSite.API.Models;

namespace MotorsportSite.Tests.DriverCalculationTest
{
    public class RacePositionTest
    {
        [Fact]
        public void RacePositionCount_CalFirstPlaceFinishes()
        {
            Calculate calculate = new Calculate();

            //Arange
            int expected = 4;

            var position = 1;
            List<RaceResults> raceResults = new List<RaceResults>
            {
                new RaceResults
                {
                     DriverId = 1,
                     Position = 1
                },
                new RaceResults
                {
                     DriverId = 1,
                     Position = 1
                },
                new RaceResults
                {
                     DriverId = 1,
                     Position = 1
                },
                new RaceResults
                {
                     DriverId = 1,
                     Position = 1
                }
            };

            //Act
            int actual = calculate.RacePositionCount(raceResults,position);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RacePositionCount_CalTopTenFinishes()
        {
            Calculate calculate = new Calculate();

            //Arange
            int expected = 3;

            var position = 10;
            List<RaceResults> raceResults = new List<RaceResults>
            {
                new RaceResults
                {
                     DriverId = 1,
                     Position = 9
                },
                new RaceResults
                {
                     DriverId = 1,
                     Position = 8
                },
                new RaceResults
                {
                     DriverId = 1,
                     Position = 10
                },
                new RaceResults
                {
                     DriverId = 1,
                     Position = 15
                }
            };

            //Act
            int actual = calculate.RacePositionCount(raceResults, position);

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}

