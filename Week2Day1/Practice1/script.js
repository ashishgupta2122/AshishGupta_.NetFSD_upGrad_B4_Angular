window.onload = function () {
    let savedNote = localStorage.getItem("myNote");
    if (savedNote !== null) {
        document.getElementById("noteArea").value = savedNote;
    }
};


function saveNote() {
    let note = document.getElementById("noteArea").value;
    localStorage.setItem("myNote", note);
    alert("Note saved successfully!");
}

function clearNote() {
    document.getElementById("noteArea").value = "";
    localStorage.removeItem("myNote");
    alert("Note cleared!");
}