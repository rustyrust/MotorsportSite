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
                     Position = 1,
                     LapsCompleted = 71
                },
                new RaceResults
                {
                     DriverId = 1,
                     Position = 4,
                     LapsCompleted = 71
                },
                new RaceResults
                {
                     DriverId = 1,
                     Position = 2,
                     LapsCompleted = 71
                },
                new RaceResults
                {
                     DriverId = 1,
                     Position = 10,
                     LapsCompleted = 71,
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
                     Position = 13,
                     LapsCompleted = 71
                },
                new RaceResults
                {
                     DriverId = 1,
                     Position = 14,
                     LapsCompleted = 71
                },
                new RaceResults
                {
                     DriverId = 1,
                     Position = 12,
                     LapsCompleted = 71
                },
                new RaceResults
                {
                     DriverId = 1,
                     Position = 10,
                     LapsCompleted = 71
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
                     Position = 0,
                     LapsCompleted = 11
                },
                new RaceResults
                {
                     DriverId = 1,
                     Position = 0,
                     LapsCompleted = 11
                },
                new RaceResults
                {
                     DriverId = 1,
                     Position = 1,
                     LapsCompleted = 11
                },
                new RaceResults
                {
                     DriverId = 1,
                     Position = 2,
                     LapsCompleted = 11
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

        [Fact]
        public void HighestResult_FirstRaceOfSeasonDNF()
        {
            Calculate calculate = new Calculate();

            //Arange
            var expected = 0;

            List<RaceResults> raceResults = new List<RaceResults>
            {
                new RaceResults
                {
                     DriverId = 1,
                     Position = 0,
                     LapsCompleted = 11

                }
            };

            //Act
            var actual = calculate.HighestResult(raceResults);

            //Assert
            Assert.Equal(expected, actual);
        }

    }
}
