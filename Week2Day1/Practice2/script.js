function validateName() {
    let name = document.getElementById("name").value;
    let msg = document.getElementById("nameMsg");

    if (name === "") {
        msg.innerText = "Name cannot be empty";
        msg.style.color = "red";
        return false;
    } else {
        msg.innerText = "Valid name";
        msg.style.color = "green";
        return true;
    }
}

function validateEmail() {
    let email = document.getElementById("email").value;
    let msg = document.getElementById("emailMsg");


    if (!email.includes("@")) {
        msg.innerText = "Email must contain @";
        msg.style.color = "red";
        return false;
    } else {
        msg.innerText = "Valid email";
        msg.style.color = "green";
        return true;
    }
}

function validateAge() {
    let age = document.getElementById("age").value;
    let msg = document.getElementById("ageMsg");

    if (age <= 18 || age === "") {
        msg.innerText = "Age must be greater than 18";
        msg.style.color = "red";
        return false;
    } else {
        msg.innerText = "Valid age";
        msg.style.color = "green";
        return true;
    }
}

function saveData() {
    let isNameValid = validateName();
    let isEmailValid = validateEmail();
    let isAgeValid = validateAge();

    let finalMsg = document.getElementById("finalMsg");

    if (isNameValid && isEmailValid && isAgeValid) {
        let user = {
            name: document.getElementById("name").value,
            email: document.getElementById("email").value,
            age: document.getElementById("age").value
        };

        sessionStorage.setItem("userData", JSON.stringify(user));
        finalMsg.innerText = "Data saved successfully!";
        finalMsg.style.color = "green";
    } else {
        finalMsg.innerText = "Please fix errors before submitting";
        finalMsg.style.color = "red";
    }
}