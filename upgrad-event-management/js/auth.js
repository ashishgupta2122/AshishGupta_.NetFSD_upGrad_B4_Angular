loginForm?.addEventListener("submit", function (e) {

    e.preventDefault();

    if (email.value == "admin@upgrad.com"
        && password.value == "12345") {

        sessionStorage.setItem("admin", true);

        window.location = "events.html";

    } else {

        alert("Invalid Login");

    }

});

function logout() {

    sessionStorage.removeItem("admin");

    window.location = "login.html";

}