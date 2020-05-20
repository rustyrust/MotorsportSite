new Vue({
    el: '#drivers-vueapp',
    data: {
        driverBio: null,
        drivers: null,
        seasonStats: null,
        driverid: null,
        selectedDriver: null,
        currentSeason: null,
        selectedDriverSeasonStats: null
    },
    mounted:

        function () {
            let self = this;

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
                    self.drivers = data;
                    self.selectedDriver = self.drivers[0];

                    let date = new Date();
                    self.currentSeason = date.getFullYear();

                }).catch(function (error) {
                    console.log(error);
                });

            fetch('https://LocalHost:44374/api/Drivers/SeasonStats/2019')
                .then((response) => response.json())
                .then(function (data) {
                    self.seasonStats = data;
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



