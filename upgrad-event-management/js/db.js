let db;

let request = indexedDB.open("eventDB", 1);

request.onupgradeneeded = function (e) {

    db = e.target.result;

    db.createObjectStore("events", { keyPath: "id" });

}

request.onsuccess = function (e) {

    db = e.target.result;

    displayEvents();

}