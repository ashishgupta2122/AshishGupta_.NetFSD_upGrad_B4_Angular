$(document).ready(function () {

    let total = 0;
    let completed = 0;

    // Add Task
    $("#add-btn").click(function () {

        let taskText = $("#task-input").val().trim();

        if (taskText === "") return;

        // Create task element
        let task = `
            <li>
                <span class="task-text">${taskText}</span>
                <button class="delete-btn">Delete</button>
            </li>
        `;

        // Append task
        $("#task-list").append(task);

        // Update count
        total++;
        $("#total").text(total);

        // Clear input
        $("#task-input").val("");
    });

    // Mark as complete (Event Delegation)
    $("#task-list").on("click", ".task-text", function () {

        $(this).toggleClass("completed");

        if ($(this).hasClass("completed")) {
            completed++;
        } else {
            completed--;
        }

        $("#completed").text(completed);
    });

    // Delete Task (Event Delegation)
    $("#task-list").on("click", ".delete-btn", function () {

        let isCompleted = $(this).siblings(".task-text").hasClass("completed");

        if (isCompleted) {
            completed--;
            $("#completed").text(completed);
        }

        // Remove task
        $(this).parent().remove();

        // Update total
        total--;
        $("#total").text(total);
    });

});