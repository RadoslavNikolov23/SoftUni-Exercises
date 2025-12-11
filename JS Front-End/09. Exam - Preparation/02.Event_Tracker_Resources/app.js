window.addEventListener("load", solve);

function solve(){
    
    const inputEventNameEl = document.querySelector("#event");
    const inputEventNoteEl = document.querySelector("#note");
    const inputEventDateEl = document.querySelector("#date");
    const saveInputBtnEl = document.querySelector("#save");

    saveInputBtnEl.addEventListener("click", onSave);

    const upcomingUlEl = document.querySelector("#upcoming > #upcoming-list");
    const eventDoneUlEl = document.querySelector("#events > #events-list");
    const eventDoneDeleteBtnEl = document.querySelector("#events > .btn.delete");

    eventDoneDeleteBtnEl.addEventListener("click", onDeleteAll);

    function onSave(event){
        event.preventDefault();
        event.stopPropagation();

        const eventName = inputEventNameEl.value;
        const eventNote = inputEventNoteEl.value;
        const eventDate = inputEventDateEl.value;

        if(eventName === "" || eventDate === "" || eventNote === ""){
            return;
        }

        const liEl = document.createElement("li");
        liEl.classList.add("event-item");

        const divContainerEl = document.createElement("div");
        divContainerEl.classList.add("event-container");

        const articleEl = document.createElement("article");
        const paragraphElOne = document.createElement("p");
        paragraphElOne.textContent = `Name: ${eventName}`;
        const paragraphElTwo = document.createElement("p");
        paragraphElTwo.textContent = `Note: ${eventNote}`;
        const paragraphElThree = document.createElement("p");
        paragraphElThree.textContent = `Date: ${eventDate}`;

        articleEl.appendChild(paragraphElOne);
        articleEl.appendChild(paragraphElTwo);
        articleEl.appendChild(paragraphElThree);

        divContainerEl.appendChild(articleEl);

        const divBtnEl = document.createElement("div");
        divBtnEl.classList.add("buttons");

        const editBtnEl = document.createElement("button");
        editBtnEl.classList.add("btn");
        editBtnEl.classList.add("edit");
        editBtnEl.textContent = "Edit";

        editBtnEl.addEventListener("click", onEdit);

        const doneBtnEl = document.createElement("button");
        doneBtnEl.classList.add("btn");
        doneBtnEl.classList.add("done");
        doneBtnEl.textContent = "Done";

        doneBtnEl.addEventListener("click", onDone);

        divBtnEl.appendChild(editBtnEl);
        divBtnEl.appendChild(doneBtnEl);

        divContainerEl.appendChild(divBtnEl);

        liEl.appendChild(divContainerEl);

        upcomingUlEl.appendChild(liEl);

        inputEventNameEl.value = "";
        inputEventNoteEl.value = "";
        inputEventDateEl.value = "";
    }

    function onEdit(event){
        event.preventDefault();
        event.stopPropagation();

        const divBtnParrent = event.target.parentElement;
        const divContainerParrent = divBtnParrent.parentElement;
        const articleEl = divContainerParrent.querySelector("article");
        const paragraphEls = articleEl.querySelectorAll("p");
        const eventName = paragraphEls[0].textContent.split(": ")[1];
        const eventNote = paragraphEls[1].textContent.split(": ")[1];
        const eventDate = paragraphEls[2].textContent.split(": ")[1];

        inputEventNameEl.value = eventName;
        inputEventNoteEl.value = eventNote;
        inputEventDateEl.value = eventDate;

        divContainerParrent.parentElement.remove();
    }

    function onDone(event){
        event.preventDefault();
        event.stopPropagation();

        const divBtnParrent = event.target.parentElement;
        const divContainerParrent = divBtnParrent.parentElement;
        const articleElParrent = divContainerParrent.querySelector("article");
        const paragraphEls = articleElParrent.querySelectorAll("p");
        const eventName = paragraphEls[0].textContent.split(": ")[1];
        const eventNote = paragraphEls[1].textContent.split(": ")[1];
        const eventDate = paragraphEls[2].textContent.split(": ")[1];

        const liEl = document.createElement("li");
        liEl.classList.add("event-item");

        const articleEl = document.createElement("article");
        const paragraphElOne = document.createElement("p");
        paragraphElOne.textContent = `Name: ${eventName}`;
        const paragraphElTwo = document.createElement("p");
        paragraphElTwo.textContent = `Note: ${eventNote}`;
        const paragraphElThree = document.createElement("p");
        paragraphElThree.textContent = `Date: ${eventDate}`;

        articleEl.appendChild(paragraphElOne);
        articleEl.appendChild(paragraphElTwo);
        articleEl.appendChild(paragraphElThree);

        liEl.appendChild(articleEl);

        eventDoneUlEl.appendChild(liEl);

        divContainerParrent.parentElement.remove();
    }

    function onDeleteAll(event){
        event.preventDefault();
        event.stopPropagation();
        eventDoneUlEl.innerHTML = "";
    }
}


