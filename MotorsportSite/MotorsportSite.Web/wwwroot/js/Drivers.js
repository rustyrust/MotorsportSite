new Vue({
    el: '#drivers-vueapp',
    data: {
        driverBio: null,
        careerStats: null,
        currentSeasonStats: null,
        driverid: null,
        selectedDriver: null,
        currentSeason: null,
        selectedDriverSeasonStats: null,
        drivers: null,
        driversChamp: null,
        selectedDriverChamp: null,
        driversRaceResults: null,
        chartdata: null,
        options: null
    },

    mounted:

        function () {
            let self = this;
            let date = new Date();
            self.currentSeason = date.getFullYear();

            fetch('https://LocalHost:44374/api/Drivers/FullInformation/2020')
                .then((response) => response.json())
                .then(function (data) {
                    self.drivers = data;
                    self.toggleDriverDetails(self.drivers[0].driverBio.id);

                }).catch(function (error) {
                    console.log(error);
                });

            fetch('https://LocalHost:44374/api/Drivers/Championships')
                .then((response) => response.json())
                .then(function (data) {
                    self.driversChamp = data;

                }).catch(function (error) {
                    console.log(error);
                });

            fetch('https://LocalHost:44374/api/Drivers/2019/RaceResults')
                .then((response) => response.json())
                .then(function (data) {
                    self.driversRaceResults = data;

                }).catch(function (error) {
                    console.log(error);
                });

            window.setTimeout(function () {
                $('[data-toggle="tooltip"]').tooltip();
            }, 500);
        },

    computed: {


    },

    methods: {
        toggleDriverDetails: function (id) {
            let self = this;
            for (let driver of self.drivers) {
                if (id === driver.driverBio.id) {
                    self.selectedDriver = driver;
                }
            }
            self.filterDriverChamp();
            self.selectedDriverChartData(id);
        },

        selectedDriverChartData: function (id) {
            let self = this;
            let driversPositions = [];
            let circuitCountry = [];
            let raceTeamColour = null;

            let numDrivers = self.drivers.length;

            for (let driver of self.driversRaceResults) {
                if (id == driver.driverId) {
                    driversPositions.push(driver.position);
                }
            }

            for (let driver of self.driversRaceResults) {
                if (id == driver.driverId) {
                    circuitCountry.push(driver.trackCountry);
                }
            }

            for (let driver of self.drivers) {
                if (id == driver.driverBio.id) {
                    raceTeamColour = driver.driverBio.teamColour;
                }
            }

            self.chartdata = {
                labels: circuitCountry,
                datasets: [{
                    fill: false,
                    label: 'selected Diver Positions',
                    borderColor: raceTeamColour,
                    data: driversPositions
                },
                {
                    fill: false,
                    label: 'Teammate Positions',
                    borderColor: '#000000',
                    borderDash: [5, 5],
                    data: self.GetTeamMateRaceResults(id)
                }]
            }

            self.options = {
                responsive: true,
                maintainAspectRatio: false,
                //tooltips: {
                //    callbacks: {
                //        afterBody: function (t, d) {
                //            return 'some stuff here'; //return a string that you wish to append
                //        }
                //    }
                //},
                scales: {
                    xAxes: [{
                        display: true,
                        scaleLabel: {
                            display: true,
                            labelString: 'Grand Prix'
                        }
                    }],
                    yAxes: [{
                        display: true,
                        scaleLabel: {
                            display: true,
                            labelString: 'Positions'
                        },
                        ticks: {
                            beginAtZero: false,
                            reverse: true,
                            stepsSize: 1,
                            fixedStepSize: 1,
                            max: numDrivers,
                            min: 1
                        }
                    }]
                }
            }
        },

        filterDriverChamp: function () {
            let self = this;
            self.selectedDriverChamp = 0;

            for (let driver of self.driversChamp) {
                if (self.selectedDriver.driverBio.id === driver.driverId) {
                    self.selectedDriverChamp = driver;
                }
            }
        },

        GetTeamMateRaceResults: function (selectedDriverId) {
            let self = this;
            let selectedDriversTeam = null;
            let teamsDrivers = [];
            let teamMateId = null;
            let teamMatesPositions = [];

            for (let driver of self.drivers) {
                if (selectedDriverId == driver.driverBio.id) {
                    selectedDriversTeam = driver.driverBio.teamName;
                }
            }

            for (let driver of self.drivers) {
                if (selectedDriversTeam == driver.driverBio.teamName) {
                    teamsDrivers.push(driver.driverBio.id);
                }
            }

            for (let driverId of teamsDrivers) {
                if (driverId != selectedDriverId) {
                    teamMateId = driverId;
                }
            }

            for (let driver of self.driversRaceResults) {
                if (teamMateId == driver.driverId) {
                    teamMatesPositions.push(driver.position);
                }
            }

            return teamMatesPositions;
        }

    }


})



