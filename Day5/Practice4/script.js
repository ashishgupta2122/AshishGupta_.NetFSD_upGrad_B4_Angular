
var student = {
    name: "Rahul",
    rollNo: 101,
    marks: 75
};


function updateStudentProfile(studentObj) {

    var content =
        "<p><strong>Name:</strong> " + studentObj.name + "</p>" +
        "<p><strong>Roll No:</strong> " + studentObj.rollNo + "</p>" +
        "<p><strong>Marks:</strong> " + studentObj.marks + "</p>";

    document.getElementById("profileCard").innerHTML = content;
}


function updateMarks(newMarks) {


    student.marks = newMarks;


    updateStudentProfile(student);
}


document.getElementById("showProfileBtn").addEventListener("click", function () {
    updateStudentProfile(student);
});

document.getElementById("updateMarksBtn").addEventListener("click", function () {

    var newMarksValue = document.getElementById("marksInput").value;

    newMarksValue = Number(newMarksValue);

    updateMarks(newMarksValue);
});