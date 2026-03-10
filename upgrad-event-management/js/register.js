window.onload = function () {

    let id = localStorage.getItem("eventId");

    let tx = db.transaction("events", "readonly");

    let request = tx.objectStore("events").get(id);

    request.onsuccess = function () {

        let event = request.result;

        eventDetails.innerHTML = `

<h5>${event.name}</h5>

<p>ID: ${event.id}</p>
<p>Category: ${event.category}</p>
<p>Date: ${event.date}</p>
<p>Time: ${event.time}</p>

`;

    }

}

registerForm.addEventListener("submit", function (e) {

    e.preventDefault();

    alert("You are successfully registered to this event!");

});