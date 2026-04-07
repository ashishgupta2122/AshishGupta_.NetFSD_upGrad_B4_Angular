import {
    addTaskCallback,
    deleteTaskCallback,
    listTasksCallback,
    addTaskPromise,
    deleteTaskPromise,
    listTasksPromise,
    addTask,
    deleteTask,
    listTasks
} from "./taskManager.js";



addTaskCallback("Learn JS", (msg) => {
    console.log(msg);

    addTaskCallback("Build Project", () => {
        listTasksCallback(console.log);
    });
});



addTaskPromise("Gym")
    .then(console.log)
    .then(() => addTaskPromise("Study"))
    .then(() => listTasksPromise())
    .then(console.log);



const runAsync = async () => {
    console.log(await addTask("Code"));
    console.log(await deleteTask("Gym"));
    console.log(await listTasks());
};

runAsync();