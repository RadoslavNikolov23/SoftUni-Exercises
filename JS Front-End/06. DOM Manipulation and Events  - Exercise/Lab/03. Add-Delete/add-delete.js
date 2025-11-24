function addItem() {
   
    const inputEl = document.getElementById(`newItemText`);
    const inputValue = inputEl.value;

    const listEl = document.getElementById(`items`);
    const liEl = document.createElement(`li`);
    liEl.textContent = inputValue;
    liEl.innerHTML += ` <a href="#">[Delete]</a>`;

    const deleteLink = liEl.querySelector(`a`);

    deleteLink.addEventListener(`click`, function(event) {
        event.preventDefault();
        listEl.removeChild(liEl);
    });

    listEl.appendChild(liEl);
    inputEl.value = "";
}