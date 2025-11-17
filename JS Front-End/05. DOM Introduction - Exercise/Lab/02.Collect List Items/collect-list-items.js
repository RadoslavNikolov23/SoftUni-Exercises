function extractText() {
   
    const liElements = document.querySelectorAll('#items li');
    const textAreaEl = document.getElementById('result');

    const elArray = Array.from(liElements);
    let result ="";

    for(let el of elArray) {
        result += el.textContent + '\n';
    }
    textAreaEl.value = result.trim();
}
