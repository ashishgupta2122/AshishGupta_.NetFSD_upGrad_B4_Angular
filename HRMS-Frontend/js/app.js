let employees = JSON.parse(localStorage.getItem("employees")) || [];

const container = document.getElementById("employeeContainer");

function displayEmployees(list) {

    if (!container) return;

    container.innerHTML = "";

    list.forEach((emp, index) => {

        let card = document.createElement("div");
        card.className = "card";

        card.innerHTML = `

<h3>${emp.firstName} ${emp.lastName}</h3>

<p>Department: ${emp.department}</p>
<p>DOJ: ${emp.doj}</p>

<button onclick="viewEmployee(${index})">View</button>
<button onclick="deleteEmployee(${index})">Delete</button>

`;

        container.appendChild(card);

    });

}

displayEmployees(employees);

function viewEmployee(i) {

    let emp = employees[i];

    alert(
        `Name: ${emp.firstName} ${emp.lastName}
Department: ${emp.department}
Email: ${emp.personalEmail}
Mobile: ${emp.mobile}
Skills: ${emp.skills}`
    );

}

function deleteEmployee(i) {

    employees.splice(i, 1);

    localStorage.setItem("employees", JSON.stringify(employees));

    displayEmployees(employees);

}


const form = document.getElementById("employeeForm");

if (form) {

    form.addEventListener("submit", (e) => {

        e.preventDefault();

        let emp = {

            id: Date.now(),

            firstName: document.getElementById("firstName").value,
            lastName: document.getElementById("lastName").value,
            dob: document.getElementById("dob").value,
            gender: document.getElementById("gender").value,
            personalEmail: document.getElementById("personalEmail").value,
            mobile: document.getElementById("mobile").value,

            street: document.getElementById("street").value,
            city: document.getElementById("city").value,
            state: document.getElementById("state").value,
            country: document.getElementById("country").value,
            zip: document.getElementById("zip").value,

            doj: document.getElementById("doj").value,
            officeEmail: document.getElementById("officeEmail").value,
            department: document.getElementById("department").value,

            skills: document.getElementById("skills").value,

            isActive: document.getElementById("isActive").checked

        };

        employees.push(emp);

        localStorage.setItem("employees", JSON.stringify(employees));

        window.location.href = "EmployeeList.html";

    });

}

const searchInput = document.getElementById("searchInput");

if (searchInput) {

    searchInput.addEventListener("keyup", () => {

        let value = searchInput.value.toLowerCase();

        let filtered = employees.filter(e =>

            e.firstName.toLowerCase().includes(value) ||
            e.lastName.toLowerCase().includes(value) ||
            e.department.toLowerCase().includes(value)

        );

        displayEmployees(filtered);

    });

}

const sortSelect = document.getElementById("sortSelect");

if (sortSelect) {

    sortSelect.addEventListener("change", () => {

        let val = sortSelect.value;

        employees.sort((a, b) => a[val].localeCompare(b[val]));

        displayEmployees(employees);

    });

}