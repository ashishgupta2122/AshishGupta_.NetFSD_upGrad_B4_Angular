$(document).ready(function () {

    $("#feedbackForm").submit(function (event) {
        event.preventDefault();

        let name = $("#name").val().trim();
        let email = $("#email").val().trim();

        // Validation
        if (name === "" || email === "") {
            $("#msg")
                .removeClass("success")
                .addClass("error")
                .text("Please fill in Name and Email.");
        } else {
            $("#msg")
                .removeClass("error")
                .addClass("success")
                .text("Feedback submitted successfully!");

            $("#feedbackForm")[0].reset();
        }
    });

});