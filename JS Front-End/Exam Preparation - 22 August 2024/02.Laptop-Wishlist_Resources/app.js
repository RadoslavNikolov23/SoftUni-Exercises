window.addEventListener("load", solve);

function solve() {
   
    const divForm = document.querySelector("#form-container");

    const laptopModelInput = divForm.querySelector("#laptop-model");
    const storageInput = divForm.querySelector("#storage");
    const priceInput = divForm.querySelector("#price");

    const addButton = divForm.querySelector("#add-btn");
    addButton.addEventListener("click", addLaptop);

    const checkListULElement = document.querySelector("#check-list");
    const laptopsListUlElement = document.querySelector("#laptops-list");

    const clearButton = document.querySelector(".btn.clear");
    clearButton.addEventListener("click", () => {
      location.reload();
    });

    function addLaptop(event){
      event.preventDefault();
      event.stopPropagation();

      if(laptopModelInput.value === "" || storageInput.value === "" || priceInput.value === ""){
        return;
      }

      const laptopModel = laptopModelInput.value;
      const storage = storageInput.value;
      const price = priceInput.value;

      const liElement = document.createElement("li");
      liElement.classList.add("laptop-item");

      const editButton = document.createElement("button");
      editButton.classList.add("btn", "edit");
      editButton.textContent = "edit";

      editButton.addEventListener("click", () => {
        laptopModelInput.value = laptopModel;
        storageInput.value = storage;
        priceInput.value = price;

        checkListULElement.removeChild(liElement);
        addButton.disabled = false;
      });

      const okButton = document.createElement("button");
      okButton.classList.add("btn", "ok");
      okButton.textContent = "ok";

      okButton.addEventListener("click", () => {

        const laptopLiElement = document.createElement("li");
        laptopLiElement.classList.add("laptop-item");
        laptopLiElement.appendChild(createArticleElement(laptopModel, storage, price));
        laptopsListUlElement.appendChild(laptopLiElement);

        checkListULElement.removeChild(liElement);
        addButton.disabled = false;
      });

      liElement.appendChild(createArticleElement(laptopModel, storage, price));
      liElement.appendChild(editButton);
      liElement.appendChild(okButton);

      checkListULElement.appendChild(liElement);

      clearInputs();

      addButton.disabled = true;
    }

    function clearInputs(){
      laptopModelInput.value = "";
      storageInput.value = "";
      priceInput.value = "";
    }

    function createArticleElement(laptopModel, storage, price){
      const articleElement = document.createElement("article");

      const laptopModelParagraph = document.createElement("p");
      laptopModelParagraph.textContent = laptopModel;

      const storageParagraph = document.createElement("p");
      storageParagraph.textContent = `Memory: ${storage} TB`;

      const priceParagraph = document.createElement("p");
      priceParagraph.textContent = `Price: ${Number(price)}$`;

      articleElement.appendChild(laptopModelParagraph);
      articleElement.appendChild(storageParagraph);
      articleElement.appendChild(priceParagraph);

      return articleElement;
    }

  }
  