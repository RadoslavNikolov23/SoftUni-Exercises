function calc() {
    
    const inputOneEl = document.getElementById('num1');
    const inputTwoEl = document.getElementById('num2');

    const sum = Number(inputOneEl.value) + Number(inputTwoEl.value);

    const sumEl = document.getElementById('sum');
    sumEl.value = sum;

}