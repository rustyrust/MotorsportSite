console.log("Hello Drivers");

let drivers;

fetch("https://LocalHost:44374/api/Drivers")
    .then((response) => response.json())
    .then(function (data) {
        drivers = data.results;
        console.log(drivers);
        changeColour()
    }).catch(function (error) {
        console.log(error);
    });

function changeColour() {
    if (drivers) {
        document.querySelector("h1").style.color = "red";
        console.log("im in the if");
    }
};





