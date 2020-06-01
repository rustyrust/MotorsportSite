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
        drivers: null
    },
    mounted:

        function () {
            let self = this;
            let date = new Date();
            self.currentSeason = date.getFullYear();

            fetch('https://LocalHost:44374/api/Drivers/Bio')
                .then((response) => response.json())
                .then(function (data) {
                    self.driverBio = data;
                }).catch(function (error) {
                    console.log(error);
                });

            fetch('https://LocalHost:44374/api/Drivers/CareerStats')
                .then((response) => response.json())
                .then(function (data) {
                    self.careerStats = data;
                    //self.selectedDriver = self.careerStats[0];

                }).catch(function (error) {
                    console.log(error);
                });

            fetch('https://LocalHost:44374/api/Drivers/SeasonStats/2019')
                .then((response) => response.json())
                .then(function (data) {
                    self.currentSeasonStats = data;
                }).catch(function (error) {
                    console.log(error);
                });

            window.setTimeout(function () {
                $('[data-toggle="tooltip"]').tooltip();
            }, 500);
        },

    methods: {
        toggleDriverDetails: function (id) {
            let self = this;
            for (let driver of self.drivers) {
                if (id === driver.id) {
                    self.selectedDriver = driver;
                }
            }
            for (let driver of self.seasonStats) {
                if (id === driver.id) {
                    self.selectedDriverSeasonStats = driver;
                }
            }
        }

    }


})



