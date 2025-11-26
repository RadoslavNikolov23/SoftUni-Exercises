document.addEventListener("DOMContentLoaded", solve);

function solve() {
  const divContent = document.querySelector("div#content");
  const formEl = document.querySelector("form");

  const btnEl = formEl.querySelector('input[type="submit"]');
  btnEl.addEventListener("click", onClick);


  function onClick(event) {
    event.preventDefault();
    event.stopPropagation();

    createElements();
    formEl.reset();
  }

  function createElements() {
    const inputEl = formEl.querySelector('input[type="text"]');
    const inputArray = inputEl.value.split(", ");

    for (const item of inputArray) {
      const divEl = document.createElement("div");
      const paragraphEl = document.createElement("p");
      paragraphEl.style.display = "none";
      paragraphEl.textContent = item;

      divEl.addEventListener("click", (event) => {
        event.preventDefault();
        event.stopPropagation();

        if (paragraphEl.style.display === "none") {
          paragraphEl.style.display = "block";
        } else {
          paragraphEl.style.display = "none";
        }
      });

      divEl.appendChild(paragraphEl);
      divContent.appendChild(divEl);
    }
  }
}
