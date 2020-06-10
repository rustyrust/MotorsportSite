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
        chartdata: {
            labels: ['Austraila', 'Barhain', 'Japan', 'England', 'France', 'Italy', 'Duabi'],
            datasets: [{
                label: 'Positions',
                backgroundColor: '#f87979',
                data: [1, 3, 2, 4, 1, 1, 2]
            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            scales: {
                xAxes: [{
                    display: true,
                    scaleLabel: {
                        display: true,
                        labelString: 'Race Circuit'
                    }
                }],
                yAxes: [{
                    display: true,
                    ticks: {
                        beginAtZero: false,
                        reverse: true
                    }
                }]
            }
        }
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
            //self.chartdata = 0;
            let driversPositions = [];

            for (let driver of self.driversRaceResults) {
                if (id == driver.driverId) {
                    driversPositions.push(driver.position);
                }
            }

            self.chartdata = {
                labels: ['Austraila', 'Barhain', 'Japan', 'England', 'France', 'Italy', 'Duabi'],
                datasets: [{
                    label: 'Positions',
                    backgroundColor: '#f87979',
                    data: driversPositions
                }]
            }

            //self.options = {
            //    responsive: true,
            //        maintainAspectRatio: false
            //}

            console.log(self.chartdata);

        },

        filterDriverChamp: function () {
            let self = this;
            self.selectedDriverChamp = 0;

            for (let driver of self.driversChamp) {
                if (self.selectedDriver.driverBio.id === driver.driverId) {
                    self.selectedDriverChamp = driver;
                }
            }
        }


    }


})



