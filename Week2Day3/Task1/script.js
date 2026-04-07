function addTask() {
    let input = document.getElementById("taskInput");
    let taskValue = input.value.trim();

    if (taskValue === "") {
        alert("Please enter a task");
        return;
    }

    let table = document.getElementById("taskTable");

    let row = document.createElement("tr");


    let taskCell = document.createElement("td");
    taskCell.innerText = taskValue;


    let actionCell = document.createElement("td");
    let deleteBtn = document.createElement("button");
    deleteBtn.innerText = "Delete";

    deleteBtn.onclick = function () {
        row.remove();
    };

    actionCell.appendChild(deleteBtn);

    row.appendChild(taskCell);
    row.appendChild(actionCell);

    table.appendChild(row);

    input.value = "";
}

async function name(params) {
    const api = ur
}
