let events = ["Hackathon", "College Contest", "Tech Fest"];

let eventList = document.getElementById("eventList");

for (let i = 0; i < events.length; i++) {
    let li = document.createElement("li");
    li.textContent = events[i];
    eventList.appendChild(li);
}

function validateForm() {
    let name = document.getElementById("name").value;

    if (name === "") {
        alert("Name is required.");
        return false;
    }

    localStorage.setItem("userName", name);
    alert("Registration successful");
    return true;
}

let inputs = document.querySelectorAll("input");

inputs.forEach(input => {
    input.onchange = () => {
        let filled = 0;
        inputs.forEach(i => {
            if (i.value !== "") {
                filled++;
            }
        });
        document.getElementById("filledCount").textContent = filled;
    }
})

function getLocation() {
    navigator.geolocation.getCurrentPosition(
        (pos) => {
            document.getElementById("location").innerText =
                "Lat: " + pos.coords.latitude +
                " , Lon: " + pos.coords.longitude;
        },
        () => {
            alert("Permission denied");
        }
    );
}