console.log("Hello Drivers");

let drivers;

fetch("https://randomuser.me/api/?results=10")
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




