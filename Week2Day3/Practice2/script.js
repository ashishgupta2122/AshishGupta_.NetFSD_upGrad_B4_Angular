const toggleBtn = document.getElementById("toggleBtn");
const body = document.body;

function applyTheme(theme) {
    body.classList.remove("light", "dark");
    body.classList.add(theme);
}


function loadTheme() {
    const savedTheme = localStorage.getItem("theme");

    if (savedTheme) {
        applyTheme(savedTheme);
    } else {
        applyTheme("light");
    }
}

function toggleTheme() {
    const currentTheme = body.classList.contains("light") ? "light" : "dark";
    const newTheme = currentTheme === "light" ? "dark" : "light";

    applyTheme(newTheme);
    localStorage.setItem("theme", newTheme);
}

toggleBtn.addEventListener("click", toggleTheme);

loadTheme();