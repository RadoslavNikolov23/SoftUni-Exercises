window.addEventListener("load", solve);

function solve() {

  const formEl = document.querySelector("form.registerEvent");

  const emailInput = formEl.querySelector("input#email");
  const eventInput = formEl.querySelector("input#event");
  const locationInput = formEl.querySelector("input#location");

  const nextBtnEl = formEl.querySelector("button#next-btn");
  nextBtnEl.addEventListener("click", onNext);

  const ulPreviewListEl = document.querySelector("ul#preview-list");
  const ulEventsListEl = document.querySelector("ul#event-list");

  function onNext(event) {
    event.preventDefault();
    event.stopPropagation();

    if(!emailInput.value || !eventInput.value || !locationInput.value){
      return;
    }

    ulPreviewListEl.appendChild(createLiElement(emailInput.value, eventInput.value, locationInput.value,true));

    // Clear input fields
    emailInput.value = "";
    eventInput.value = "";
    locationInput.value = "";

    nextBtnEl.disabled = true;
  
  }

  function createLiElement(email, event, location,toAddButtons) {
    const liEl = document.createElement("li");
    liEl.classList.add("application");

    const articleEl = document.createElement("article");

    const h4El = document.createElement("h4");
    h4El.textContent = email;

    const pEventEl = document.createElement("p");
    const strongEmailEl = document.createElement("strong");
    strongEmailEl.textContent = `Event:`;
    const brEmailEl1 = document.createElement("br");
    pEventEl.appendChild(strongEmailEl);
    pEventEl.appendChild(brEmailEl1);
    pEventEl.appendChild(document.createTextNode(`${event}`));

    const pLocationEl = document.createElement("p");
    const strongLocationEl = document.createElement("strong");
    strongLocationEl.textContent = `Location:`;
    const brLocationEl1 = document.createElement("br");
    pLocationEl.appendChild(strongLocationEl);
    pLocationEl.appendChild(brLocationEl1);
    pLocationEl.appendChild(document.createTextNode(`${location}`));

    articleEl.appendChild(h4El);
    articleEl.appendChild(pEventEl);
    articleEl.appendChild(pLocationEl);

   

    liEl.appendChild(articleEl);

    if(toAddButtons){
      addButtons(liEl);
    }

    return liEl;
  }

  function addButtons(liEl){
    
    const editBtnEl = document.createElement("button");
    editBtnEl.classList.add("action-btn","edit");
    editBtnEl.textContent = "edit";

    editBtnEl.addEventListener("click", onEditEmail);

    const applyBtnEl = document.createElement("button");
    applyBtnEl.classList.add("action-btn","apply");
    applyBtnEl.textContent = "apply";

    applyBtnEl.addEventListener("click", onApplyEmail);
    liEl.appendChild(editBtnEl);
    liEl.appendChild(applyBtnEl);

    return liEl;
  }

  function onEditEmail(event){
    const liEl = event.target.parentElement;

    //const email = liEl.

    emailInput.value = liEl.querySelector("h4").textContent;
    eventInput.value = liEl.querySelector("p:nth-of-type(1)").textContent.split(":")[1];
    locationInput.value = liEl.querySelector("p:nth-of-type(2)").textContent.split(":")[1];

    liEl.remove();
    nextBtnEl.disabled = false;

  }

  function onApplyEmail(event){
    const liEl = event.target.parentElement;
    liEl.remove();

    const emailEl = liEl.querySelector("h4").textContent;
    const eventEl = liEl.querySelector("p:nth-of-type(1)").textContent.split(":")[1];
    const locationEl = liEl.querySelector("p:nth-of-type(2)").textContent.split(":")[1];

    ulEventsListEl.appendChild(createLiElement(emailEl, eventEl, locationEl,false));
    nextBtnEl.disabled = false;
  }
  
}
