window.addEventListener("load", solve);

function solve() {

  const divTasksEl = document.querySelector("#tasks");
  const sectionCurrentTasksEl = divTasksEl.querySelector(".current-tasks.tasks");
  const sectionDoneTasksEl = divTasksEl.querySelector(".done-tasks.tasks");

  const ulCurrentTasksEl = sectionCurrentTasksEl.querySelector("ul#task-list");
  const ulDoneListsEl = sectionDoneTasksEl.querySelector("ul#done-list");

  const sectionTaskEl = document.querySelector("#add-task");

  const placeInput = sectionTaskEl.querySelector("#place");
  const actionInput = sectionTaskEl.querySelector("#action");
  const personInput = sectionTaskEl.querySelector("#person");

  const addBtn = sectionTaskEl.querySelector("#add-btn");
  addBtn.addEventListener("click", addNewTask);

  function addNewTask(event) {
    event.preventDefault();

    if(!placeInput.value || !actionInput.value || !personInput.value){
      return;
    }

    const place = placeInput.value;
    const action = actionInput.value;
    const person = personInput.value;

    const liCleanTaskEl = document.createElement("li");
    liCleanTaskEl.classList.add("clean-task");
    liCleanTaskEl.appendChild(createArticleElement(place, action, person));

    liCleanTaskEl.appendChild(createButtonsForCurrentTask());

    ulCurrentTasksEl.appendChild(liCleanTaskEl);

    clearInputFields() 
  }

  function createArticleElement(place, action, person) {
    const articleEl = document.createElement("article");

    const pPlaceEl = document.createElement("p");
    pPlaceEl.textContent = `Place:${place}`;

    const pActionEl = document.createElement("p");
    pActionEl.textContent = `Action:${action}`;

    const pPersonEl = document.createElement("p");
    pPersonEl.textContent = `Person:${person}`;

    articleEl.appendChild(pPlaceEl);
    articleEl.appendChild(pActionEl);
    articleEl.appendChild(pPersonEl);

    return articleEl;
  }

  function createButtonsForCurrentTask() {
    const divEl = document.createElement("div");
    divEl.classList.add("buttons");

    const editBtn = document.createElement("button");
    editBtn.classList.add("edit");
    editBtn.textContent = "Edit";


    const doneBtn = document.createElement("button");
    doneBtn.classList.add("done");
    doneBtn.textContent = "Done";


    divEl.appendChild(editBtn);
    divEl.appendChild(doneBtn);

    editBtn.addEventListener("click", editCurrentTask);
    doneBtn.addEventListener("click", markCurrentTaskAsDone);
    return divEl;
  }

  function editCurrentTask(event) {
    const liTaskEl = event.target.parentElement.parentElement;
    const articleEl = liTaskEl.querySelector("article");

    const place = articleEl.children[0].textContent.split(":")[1].trim();;
    const action = articleEl.children[1].textContent.split(":")[1].trim();;
    const person = articleEl.children[2].textContent.split(":")[1].trim();;

    placeInput.value = place;
    actionInput.value = action;
    personInput.value = person;

    liTaskEl.remove();
  }

  function markCurrentTaskAsDone(event) {
    const liTaskEl = event.target.parentElement.parentElement;

    liTaskEl.classList.remove("clean-task");
    liTaskEl.removeChild(liTaskEl.querySelector("div.buttons"));
    liTaskEl.appendChild(createDeleteButtonElement());

    ulDoneListsEl.appendChild(liTaskEl);
  }

  function createDeleteButtonElement(){
    const deleteBtn = document.createElement("button");
    deleteBtn.classList.add("delete");
    deleteBtn.textContent = "Delete";

    deleteBtn.addEventListener("click", deleteDoneTask);

    return deleteBtn;
  }

  function deleteDoneTask(event) {
    const liTaskEl = event.target.parentElement;
    liTaskEl.remove();
  }

  function clearInputFields() {
    placeInput.value = "";
    actionInput.value = "";
    personInput.value = "";
  }

}