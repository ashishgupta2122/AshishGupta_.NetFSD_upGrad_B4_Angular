const marks = [75, 82, 60, 45, 90];

const calculateTotal = (arr) => arr.reduce((sum, mark) => sum + mark, 0);

const calculateAverage = (arr) => {
    const total = calculateTotal(arr);
    return total / arr.length;
};

const getResult = (average) =>
    average >= 50 ? "Pass" : "Fail";

const formattedMarks = marks.map((mark, index) => `Student ${index + 1}: ${mark}`);

const analyzeMarks = () => {
    const total = calculateTotal(marks);
    const average = calculateAverage(marks);
    const result = getResult(average);

    console.log("Student Marks:");
    formattedMarks.forEach(m => console.log(m));


    console.log(`Total Marks: ${total} Average Marks: ${average.toFixed(2)}
    Result: ${result}`);
};

export default analyzeMarks;