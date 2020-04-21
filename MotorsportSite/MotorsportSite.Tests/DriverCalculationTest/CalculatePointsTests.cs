using System;
using Xunit;
using MotorsportSite.API.Services;
using MotorsportSite.API.Models;
using System.Collections.Generic;

namespace MotorsportSite.Tests
{
    public class CalculatePointsTests
    {
        [Fact]
        public void TotalDriverPoints_CalcPointsWithoutFastLap()
        {
            Calculate calculate = new Calculate();

            // Arrange
            decimal excpected = 43;

            List<RaceResults> driverPoints = new List<RaceResults> { 
                new RaceResults
                {
                  DriverId = 1,
                  Points = 25,
                  Position = 1,
                  FastestLap = false
                },
                new RaceResults
                {
                  DriverId = 1,
                  Points = 18,
                  Position = 2,
                  FastestLap = false
                }
             };

            // Act
            decimal actual = calculate.TotalDriverPoints(driverPoints);

            // Assert
            Assert.Equal(excpected, actual);
        }

        [Fact]
        public void TotalDriverPoints_CalcPointsWithFastLap()
        {
            Calculate calculate = new Calculate();

            // Arrange
            decimal excpected = 45;

            List<RaceResults> driverPoints = new List<RaceResults> {
                new RaceResults
                {
                  DriverId = 1,
                  Points = 25,
                  Position = 1,
                  FastestLap = true
                },
                new RaceResults
                {
                  DriverId = 1,
                  Points = 18,
                  Position = 2,
                  FastestLap = true
                }
             };

            // Act*
            decimal actual = calculate.TotalDriverPoints(driverPoints);

            // Assert
            Assert.Equal(excpected, actual);
        }
    }
}
