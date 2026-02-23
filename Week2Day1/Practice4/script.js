let db;


let request = indexedDB.open("ExpenseDB", 1);


request.onupgradeneeded = function (event) {
    db = event.target.result;
    let store = db.createObjectStore("expenses", { keyPath: "id", autoIncrement: true });
    store.createIndex("title", "title", { unique: false });
};


request.onsuccess = function (event) {
    db = event.target.result;
};


request.onerror = function () {
    console.log("Database error");
};


function addExpense() {
    let title = document.getElementById("title").value;
    let amount = document.getElementById("amount").value;
    let date = document.getElementById("date").value;

    let transaction = db.transaction(["expenses"], "readwrite");

    transaction.onerror = function () {
        alert("Transaction failed!");
    };

    let store = transaction.objectStore("expenses");

    let expense = {
        title: title,
        amount: amount,
        date: date
    };

    let req = store.add(expense);

    req.onerror = function () {
        alert("Error adding expense");
    };

    req.onsuccess = function () {
        alert("Expense added!");
    };
}

function viewExpenses() {
    let list = document.getElementById("expenseList");
    list.innerHTML = "";

    let transaction = db.transaction(["expenses"], "readonly");

    let store = transaction.objectStore("expenses");

    let request = store.openCursor();

    request.onsuccess = function (event) {
        let cursor = event.target.result;

        if (cursor) {
            let li = document.createElement("li");
            li.innerHTML = `
                ${cursor.value.title} - ₹${cursor.value.amount} - ${cursor.value.date}
                <button onclick="deleteExpense(${cursor.value.id})">Delete</button>
            `;
            list.appendChild(li);
            cursor.continue();
        }
    };

    request.onerror = function () {
        alert("Error fetching data");
    };
}


function deleteExpense(id) {
    let transaction = db.transaction(["expenses"], "readwrite");

    let store = transaction.objectStore("expenses");

    let req = store.delete(id);

    req.onsuccess = function () {
        alert("Deleted!");
        viewExpenses();
    };

    req.onerror = function () {
        alert("Delete failed");
    };
}