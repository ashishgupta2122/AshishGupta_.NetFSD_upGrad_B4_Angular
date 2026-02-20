var count = 0;

function incrementCounter(step) {
    count = count + step;

    document.getElementById("counter").innerText = count;
}

function resetCounter() {
    count = 0;

    document.getElementById("counter").innerText = count;
}

document.getElementById("incrementBtn").addEventListener("click", function () {
    incrementCounter(1);
})

document.getElementById("resetBtn").addEventListener("click", function () {
    resetCounter();
})