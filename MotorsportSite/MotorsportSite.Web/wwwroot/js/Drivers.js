console.log('Hello Drivers');


let driverData;

fetch('https://LocalHost:44374/api/Drivers')
    .then((response) => response.json())
    .then(function (data) {
        driverData = data;
        console.log(driverData);
    }).catch(function (error) {
        console.log(error);
    });



let drivers = new Vue({
    el: '#drivers',
    data: {
        driverNames: ['Hamilton', 'Vettel', 'Norris']
    }
})



