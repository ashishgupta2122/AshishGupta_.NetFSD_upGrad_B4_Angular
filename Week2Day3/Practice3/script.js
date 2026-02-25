const input = document.getElementById("taskInput");
const addBtn = document.getElementById("addBtn");
const taskList = document.getElementById("taskList");

function addTask() {
    const taskText = input.value.trim();

    if (taskText === "") return;

    const li = document.createElement("li");

    li.innerHTML = `
        <span class="task-text">${taskText}</span>
        <button class="delete-btn">Delete</button>
    `;

    taskList.appendChild(li);
    input.value = "";
}


addBtn.addEventListener("click", addTask);

taskList.addEventListener("click", function (e) {


    if (e.target.classList.contains("delete-btn")) {
        e.target.parentElement.remove();
    }


    if (e.target.classList.contains("task-text")) {
        e.target.classList.toggle("completed");
    }
});