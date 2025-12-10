
const BASE_URL = `http://localhost:3030/jsonstore/orders/`;

let baseID = '';

const createOrderBtnEl = document.getElementById('order-btn');
createOrderBtnEl.addEventListener('click', onCreateOrder);

const editOrderBtnEl = document.getElementById('edit-order');
editOrderBtnEl.addEventListener('click', onEditOrder);


const loadOrdersBtnEl = document.getElementById('load-orders');
loadOrdersBtnEl.addEventListener('click', getAllOrders);


async function onCreateOrder(event){
    event.preventDefault();
    event.stopPropagation();

    const inputNameEl = document.getElementById('name');
    const inputQuantityEl = document.getElementById('quantity');
    const inputDateEl = document.getElementById('date');

    const name = inputNameEl.value;
    const quantity = inputQuantityEl.value;
    const date = inputDateEl.value;

    if(name === "" || quantity === "" || date === ""){
        return;
    }

    const order = {
        name,
        quantity,
        date
    };

    const response = await fetch(BASE_URL, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(order)
    });

    if(!response.ok){
        return alert('Error creating order!');
    }

    inputNameEl.value = '';
    inputQuantityEl.value = '';
    inputDateEl.value = '';

    await getAllOrders(event);
}


async function getAllOrders(event) {
    event.preventDefault();
    event.stopPropagation();

    const response = await fetch(BASE_URL);
    const data = await response.json();

    if(!response.ok){
        return alert('Error fetching orders!');
    }

    const orders = Object.values(data);
    const liDiv = document.getElementById('list');
    liDiv.innerHTML = '';

    for(const order of orders){

        const divContainer = document.createElement('div');
        divContainer.classList.add('container');

        const h2El = document.createElement('h2');
        h2El.textContent = order.name;

        const h3ElOne = document.createElement('h3');
        h3ElOne.textContent = `Quantity: ${order.quantity}`; 
        
        const h3ElTwo = document.createElement('h3');
        h3ElTwo.textContent = order.date;

        const btnElChange = document.createElement('button');
        btnElChange.textContent = 'Change';
        btnElChange.classList.add('change-btn');
        btnElChange.dataset.id = order._id;

        btnElChange.addEventListener('click', onChange);

        const btnElDone = document.createElement('button');
        btnElDone.textContent = 'Done';
        btnElDone.classList.add('done-btn');
        btnElDone.dataset.id = order._id;

        btnElDone.addEventListener('click', onDone);

        divContainer.appendChild(h2El);
        divContainer.appendChild(h3ElOne);
        divContainer.appendChild(h3ElTwo);
        divContainer.appendChild(btnElChange);
        divContainer.appendChild(btnElDone);

        liDiv.appendChild(divContainer);
    }
}

    async function onChange(event){
        event.preventDefault();
        event.stopPropagation();

        const orderId = event.target.dataset.id;

        const response = await fetch(`${BASE_URL}${orderId}`);
        const order = await response.json();
        if(!response.ok){
            return alert('Error fetching order!');
        }

        const inputNameEl = document.getElementById('name');
        const inputQuantityEl = document.getElementById('quantity');
        const inputDateEl = document.getElementById('date');

        inputNameEl.value = order.name;
        inputQuantityEl.value = order.quantity;
        inputDateEl.value = order.date;

        const divContainer = event.target.parentElement;
        divContainer.remove();


        // const orderToDeleteResponse = await fetch(`${BASE_URL}${orderId}`, {
        //     method: 'DELETE'
        // });

        // if(!orderToDeleteResponse.ok){
        //     return alert('Error deleting order!');
        // }   

        // await getAllOrders(event);

        createOrderBtnEl.disabled = true;
        editOrderBtnEl.disabled = false;
        baseID = orderId;

    }

    async function onDone(event){
        event.preventDefault();
        event.stopPropagation();

        const orderId = event.target.dataset.id;
        const response = await fetch(`${BASE_URL}${orderId}`, {
            method: 'DELETE'
        });
        if(!response.ok){
            return alert('Error deleting order!');
        }
        await getAllOrders(event);
    }

    async function onEditOrder(event){
        event.preventDefault();
        event.stopPropagation();

        const inputNameEl = document.getElementById('name');
        const inputQuantityEl = document.getElementById('quantity');
        const inputDateEl = document.getElementById('date');

        const name = inputNameEl.value;
        const quantity = inputQuantityEl.value;
        const date = inputDateEl.value;

        const btnChangeOrder = event.target;
        btnChangeOrder.dataset.id = baseID;

        const parrentContainer = btnChangeOrder.parentElement;
        const btnDoneOrder = parrentContainer.querySelector('.done-btn');
        btnDoneOrder.dataset.id = baseID;

        if(name === "" || quantity === "" || date === ""){
            return;
        }

        const editedOrder = {
            name,
            quantity,
            date
        };


        const editResponse = await fetch(`${BASE_URL}${baseID}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'},
            body: JSON.stringify(editedOrder)
        });

        if(!editResponse.ok){
            return alert('Error editing order!');
        }

        inputNameEl.value = '';
        inputQuantityEl.value = '';
        inputDateEl.value = '';
        orderCreateBtn.disabled = false;
        editOrderBtn.disabled = true;
        baseID='';
        
        await getAllOrders(event);
    }
