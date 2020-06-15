using System.Text;
using Xunit;
using MotorsportSite.API.Models;
using MotorsportSite.API.Services;
using System.Collections.Generic;

namespace MotorsportSite.Tests.DriverCalculationTest
{
    public class HighestResultTests
    {

        [Fact]
        public void HighestResult_CalcExpectedFirst()
        {
            Calculate calculate = new Calculate();

            //Arange
            var expected = 1;

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
                     Position = 4
                },
                new RaceResults
                {
                     DriverId = 1,
                     Position = 2
                },
                new RaceResults
                {
                     DriverId = 1,
                     Position = 10
                }
            };

            //Act
            var actual = calculate.HighestResult(raceResults);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void HighestResult_CalcExpectedTenth()
        {
            Calculate calculate = new Calculate();

            //Arange
            var expected = 10;

            List<RaceResults> raceResults = new List<RaceResults>
            {
                new RaceResults
                {
                     DriverId = 1,
                     Position = 13
                },
                new RaceResults
                {
                     DriverId = 1,
                     Position = 14
                },
                new RaceResults
                {
                     DriverId = 1,
                     Position = 12
                },
                new RaceResults
                {
                     DriverId = 1,
                     Position = 10
                }
            };

            //Act
            var actual = calculate.HighestResult(raceResults);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void HighestResult_DNFTest()
        {
            Calculate calculate = new Calculate();

            //Arange
            var expected = 1;

            List<RaceResults> raceResults = new List<RaceResults>
            {
                new RaceResults
                {
                     DriverId = 1,
                     Position = 0
                },
                new RaceResults
                {
                     DriverId = 1,
                     Position = 0
                },
                new RaceResults
                {
                     DriverId = 1,
                     Position = 1
                },
                new RaceResults
                {
                     DriverId = 1,
                     Position = 2
                }
            };

            //Act
            var actual = calculate.HighestResult(raceResults);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void HighestResult_AllDNFsResults()
        {
            Calculate calculate = new Calculate();

            //Arange
            var expected = 0;

            List<RaceResults> raceResults = new List<RaceResults>
            {
                new RaceResults
                {
                     DriverId = 1,
                     Position = 0
                },
                new RaceResults
                {
                     DriverId = 1,
                     Position = 0
                },
                new RaceResults
                {
                     DriverId = 1,
                     Position = 0
                },
                new RaceResults
                {
                     DriverId = 1,
                     Position = 0
                }
            };

            //Act
            var actual = calculate.HighestResult(raceResults);

            //Assert
            Assert.Equal(expected, actual);
        }

    }
}
