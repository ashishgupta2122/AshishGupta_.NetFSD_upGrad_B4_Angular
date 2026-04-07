let tasks = [];

export const addTaskCallback = (task, callback) => {
    setTimeout(() => {
        tasks.push(task);
        callback(`Task Added: ${task}`);
    }, 1000);
}

export const deleteTaskCallback = (task, callback) => {
    setTimeout(() => {
        tasks = tasks.filter(t => t !== task);
        callback(`Task Deleted: ${task}`);
    }, 1000);
}

export const listTasksCallback = (callback) => {
    setTimeout(() => {
        callback(`Tasks: ${tasks.join(", ")}`);
    }, 1000);
};


export const addTaskPromise = (task) => {
    return new Promise((resolve) => {
        setTimeout(() => {
            tasks.push(task);
            resolve(`Task Added: ${task}`);
        }, 1000);
    });
};

export const deleteTaskPromise = (task) => {
    return new Promise((resolve) => {
        setTimeout(() => {
            tasks = tasks.filter(t => t !== task);
            resolve(`Task Deleted: ${task}`);
        }, 1000);
    });
};

export const listTasksPromise = () => {
    return new Promise((resolve) => {
        setTimeout(() => {
            resolve(`📋 Tasks: ${tasks.join(", ")}`);
        }, 1000);
    });
};

export const addTask = async (task) => {
    await addTaskPromise(task);
    return `✅ Task Added: ${task}`;
};

export const deleteTask = async (task) => {
    await deleteTaskPromise(task);
    return `🗑️ Task Deleted: ${task}`;
};

export const listTasks = async () => {
    const result = await listTasksPromise();
    return result;
};