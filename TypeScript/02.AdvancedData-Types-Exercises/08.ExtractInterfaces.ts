type status = 'Logged' | 'Started' | 'InProgress' | 'Done';

interface user {
    username:string;
    signupDate:Date;
    passwordHash:string;
}

interface task {
    status: status;
    title: string;
    daysRequired: number;
    assignedTo: user | undefined;
    changeStatus(newStatus:status):void;
}


function assignTask(
    user: user,
    task: task
) {
    if (task.assignedTo == undefined) {
        task.assignedTo = user;
        console.log(`User ${user.username} assigned to task '${task.title}'`);
    }
}

let user = {
    username: 'Margaret',
    signupDate: new Date(2022, 1, 13),
    passwordHash: 'random'
}
let task1 = {
    status: <status>'Logged',
    title: 'Need assistance',
    daysRequired: 1,
    assignedTo: undefined,
    changeStatus(newStatus: status) { this.status = newStatus; }
}

let task2 = {
    status: <status> 'Done',
    title: 'Test',
    daysRequired: 12,
    assignedTo: undefined,
    changeStatus(newStatus: status) { this.status = newStatus; },
    moreProps: 300,
    evenMore: 'wow'
}


assignTask(user, task1);
assignTask(user, task2);
