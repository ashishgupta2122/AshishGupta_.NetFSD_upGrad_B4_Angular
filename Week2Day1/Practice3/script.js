window.onload = function () {
    displayHistory();
}

function getLocation() {
    let status = document.getElementById("status");

    if (navigator.geolocation) {
        status.innerText = "Fetching Location...";
        navigator.geolocation.getCurrentPosition(successCallback, errorCallback);
    } else {
        status.innerText = "Geolocation is not supported by this browser"
    }
}


function successCallback(position) {
    let lat = position.coords.latitude;
    let lon = position.coords.longitude;

    document.getElementById("status").innerText = "Location fetched!";
    document.getElementById("latitude").innerText = "Latitude: " + lat;
    document.getElementById("longitude").innerText = "Longitude: " + lon;

    let newLocation = {
        latitude: lat,
        longitude: lon,
        time: new Date().toLocaleString()
    };

    let locations = JSON.parse(localStorage.getItem("locations")) || [];


    locations.unshift(newLocation);


    if (locations.length > 5) {
        locations = locations.slice(0, 5);
    }


    localStorage.setItem("locations", JSON.stringify(locations));


    displayHistory();
}

// ERROR CALLBACK
function errorCallback(error) {
    let status = document.getElementById("status");

    switch (error.code) {
        case error.PERMISSION_DENIED:
            status.innerText = "Permission denied by user.";
            break;
        case error.POSITION_UNAVAILABLE:
            status.innerText = "Location information unavailable.";
            break;
        case error.TIMEOUT:
            status.innerText = "Request timed out.";
            break;
        default:
            status.innerText = "An unknown error occurred.";
    }
}

// DISPLAY HISTORY
function displayHistory() {
    let historyList = document.getElementById("history");
    historyList.innerHTML = "";

    let locations = JSON.parse(localStorage.getItem("locations")) || [];

    locations.forEach(loc => {
        let li = document.createElement("li");
        li.innerText = `Lat: ${loc.latitude}, Lon: ${loc.longitude} (${loc.time})`;
        historyList.appendChild(li);
    });
}

