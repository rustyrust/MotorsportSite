new Vue({
    el: '#drivers-vueapp',
    data: {
        drivers: null,
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
    methods: {
        closeDriverDetails: function (id) {
            let self = this;
            for (let driver of self.drivers) {
                if (id === driver.id) {
                    driver.isVisable = !driver.isVisable;
                }
                else {
                    driver.isVisable = false;
                }

            }
        }

    }


})



