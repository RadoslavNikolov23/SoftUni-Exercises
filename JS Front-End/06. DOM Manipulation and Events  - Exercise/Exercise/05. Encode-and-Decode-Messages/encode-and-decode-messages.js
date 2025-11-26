document.addEventListener("DOMContentLoaded", solve);

function solve() {

  function encodeMessage(message, shift) {
    let encodeMessage = "";

    for (let char of message) {
      encodeMessage += String.fromCharCode(char.charCodeAt(0) + shift);
    }
    return encodeMessage;
  }


  const btnEncodeElement = document.querySelector("form#encode button");
  btnEncodeElement.addEventListener("click", (event) => encodeEvent(event,1));

  const btnDecodeElement = document.querySelector("form#decode button");
  btnDecodeElement.addEventListener("click", (event) => encodeEvent(event,-1));

  function encodeEvent(event,shift) {
    event.preventDefault();
    event.stopPropagation();

    const formELId =event.target.parentElement.id;
    const textAreaEl = document.querySelector(`form#${formELId} textarea`);
    
    const message = encodeMessage(textAreaEl.value, shift);

    const outputTextAreaEl = document.querySelector("form#decode textarea");
    outputTextAreaEl.value = message;

    const inputTextAreaEl = document.querySelector("form#encode textarea");

    inputTextAreaEl.value = "";
  }
}
