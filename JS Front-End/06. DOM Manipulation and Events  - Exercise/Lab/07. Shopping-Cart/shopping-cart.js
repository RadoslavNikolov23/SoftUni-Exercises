document.addEventListener("DOMContentLoaded", solve);

function solve() {

   let totalPrice = 0;
   let listItems = new Set();
   
   const addButtons = document.getElementsByClassName("add-product");
  for (let button of addButtons) {
    button.addEventListener("click", addElementToShoppingCart);
  }

  function addElementToShoppingCart(event) {

    const product = event.target.parentElement.parentElement;
    const name = product.querySelector(".product-title").textContent;
    const price = product.querySelector(".product-line-price").textContent;

    const textOutput = `Added ${name} for ${Number(price).toFixed(2)} to the cart.\n`;
    const textArea = document.querySelector("textarea");
    textArea.value += textOutput;

    listItems.add(name);
    totalPrice += Number(price);
  }

  const checkoutButton = document.querySelector(".checkout");
  checkoutButton.addEventListener("click", checkout);

  function checkout(event) {
    const textArea = document.querySelector("textarea");
    textArea.value += `You bought ${Array.from(listItems).join(", ")} for ${totalPrice.toFixed(2)}.`;
   
    const addButtons = document.getElementsByClassName("add-product");
    
    for (let button of addButtons) {
      button.disabled = true;
    }

    checkoutButton.disabled = true;
  }
}
