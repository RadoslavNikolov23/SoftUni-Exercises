function solve() {
  
    const inputElement = document.getElementById('input');
    const number = parseFloat(inputElement.value);

    const selectMenuElement = document.getElementById('selectMenuTo');

    let result ='';

    if(selectMenuElement.value === 'binary'){
        result = number.toString(2);
    } else if(selectMenuElement.value === 'hexadecimal'){
        result = number.toString(16).toUpperCase();
    }

    const resultElement = document.getElementById('result');
    resultElement.value = result;


}