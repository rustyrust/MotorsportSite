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
        driversCurrentSeasonVsLast: null,

        chartdata: null,
        options: null,
        LineChartCurrentVsLastSeaonData: null,
        LineChartCurrentVsLastSeaonOptions: null,
        piechartdata: null,
        pieoptions: null,

        lineChartShow: false,
        pieChartShow: false,
        vsLastSeaonShow: true
    },

    mounted:

        function () {
            let self = this;
            let date = new Date();
            self.currentSeason = date.getFullYear();

            let promise1 = fetch('https://LocalHost:44374/api/Drivers/FullInformation/2020')
                .then((response) => response.json())
                .then(function (data) {
                    self.drivers = data;
                    

                }).catch(function (error) {
                    console.log(error);
                });

            let promise2 = fetch('https://LocalHost:44374/api/Drivers/Championships')
                .then((response) => response.json())
                .then(function (data) {
                    self.driversChamp = data;

                }).catch(function (error) {
                    console.log(error);
                });

            let promise3 = fetch('https://LocalHost:44374/api/Drivers/2019/RaceResults')
                .then((response) => response.json())
                .then(function (data) {
                    self.driversRaceResults = data;

                }).catch(function (error) {
                    console.log(error);
                });

            let promise4 = fetch('https://LocalHost:44374/api/Drivers/2020/CurrentSeasonVsPreviousSeason')
                .then((response) => response.json())
                .then(function (data) {
                    self.driversCurrentSeasonVsLast= data;

                }).catch(function (error) {
                    console.log(error);
                });

            Promise.all([promise1, promise2, promise3, promise4])
                .then(function () {
                    self.toggleDriverDetails(self.drivers[0].driverBio.id);
                    console.log(self.drivers);
                    console.log(self.driversChamp);
                    console.log(self.driversRaceResults);
                    console.log(self.driversCurrentSeasonVsLast);
                }
                );

            window.setTimeout(function () {
                $('[data-toggle="tooltip"]').tooltip();
            }, 500);
        },

    computed: {

        showLineChart: function () {
            lineChartShow = true;
            pieChartShow = false;
        },

        showPieChart: function () {
            lineChartShow = false;
            pieChartShow = true;
        }

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
            self.selectedDriverLineChartLastSeasonVsTeamMate(id);
            self.selectedDriverLineChartCurrentSeaonVsLastSeaon(id);
            self.selectedDriverPieChartCurrentSeasonTopPlacesVsAllDrivers(id);
        },

        selectedDriverLineChartLastSeasonVsTeamMate: function (id) {
            let self = this;
            let circuitCountry = [];
            let selectedDriverData = [];

            let yAxisiData = Math.max(Math.max.apply(Math, self.GetSelectedDriversPositions(id, self.driversRaceResults)), Math.max.apply(Math, self.GetTeamMateRaceResults(id)));
            let yAxisiScale = yAxisiData < 5 ? 5 : yAxisiData;

            for (let driver of self.driversRaceResults) {
                if (id == driver.driverId) {
                    circuitCountry.push(driver.trackCountry);
                }
            }

            for (let driver of self.GetSelectedDriversPositions(id, self.driversRaceResults)) {
                if (driver == 0) {
                    selectedDriverData.push(NaN);
                }
                selectedDriverData.push(driver);
            }

            self.chartdata = {
                labels: circuitCountry,
                datasets: [{
                    fill: false,
                    label: self.selectedDriver.driverBio.lastName + ' Positions',
                    borderColor: self.teamRaceColour(id),
                    data: selectedDriverData,
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

        selectedDriverLineChartCurrentSeaonVsLastSeaon: function (id) {
            let self = this;
            let circuitCountry = [];
            let selectedDriverData = [];

            let yAxisiData = Math.max(Math.max.apply(Math, self.GetRacePositions(id, self.driversCurrentSeasonVsLast, 2019)), Math.max.apply(Math, self.GetTeamMateRaceResults(id)));
            let yAxisiScale = yAxisiData < 5 ? 5 : yAxisiData;

            for (let driver of self.driversCurrentSeasonVsLast) {
                if (id == driver.driverId) {
                    circuitCountry.push(driver.trackCountry);
                }
            }

            //for (let driver of self.GetRacePositions(id, self.driversCurrentSeasonVsLast, 2020)) {
            //    if (driver == 0) {
            //        selectedDriverData.push(NaN);
            //    }
            //    selectedDriverData.push(driver);
            //}

            self.LineChartCurrentVsLastSeaonData = {
                labels: self.GetCountryNames(id, self.driversCurrentSeasonVsLast, 2019),
                datasets: [{
                    fill: false,
                    label: 'Race Positions',
                    borderColor: self.teamRaceColour(id),
                    data: self.GetRacePositions(id, self.driversCurrentSeasonVsLast, 2020)
                },
                //{
                //    fill: false,
                //    label: 'Qualifing Positions',
                //    borderColor: self.teamRaceColour(id),
                //    borderDash: [5, 5],
                //    data: 4
                //},
                {
                    fill: false,
                    label: '2019 Race Positions',
                    borderColor: '#000000',
                    data: self.GetRacePositions(id, self.driversCurrentSeasonVsLast, 2019)
                }]
                //{
                //    fill: false,
                //    label: '2019 Qualifing Positions',
                //    borderColor: '#000000',
                //    borderDash: [5, 5],
                //    data: 8
                //}]
            }

            self.LineChartCurrentVsLastSeaonOptions = {
                responsive: true,
                maintainAspectRatio: false,
                //tooltips: {
                //    callbacks: {
                //        afterBody: function (t, d) {
                //            let toolTipInfo = [];
                //            let overTakes = self.SelectedDriversOvertakes(id);
                //            let leadLaps = self.SelectedDriversLeadLaps(id);
                //            let champRaceNum = self.trackNumChapionshipWon(id);

                //            toolTipInfo = [`Num Of Overtakes: ${overTakes[t[0].index]}`];
                //            toolTipInfo.push(`Num Lead Laps: ${leadLaps[t[0].index]}`);

                //            //if (champRaceNum != null) {
                //            //    toolTipInfo.push('Won the Chapionship');
                //            //}

                //            return toolTipInfo;
                //        }
                //    },
                //    filter: function (tooltipItem) {
                //        return tooltipItem.datasetIndex === 0;
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
                            max: yAxisiScale,
                            min: 1
                        }
                    }]
                }
            }
        },

        selectedDriverPieChartCurrentSeasonTopPlacesVsAllDrivers: function (id) {
            let self = this;
            let pieData = [];
            let dataLables = [];
            let dataColours = [];

            for (let driver of self.driversRaceResults) {
                if (driver.position <= 3 && driver.position != 0) {
                    pieData.push(driver.driverId)
                };
            }

            const data = pieData.reduce((total, value) => {
                total[value] = (total[value] || 0) + 1;
                return total;
            }, {});

            for (let d in data) {
                dataLables.push(self.GetDriverShortName(d));
            }

            for (let d in data) {
                dataColours.push(self.teamRaceColour(d));
            }

            self.piechartdata = {
                labels: dataLables,
                datasets: [{
                    borderWidth: 1,
                    borderColor: 'White',
                    backgroundColor: dataColours,
                    data: Object.values(data)
                }]
            }

            self.pieoptions = {
                legend: {
                    display: true
                },
                responsive: true,
                maintainAspectRatio: false
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

        GetSelectedDriversPositions: function (selectedDriverId, data) {
            let self = this;
            let driversPositions = [];

            for (let driver of data) {
                if (selectedDriverId == driver.driverId) {
                    driversPositions.push(driver.position);
                }
            }
            return driversPositions;
        },

        GetRacePositions: function (selectedDriverId, data, season) {
            let self = this;
            let driversPositions = [];

            for (let driver of data) {
                let startDate = new Date(driver.startDate);
                if (selectedDriverId == driver.driverId && startDate.getFullYear() == season) {
                    driversPositions.push(driver.position);
                }
            }
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
            let result = isAChampion.indexOf(true) === -1 ? 0 : isAChampion.indexOf(true);

            return result;
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
        },

        GetDriverShortName: function (driverId) {
            let self = this;

            for (let driver of self.drivers) {
                if (driverId == driver.driverBio.id) {
                    return driver.driverBio.shortName;
                }
            }
        },

        GetCountryNames: function (selectedDriverId, data, season) {
            let self = this;
            let circuits = [];

            for (let driver of data) {
                let startDate = new Date(driver.startDate);
                if (selectedDriverId == driver.driverId && startDate.getFullYear() == season) {
                    circuits.push(driver.trackCountry);
                }
            }
            return circuits;
        },

        showVsLastSeaon: function () {
            let self = this;
            self.vsLastSeaonShow = true;
            self.lineChartShow = false;
            self.pieChartShow = false;
        },

        showPodiums: function () {
            let self = this;
            self.lineChartShow = false;
            self.pieChartShow = true;
            self.vsLastSeaonShow = false;
        },

        showVsTeammate: function () {
            let self = this;
            self.lineChartShow = true;
            self.pieChartShow = false;
            self.vsLastSeaonShow = false;
        }

    }


})



