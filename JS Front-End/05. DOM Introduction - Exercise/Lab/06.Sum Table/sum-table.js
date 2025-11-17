function sumTable() {
    
    const tableEl = document.querySelectorAll('table tbody tr td:nth-child(even)');
    
    let tableArry = Array.from(tableEl);
    const sum = tableArry.pop();

    let total = 0;

    for (let el of tableArry) {
        total += Number(el.textContent);
    }
    sum.textContent = total;

}