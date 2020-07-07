using MotorsportSite.API.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MotorsportSite.Tests.DriverInformationServiceTest
{
    public class GetDriverCurrentSeasonVsPreviousResultsTests
    {
        [Fact]
        public void DuplicateRaces()
        {
            //DriverInformationService driverService = new DriverInformationService();

            ////Arange
            //var expected = 1;

            //List<RaceResults> raceResults = new List<RaceResults>
            //{
            //    new RaceResults
            //    {
            //         DriverId = 1,
            //         Position = 1,
            //         LapsCompleted = 71
            //    },
            //    new RaceResults
            //    {
            //         DriverId = 1,
            //         Position = 4,
            //         LapsCompleted = 71
            //    },
            //    new RaceResults
            //    {
            //         DriverId = 1,
            //         Position = 2,
            //         LapsCompleted = 71
            //    },
            //    new RaceResults
            //    {
            //         DriverId = 1,
            //         Position = 10,
            //         LapsCompleted = 71,
            //    }
            //};

            ////Act
            //var actual = calculate.HighestResult(raceResults);

            ////Assert
            //Assert.Equal(expected, actual);
        }
    }
}
