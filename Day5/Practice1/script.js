function generateGreeting() {
    let name = document.getElementById("nameInput").value;
    showGreeting(name);
}

function showGreeting(userName) {
    let message = "Hello, " + userName + "! Welcome to our website.";
    document.getElementById("greetingMessage").innerText = message;
}



