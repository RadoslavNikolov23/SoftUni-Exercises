const BASE_URL = 'http://localhost:3030/jsonstore/workout';

const formElement = document.querySelector('div#form > form');

const workoutNameInput = formElement.querySelector('input#workout');
const workoutLocationInput = formElement.querySelector('input#location');
const workoutDateInput = formElement.querySelector('input#date');

const loadBtn = document.getElementById('load-workout');
loadBtn.addEventListener('click', loadAllWorkouts);

const addBtn = document.getElementById('add-workout');
addBtn.addEventListener('click', addWorkout);

const editBtn = document.getElementById('edit-workout');
editBtn.addEventListener('click', onEditWorkout);


let currentId = null;

async function loadAllWorkouts(event) {
    event.preventDefault();
    event.stopPropagation();

    const response = await fetch(BASE_URL);
    const workoutData = await response.json();

    if(!response.ok) {
        alert(workoutData.message);
        return;
    }

    const workoutDivList = document.getElementById('list');
    workoutDivList.replaceChildren();

    for(const workoutObj of Object.values(workoutData)) {
        workoutDivList.appendChild(createWorkoutDiv(workoutObj));
    }

    editBtn.disabled = true;
    editBtn.dataset.id = '';
    addBtn.disabled = false;
}

async function addWorkout(event) {
    event.preventDefault();
    event.stopPropagation();

    if(workoutNameInput.value === '' || workoutLocationInput.value === '' || workoutDateInput.value === '') {
        return;
    }

    const workoutName = workoutNameInput.value;
    const workoutLocation = workoutLocationInput.value;
    const workoutDate = workoutDateInput.value;

    const workoutObj = {
        workout: workoutName,
        location: workoutLocation,
        date: workoutDate
    };

    const response = await fetch(BASE_URL, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(workoutObj)
    });

    if(!response.ok) {
        return;
    }

    clearInputFields();

    loadAllWorkouts(event);
}

async function onEditWorkout(event) {  
    event.preventDefault();
    event.stopPropagation();

    if(workoutNameInput.value === '' || workoutLocationInput.value === '' || workoutDateInput.value === '') {
        return;
    }

    const workoutId = editBtn.dataset.id;

    const workoutName = workoutNameInput.value;
    const workoutLocation = workoutLocationInput.value;
    const workoutDate = workoutDateInput.value;

    const workoutObj = {
        workout: workoutName,
        location: workoutLocation,
        date: workoutDate,
        _id: workoutId
    };

    const response = await fetch(`${BASE_URL}/${workoutId}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(workoutObj)
    });

    if(!response.ok) {
        return;
    }

    clearInputFields();

    editBtn.disabled = true;
    editBtn.dataset.id = '';
    addBtn.disabled = false;

    loadAllWorkouts(event);
}

async function onChangeWorkout(event) {
    event.preventDefault();
    event.stopPropagation();

    const workoutDiv = event.target.parentElement.parentElement;
    const workoutName = workoutDiv.querySelector('h2').textContent;
    const workoutLocation = workoutDiv.querySelector('#location').textContent;
    const workoutDate = workoutDiv.querySelector('h3:nth-of-type(1)').textContent;
    editBtn.dataset.id = event.target.dataset.id;

    workoutNameInput.value = workoutName;
    workoutLocationInput.value = workoutLocation;
    workoutDateInput.value = workoutDate;
    editBtn.disabled = false;
    addBtn.disabled = true;

    workoutDiv.remove();
}

async function onDeleteWorkout(event) {
    event.preventDefault();
    event.stopPropagation();

    const workoutId = event.target.dataset.id;
    await fetch(`${BASE_URL}/${workoutId}`, {
        method: 'DELETE'
    });

    loadAllWorkouts(event);
}

function createWorkoutDiv(workoutData) {

    const workoutDiv = document.createElement('div');
    workoutDiv.classList.add('container');

    const workoutHeader2 = document.createElement('h2');
    workoutHeader2.textContent = workoutData.workout;

    const dataHeader3 = document.createElement('h3');
    dataHeader3.textContent = workoutData.date;

    const locationHeader3 = document.createElement('h3');
    locationHeader3.textContent = workoutData.location;
    locationHeader3.id='location';

    workoutDiv.appendChild(workoutHeader2);
    workoutDiv.appendChild(dataHeader3);
    workoutDiv.appendChild(locationHeader3);

    const buttonsDiv = document.createElement('div');
    buttonsDiv.id = 'buttons-container';

    const changeBtn = document.createElement('button');
    changeBtn.classList.add('change-btn');
    changeBtn.textContent = 'Change';
    changeBtn.dataset.id = workoutData._id;

    changeBtn.addEventListener('click', onChangeWorkout);

    const deleteBtn = document.createElement('button');
    deleteBtn.classList.add('delete-btn');
    deleteBtn.textContent = 'Done';
    deleteBtn.dataset.id = workoutData._id;

    deleteBtn.addEventListener('click', onDeleteWorkout);

    buttonsDiv.appendChild(changeBtn);
    buttonsDiv.appendChild(deleteBtn);
    workoutDiv.appendChild(buttonsDiv);

    return workoutDiv;
}

function clearInputFields() {
    
    workoutNameInput.value = '';
    workoutLocationInput.value = '';
    workoutDateInput.value = '';
}