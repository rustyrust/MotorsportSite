new Vue({
    el: '#drivers-vueapp',
    data: {
        drivers: null,
        driverid: null,
        selectedDriver: null
    },
    mounted:

        function () {
            let self = this;
            fetch('https://LocalHost:44374/api/Drivers/Information')
                .then((response) => response.json())
                .then(function (data) {
                    self.drivers = data;
                    self.selectedDriver = self.drivers[0];
                }).catch(function (error) {
                    console.log(error);
                });
        },
    methods: {
        toggleDriverDetails: function (id) {
            let self = this;
            for (let driver of self.drivers) {
                if (id === driver.id) {
                    self.selectedDriver = driver;
                }
            }
        }

    }


})



