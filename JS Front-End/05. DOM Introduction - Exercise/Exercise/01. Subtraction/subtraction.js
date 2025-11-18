function subtract() {

    const firstNumber= Number(document.getElementById("firstNumber").value);
    const secondNumber= Number(document.getElementById("secondNumber").value);
    const result = firstNumber - secondNumber;

    const resultContainer = document.getElementById("result");
    resultContainer.textContent = result;
}