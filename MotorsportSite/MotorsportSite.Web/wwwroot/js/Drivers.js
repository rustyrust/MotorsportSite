new Vue({
    el: '#drivers-vueapp',
    data: {
        drivers: null,
        activeDetails: false,
        info: [],
        driverid: null
    },
    mounted:

        function () {
        let self = this;
            fetch('https://LocalHost:44374/api/Drivers/Information')
            .then((response) => response.json())
            .then(function (data) {
                self.drivers = data;
            }).catch(function (error) {
                console.log(error);
            });
    },
    methods:{
        driverInfo: function (driverid) {
            let self = this;
            for (let driver in self.drivers) {
                if (driver.id === driverid) {
                    info = [driver.driverNumber, driver.country]
                }
            }
            return info;
        }
    }


})



