document.addEventListener("DOMContentLoaded", solve);

function solve() {

  const selectEl = document.querySelector("select#menu");

  const submitInputEl = document.querySelector(
    'article form input[type="submit"]'
  );
  submitInputEl.addEventListener("click", addElement);

  function addElement(event) {
    event.preventDefault();
    event.stopPropagation();

    let inputTextEl =
      event.target.parentElement.querySelector("input#newItemText").value;
    let inputValueEl =
      event.target.parentElement.querySelector("input#newItemValue").value;

    const optionEl = document.createElement("option");
    optionEl.textContent = inputTextEl;
    optionEl.value = inputValueEl;

    selectEl.appendChild(optionEl);

    event.target.parentElement.querySelector("input#newItemText").value = "";
    event.target.parentElement.querySelector("input#newItemValue").value = "";
  }
}
