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
            let circuitCountry = [];

            let yAxisiData = Math.max(Math.max.apply(Math, self.GetSelectedDriversPositions(id)), Math.max.apply(Math, self.GetTeamMateRaceResults(id)));
            let yAxisiScale = yAxisiData < 5 ? 5 : yAxisiData;

            for (let driver of self.driversRaceResults) {
                if (id == driver.driverId) {
                    circuitCountry.push(driver.trackCountry);
                }
            }

            self.chartdata = {
                labels: circuitCountry,
                datasets: [{
                    fill: false,
                    label: self.selectedDriver.driverBio.lastName + ' Positions',
                    borderColor: self.teamRaceColour(id),
                    data: self.GetSelectedDriversPositions(id),
                    pointBackgroundColor: self.dataPointColours(id),
                    pointRadius: self.dataPointRadius(id)
                },
                {
                    fill: false,
                    label: 'Teammate ' + self.GetTeammateLastName(id) + ' Positions',
                    borderColor: '#000000',
                    borderDash: [5, 5],
                    data: self.GetTeamMateRaceResults(id)
                }]
            }

            self.options = {
                responsive: true,
                maintainAspectRatio: false,
                tooltips: {
                    callbacks: {
                        afterBody: function (t, d) {
                            let toolTipInfo = [];
                            let overTakes = self.SelectedDriversOvertakes(id);
                            let leadLaps = self.SelectedDriversLeadLaps(id);
                            let champRaceNum = self.trackNumChapionshipWon(id);

                            toolTipInfo = [`Num Of Overtakes: ${overTakes[t[0].index]}`];
                            toolTipInfo.push(`Num Lead Laps: ${leadLaps[t[0].index]}`);

                            //if (champRaceNum != null) {
                            //    toolTipInfo.push('Won the Chapionship');
                            //}

                            return toolTipInfo;
                        }
                    },
                    filter: function (tooltipItem) {
                        return tooltipItem.datasetIndex === 0;
                    }
                },
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
                            max: yAxisiScale,
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
            let teamMateId = self.GetTeammateDriverId(selectedDriverId);
            let teamMatesPositions = [];

            for (let driver of self.driversRaceResults) {
                if (teamMateId == driver.driverId) {
                    teamMatesPositions.push(driver.position);
                }
            }

            return teamMatesPositions;
        },

        GetSelectedDriversPositions: function (selectedDriverId) {
            let self = this;
            let driversPositions = [];

            for (let driver of self.driversRaceResults) {
                if (selectedDriverId == driver.driverId) {
                    driversPositions.push(driver.position);
                }
            }
            console.log(self.trackNumChapionshipWon(1));
            return driversPositions;
        },

        SelectedDriversOvertakes: function (selectedDriverId) {
            let self = this;
            let driversOvertakes = [];

            for (let driver of self.driversRaceResults) {
                if (selectedDriverId == driver.driverId) {
                    driversOvertakes.push(driver.overtakes);
                }
            }

            return driversOvertakes;
        },

        SelectedDriversLeadLaps: function (selectedDriverId) {
            let self = this;
            let driversLeadLaps = [];

            for (let driver of self.driversRaceResults) {
                if (selectedDriverId == driver.driverId) {
                    driversLeadLaps.push(driver.lapsLead);
                }
            }

            return driversLeadLaps;
        },

        teamRaceColour: function (selectedDriverId) {
            let self = this;
            let raceTeamColour = null;

            for (let driver of self.drivers) {
                if (selectedDriverId == driver.driverBio.id) {
                    raceTeamColour = driver.driverBio.teamColour;
                }
            }
            return raceTeamColour;
        },

        championshipTrackWon: function (selectedDriverId) {
            let self = this;
            let isAChampion = [];

            for (let driver of self.driversRaceResults) {
                if (selectedDriverId == driver.driverId) {
                    isAChampion.push(driver.isChampion);
                }
            }
            return isAChampion;
        },

        trackNumChapionshipWon: function (selectedDriverId) {
            let self = this;
            let isAChampion = self.championshipTrackWon(selectedDriverId);
            let counter = 0;

            if (isAChampion.includes(true)) {
                for (const input of isAChampion) {
                    if (input == true) {
                        return counter + 1;
                    }
                    counter += 1;
                }
            }
            return counter;
        },

        dataPointColours: function (selectedDriverId) {
            let self = this;
            let champData = self.championshipTrackWon(selectedDriverId);
            let colours = [];

            for (let data of champData) {
                if (data == true) {
                    colours.push('gold');
                }
                else {
                    colours.push(self.teamRaceColour(selectedDriverId));
                }
            }
            return colours;
        },

        dataPointRadius: function (selectedDriverId) {
            let self = this;
            let champData = self.championshipTrackWon(selectedDriverId);
            let radius = [];

            for (let data of champData) {
                if (data == true) {
                    radius.push(8);
                }
                else {
                    radius.push(4);
                }
            }
            return radius;
        },

        GetTeammateDriverId: function (selectedDriverId) {
            let self = this;
            let selectedDriversTeam = null;
            let teamsDrivers = [];
            let teamMateId = null;

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
            return teamMateId;
        },

        GetTeammateLastName: function (selectedDriverId) {
            let self = this;
            let teammateId = self.GetTeammateDriverId(selectedDriverId);
            let teamateLastName = null;

            for (let driver of self.drivers) {
                if (teammateId == driver.driverBio.id) {
                    teamateLastName = driver.driverBio.lastName;
                }
            }
            return teamateLastName;
        }




    }


})



