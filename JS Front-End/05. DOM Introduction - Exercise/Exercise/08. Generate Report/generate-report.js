function solve() {
  
    let reportObj = {};
    const tableEl = document.querySelector('table');
    const tableHeads = tableEl.querySelectorAll('thead th');

    for(let i=0;i< tableHeads.length;i++){
        
        if(tableHeads[i].innerHTML.includes(`checked`)){
            reportObj[tableHeads[i].textContent.toLowerCase().trim()] = [i];
        }
    }

    const tableRows = tableEl.querySelectorAll('tbody tr');

    for(const row of tableRows){
        const rowCells = row.querySelectorAll('td');

        for(const key in reportObj){
            const cellIndex = reportObj[key][0];
            const cellValue = rowCells[cellIndex].textContent.trim();

            reportObj[key].push(cellValue);
        }
    }

    let finalReport = {};
    for(let i=1; i< reportObj[Object.keys(reportObj)[0]].length;i++){
        let entry = {};
        for(const key in reportObj){
            entry[key] = reportObj[key][i];
        }
        finalReport[i] = entry;
    }

    let reportValues = Object.values(finalReport);
    let result = JSON.stringify(reportValues);

    let outputEl = document.getElementById('output');
    outputEl.value = result;
}