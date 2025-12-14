const BASE_URL = 'http://localhost:3030/jsonstore/gifts';

//Section Form:
const sectionFormEl = document.querySelector('section#form-section');	

const giftInputEl = sectionFormEl.querySelector('#gift');
const forWhomInputEl = sectionFormEl.querySelector('#for-whom');
const priceInputEl = sectionFormEl.querySelector('#price');

const addBtnEl = sectionFormEl.querySelector('button#add-present');
addBtnEl.addEventListener('click', addNewGift);

const editBtnEl = sectionFormEl.querySelector('button#edit-present');
editBtnEl.addEventListener('click', edditCurrentGift);


//Div Wrapper:
const divWrapperEl = document.querySelector('div#wrapper');
const divGiftsListel = divWrapperEl.querySelector('div#gift-list');
console.log(divGiftsListel);

const loadBtnEl = divWrapperEl.querySelector('button#load-presents');
loadBtnEl.addEventListener('click', function (e) {
                                                    e.preventDefault();
                                                    loadAllGifts();
                                                });


//Functions:

async function loadAllGifts(){

    const response = await fetch(BASE_URL);
    const data = await response.json();

    const giftsData = Object.values(data);

    divGiftsListel.innerHTML = '';

    for (const giftEnt of giftsData) {
        divGiftsListel.appendChild(createGiftBox(giftEnt));
    }

    editBtnEl.disabled = true;
}

async function addNewGift(event){
    event.preventDefault();

    const gift = giftInputEl.value;
    const forWhom = forWhomInputEl.value;
    const price = priceInputEl.value;

    if(gift === '' || forWhom === '' || price === ''){
        return;
    }

    const newGiftEnt = {
        gift,
        forWhom,
        price
    };

    const response = await fetch(BASE_URL, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(newGiftEnt)
    });

    if(!response.ok){
        alert('Error adding new gift!');
        return;
    }

    clearInput();
    loadAllGifts();

}


function createGiftBox(giftEnt){
    const divGiftBoxEl = document.createElement('div');
    divGiftBoxEl.classList.add('gift-box');

    const divContentEl = document.createElement('div');
    divContentEl.classList.add('content');

    const pGiftEl = document.createElement('p');
    pGiftEl.textContent = giftEnt.gift;

    const pPriceEl = document.createElement('p');
    pPriceEl.textContent = giftEnt.price;

    const pForWhomEl = document.createElement('p');
    pForWhomEl.textContent = giftEnt.forWhom;

    divContentEl.appendChild(pGiftEl);
    divContentEl.appendChild(pPriceEl);
    divContentEl.appendChild(pForWhomEl);


    const divButtonsContainerEl = document.createElement('div');
    divButtonsContainerEl.classList.add('buttons-container');

    const changeBtnEl = document.createElement('button');
    changeBtnEl.classList.add('change-btn');
    changeBtnEl.textContent = 'Change';
    changeBtnEl.dataset.id = giftEnt._id;

    const deleteBtnEl = document.createElement('button');
    deleteBtnEl.classList.add('delete-btn');
    deleteBtnEl.textContent = 'Delete';
    deleteBtnEl.dataset.id = giftEnt._id;

    divButtonsContainerEl.appendChild(changeBtnEl);
    divButtonsContainerEl.appendChild(deleteBtnEl);

    //TODO: Add Event Listeners to the buttons
    changeBtnEl.addEventListener('click', changeCurrentGift);
    deleteBtnEl.addEventListener('click', deleteCurrentGift);

    divGiftBoxEl.appendChild(divContentEl);
    divGiftBoxEl.appendChild(divButtonsContainerEl);

    return divGiftBoxEl;
}

async function changeCurrentGift(event){

    const divGiftBoxEl = event.target.parentElement.parentElement;
    const giftEnt = {
        gift: divGiftBoxEl.querySelector('div.content p:nth-child(1)').textContent,
        price: divGiftBoxEl.querySelector('div.content p:nth-child(2)').textContent,
        forWhom: divGiftBoxEl.querySelector('div.content p:nth-child(3)').textContent
    };
    const giftId = event.target.dataset.id;

    giftInputEl.value = giftEnt.gift;
    forWhomInputEl.value = giftEnt.forWhom;
    priceInputEl.value = giftEnt.price;
    editBtnEl.dataset.id = giftId;

    addBtnEl.disabled = true;
    editBtnEl.disabled = false;

    divGiftBoxEl.remove();
    
}

async function edditCurrentGift(event){
    event.preventDefault();

    const giftId = event.target.dataset.id;

    const gift = giftInputEl.value;
    const forWhom = forWhomInputEl.value;
    const price = priceInputEl.value;

    if(gift === '' || forWhom === '' || price === ''){
        return;
    }

    const updatedGiftEnt = {
        gift,
        forWhom,
        price,
        _id: giftId
    };

    const response = await fetch(`${BASE_URL}/${giftId}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(updatedGiftEnt)
    });

    if(!response.ok){
        alert('Error editing the gift!');
        return;
    }

    clearInput();
    addBtnEl.disabled = false;
    editBtnEl.disabled = true;
    loadAllGifts();
}

async function deleteCurrentGift(event){
    const giftId = event.target.dataset.id;

    const response = await fetch(`${BASE_URL}/${giftId}`, {
        method: 'DELETE'
    });

    if(!response.ok){
        alert('Error deleting the gift!');
        return;
    }

    loadAllGifts();
}


function clearInput(){
    giftInputEl.value = '';
    forWhomInputEl.value = '';
    priceInputEl.value = '';
}