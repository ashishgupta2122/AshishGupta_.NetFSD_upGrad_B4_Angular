function addEvent(e) {

    e.preventDefault();

    let event = {
        id: eventId.value,
        name: eventName.value,
        category: category.value,
        date: date.value,
        time: time.value,
        url: url.value
    };

    let tx = db.transaction("events", "readwrite");

    tx.objectStore("events").add(event);

    alert("Event Added");

    displayEvents();

}

function displayEvents() {

    let container = document.getElementById("eventsList")
        || document.getElementById("eventContainer");

    if (!container) return;

    container.innerHTML = "";

    let tx = db.transaction("events", "readonly");

    tx.objectStore("events").openCursor().onsuccess = function (e) {

        let cursor = e.target.result;

        if (cursor) {

            let event = cursor.value;

            container.innerHTML += `

<div class="col-md-4">

<div class="card p-3">

<h5>${event.name}</h5>

<p><b>ID:</b> ${event.id}</p>
<p><b>Category:</b> ${event.category}</p>
<p><b>Date:</b> ${event.date}</p>
<p><b>Time:</b> ${event.time}</p>

<a href="${event.url}" target="_blank"
class="btn btn-primary mb-2">
Join Event
</a>

<button class="btn btn-danger"
onclick="deleteEvent('${event.id}')">
Delete
</button>

<button class="btn btn-success mt-2"
onclick="registerEvent('${event.id}')">
Register
</button>

</div>

</div>

`;

            cursor.continue();

        }

    }

}

function deleteEvent(id) {

    let tx = db.transaction("events", "readwrite");

    tx.objectStore("events").delete(id);

    displayEvents();

}

function registerEvent(id) {

    localStorage.setItem("eventId", id);

    window.location = "register.html";

}

function searchEvents() {

    let input = document.getElementById("searchInput").value.toLowerCase();

    let cards = document.querySelectorAll(".card");

    cards.forEach(card => {

        let text = card.innerText.toLowerCase();

        card.parentElement.style.display =
            text.includes(input) ? "block" : "none";

    });

}