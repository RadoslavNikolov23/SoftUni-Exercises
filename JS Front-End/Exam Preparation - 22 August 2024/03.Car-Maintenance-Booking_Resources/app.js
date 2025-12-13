const BASE_URL = 'http://localhost:3030/jsonstore/appointments';

const divFormEl = document.querySelector('#form');

const modelInputeEl = divFormEl.querySelector('#car-model');
const serviceInputEl = divFormEl.querySelector('#car-service');
const dateInputEl = divFormEl.querySelector('#date');

const buttonsContainerEl = document.querySelector('#btn-container');

const addAppointmentBtnEl = buttonsContainerEl.querySelector('#add-appointment');
addAppointmentBtnEl.addEventListener('click', addNewAppointment);

const editAppointmentBtnEl = buttonsContainerEl.querySelector('#edit-appointment');
editAppointmentBtnEl.addEventListener('click', editChangedAppointment);

const sectAppointmentsEl = document.querySelector('#appointments');
const btnLoadAppointmentsEl = sectAppointmentsEl.querySelector('#load-appointments');
btnLoadAppointmentsEl.addEventListener('click', function (e) {
    e.preventDefault();
    loadAppointments();
});

const ulAppointmentsEl = sectAppointmentsEl.querySelector('#appointments-list');

async function loadAppointments(event){
  

    const respone = await fetch(BASE_URL);
    const dataAppointments = await respone.json();

    ulAppointmentsEl.innerHTML = '';

    for (const appointment of Object.values(dataAppointments)) {
    ulAppointmentsEl.appendChild(
        createAppointmentElement(
            appointment.model,
            appointment.service,
            appointment.date,
            appointment._id
        )
    );
}

    editAppointmentBtnEl.disabled = true;
}

async function addNewAppointment(event){
    event.preventDefault();
    event.stopPropagation();

    if(!modelInputeEl.value || !serviceInputEl.value || !dateInputEl.value){
        return;
    }

    const model = modelInputeEl.value;
    const service = serviceInputEl.value;
    const date = dateInputEl.value;

    const appointment = {
        model,
        service,
        date
    };

    await fetch(BASE_URL, { 
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(appointment)
    });

    clearInputs()
    loadAppointments(event);
}

async function editChangedAppointment(event){
    event.preventDefault();
    event.stopPropagation();

    
    if(!modelInputeEl.value || !serviceInputEl.value || !dateInputEl.value){
        return;
    }

    const _id = editAppointmentBtnEl.dataset.id;
    const model = modelInputeEl.value;
    const service = serviceInputEl.value;
    const date = dateInputEl.value;
    const appointment = {
        model,
        service,
        date,
        _id
    };
    
    await fetch(`${BASE_URL}/${_id}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(appointment)
    });

    clearInputs()
    loadAppointments(event);
    addAppointmentBtnEl.disabled = false;
    editAppointmentBtnEl.disabled = true;
    editAppointmentBtnEl.removeAttribute('data-id');
}

function createAppointmentElement(model,service, date,_id){
    const liAppointmentEl = document.createElement('li');
    liAppointmentEl.classList.add('appointment');

    const h2ModelEl = document.createElement('h2');
    h2ModelEl.textContent = model;

    const h3DateEl = document.createElement('h3');
    h3DateEl.textContent = date;

    const h3ServiceEl = document.createElement('h3');
    h3ServiceEl.textContent = service;

    const buttonsDivEl = document.createElement('div');
    buttonsDivEl.classList.add('buttons-appointment');

    const btnChangeEl = document.createElement('button');
    btnChangeEl.classList.add('change-btn');
    btnChangeEl.textContent = 'Change';
    btnChangeEl.dataset.id=_id;

  

    const btnDeletelEl = document.createElement('button');
    btnDeletelEl.classList.add('delete-btn');
    btnDeletelEl.textContent = 'Delete';
    btnDeletelEl.dataset.id=_id;


    buttonsDivEl.appendChild(btnChangeEl);
    buttonsDivEl.appendChild(btnDeletelEl);

    liAppointmentEl.appendChild(h2ModelEl);
    liAppointmentEl.appendChild(h3DateEl);
    liAppointmentEl.appendChild(h3ServiceEl);
    liAppointmentEl.appendChild(buttonsDivEl);

    btnChangeEl.addEventListener('click', async (event) => {
        event.preventDefault();
        event.stopPropagation();

        modelInputeEl.value = h2ModelEl.textContent;
        serviceInputEl.value = h3ServiceEl.textContent;
        dateInputEl.value = h3DateEl.textContent;
    
        editAppointmentBtnEl.dataset.id = _id;
        addAppointmentBtnEl.disabled = true;
        editAppointmentBtnEl.disabled = false;
    });

    
    btnDeletelEl.addEventListener('click', async (event) => {
        event.preventDefault();
        event.stopPropagation();

        const _id = btnDeletelEl.dataset.id;

        await fetch(`${BASE_URL}/${_id}`, {
            method: 'DELETE'
        });

        loadAppointments(event);
    });

    return liAppointmentEl;
}

function clearInputs(){
    modelInputeEl.value = '';
    serviceInputEl.value = '';
    dateInputEl.value = '';
}