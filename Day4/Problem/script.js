function calculateAge() {
    const dobInput = document.getElementById("dob").value;
    const error = document.getElementById("error");
    const result = document.getElementById("result");

    error.innerText = "";
    result.innerText = "";

    if (!dobInput) {
        error.innerText = "Date of Birth is required and should not be a future date.";
        return;
    }

    const dob = new Date(dobInput);
    const today = new Date();

    if (dob > today) {
        error.innerText = "Date of Birth should not be a future date.";
        return;
    }

    let age = today.getFullYear() - dob.getFullYear();
    const monthDiff = today.getMonth() - dob.getMonth();

    if (monthDiff < 0 || (monthDiff === 0 && today.getDate() < dob.getDate())) {
        age--;
    }

    result.innerText = `Show Alert: You have completed ${age} years`;

    // Optional alert (like your screenshot)
    alert(`You have completed ${age} years`);
}
