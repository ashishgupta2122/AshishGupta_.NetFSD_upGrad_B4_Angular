let user = {
    name: "Ashish",
    age: 22,
    city: "Mumbai"
};

function handleDispley() {
    displayUserInfo(user)
}

function displayUserInfo(userObj) {
    document.getElementById("name").innerText = "Name: " + userObj.name;
    document.getElementById("age").innerText = "Age: " + userObj.age;
    document.getElementById("city").innerText = "City: " + userObj.city;
}