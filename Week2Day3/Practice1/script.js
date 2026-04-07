const button = document.getElementById("feedbackBtn");
const message = document.getElementById("message");

button.addEventListener("click", function () {
    message.textContent = "Feedback Submited Successfully";
});