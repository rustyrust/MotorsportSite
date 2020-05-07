new Vue({
    el: '#drivers-vueapp',
    data: {
        drivers: null,
        activeDetails: false
    },
    mounted:

        function () {
        let self = this;
        fetch('https://LocalHost:44374/api/Drivers')
            .then((response) => response.json())
            .then(function (data) {
                self.drivers = data;
            }).catch(function (error) {
                console.log(error);
            });
    },
    methods:{

    }


})



