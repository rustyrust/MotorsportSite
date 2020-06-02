using System;
using System.Collections.Generic;
using MotorsportSite.API.Services;
using System.Text;
using Xunit;
using MotorsportSite.API.Models;

namespace MotorsportSite.Tests.DriverCalculationTest
{
    public class LapsLeadTest
    {
        [Fact]
        public void RacePositionCount_CalFirstPlaceFinishes()
        {
            Calculate calculate = new Calculate();

            //Arange
            int expected = 8;

            List<RaceResults> raceResults = new List<RaceResults>
            {
                new RaceResults
                {
                     DriverId = 1,
                     LapsLead = 5
                },
                new RaceResults
                {
                     DriverId = 1,
                     LapsLead = 3
                }
            };

            //Act
            int actual = calculate.LapsLead(raceResults);

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
