document.addEventListener("DOMContentLoaded", solve);

function solve() {
  const formTextAreaEl = document.querySelector("form#input textarea");
  const generateBtnEl = document.querySelector(
    'form#input input[type="submit"]'
  );

  generateBtnEl.addEventListener("click", addNewFurniture);

  function addNewFurniture(event) {
    event.preventDefault();
    event.stopPropagation();

    const furnitureData = JSON.parse(formTextAreaEl.value);
    const furnitureListEl = document.querySelector("form#shop table tbody");

    for (const furniture of furnitureData) {
      const imageUrl = furniture.img;
      const name = furniture.name;
      const price = Number(furniture.price);
      const decorationFactor = furniture.decFactor;

      const trEl = document.createElement("tr");

      const tdImageEl = document.createElement("td");
      const imgEl = document.createElement("img");
      imgEl.src = imageUrl;
      tdImageEl.appendChild(imgEl);
      trEl.appendChild(tdImageEl);

      const tdNameEl = document.createElement("td");
      const pNameEl = document.createElement("p");
      pNameEl.textContent = name;
      tdNameEl.appendChild(pNameEl);
      trEl.appendChild(tdNameEl);

      const tdPriceEl = document.createElement("td");
      const pPriceEl = document.createElement("p");
      pPriceEl.textContent = price;
      tdPriceEl.appendChild(pPriceEl);
      trEl.appendChild(tdPriceEl);

      const tdDecFactorEl = document.createElement("td");
      const pDecFactorEl = document.createElement("p");
      pDecFactorEl.textContent = decorationFactor;
      tdDecFactorEl.appendChild(pDecFactorEl);
      trEl.appendChild(tdDecFactorEl);

      const tdCheckboxEl = document.createElement("td");
      const checkboxEl = document.createElement("input");
      checkboxEl.type = "checkbox";
      tdCheckboxEl.appendChild(checkboxEl);
      trEl.appendChild(tdCheckboxEl);

      furnitureListEl.appendChild(trEl);
    }
  }

  const buyBtnEl = document.querySelector('form#shop input[type="submit"]');

  buyBtnEl.addEventListener("click", buyFurniture);

  function buyFurniture(event) {
    event.preventDefault();
    event.stopPropagation();

    const furnitureListEl = document.querySelectorAll(
      "form#shop table tbody tr"
    );
    const boughtFurniture = [];
    let totalPrice = 0;
    let totalDecFactor = 0;

    for (const furniture of furnitureListEl) {
      const isChecked = furniture.querySelector(
        'td input[type="checkbox"]'
      ).checked;
      if (isChecked) {
        const name = furniture.querySelector("td:nth-child(2) p").textContent;
        const price = Number(
          furniture.querySelector("td:nth-child(3) p").textContent
        );
        const decFactor = Number(
          furniture.querySelector("td:nth-child(4) p").textContent
        );
        boughtFurniture.push(name);
        totalPrice += price;
        totalDecFactor += decFactor;
      }
    }

    const outputTextAreaEl = document.querySelector("form#shop textarea");
    const averageDecFactor = totalDecFactor / boughtFurniture.length;
    outputTextAreaEl.value = "";
    outputTextAreaEl.value += `Bought furniture: ${boughtFurniture.join(", ")}\n`;
    outputTextAreaEl.value += `Total price: ${totalPrice}\n`;
    outputTextAreaEl.value += `Average decoration factor: ${averageDecFactor}`;
  }
}
