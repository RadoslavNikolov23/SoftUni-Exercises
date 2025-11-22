function addItem() {
   
    const inputEl = document.getElementById('newItemText');

    const ulEl = document.getElementById('items');
    const liEl = document.createElement('li');
    liEl.textContent = inputEl.value;
    ulEl.appendChild(liEl);

    inputEl.value = '';


}
