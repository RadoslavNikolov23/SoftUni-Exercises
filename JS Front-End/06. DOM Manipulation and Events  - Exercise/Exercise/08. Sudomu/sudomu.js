document.addEventListener("DOMContentLoaded", solve);

function solve() {
  const sizeTable = document.querySelector("#size");

  sizeTable.addEventListener("change", onClick);

  function onClick(event) {
    event.preventDefault();
    event.stopPropagation();

    const sizeTableValue = Number(sizeTable.value);
    const tableBodyEl = document.querySelector("form#solutionCheck table tbody");

        for (let row = tableBodyEl.rows.length - 1; row >= 0; row--) {
      tableBodyEl.deleteRow(row);
    }

    for (let row = 0; row < sizeTableValue; row++) {
      const trEl = document.createElement("tr");
      for (let col = 0; col < sizeTableValue; col++) {
        const tbEl = document.createElement("td");
        const inputEl = document.createElement("input");
        inputEl.step = "1";
        inputEl.min = "1";
        inputEl.max = "3";
        inputEl.type = "number";
        inputEl.required = true;
        tbEl.appendChild(inputEl);
        trEl.appendChild(tbEl);
      }
        tableBodyEl.appendChild(trEl);
    }
  }

  const quickCheckBtnEl = document.querySelector('form#solutionCheck div.buttons input[type="submit"]');
  quickCheckBtnEl.addEventListener("click", checkNumbers);

  function checkNumbers(event) {
    event.preventDefault();
    event.stopPropagation();

    const tableEl = document.querySelector("form#solutionCheck table");
    const sizeTableValue = Number(sizeTable.value);
    const matrix = [];

    for (let row = 0; row < sizeTableValue; row++) {
      const currentRow = [];
      for (let col = 0; col < sizeTableValue; col++) {
        const cellValue = Number(
          tableEl.rows[row].cells[col].firstElementChild.value
        );
        currentRow.push(cellValue);
      }
      matrix.push(currentRow);
    }
    let isSudomu = true;

    for (let i = 0; i < sizeTableValue; i++) {
      const rowSet = new Set();
      const colSet = new Set();
      for (let j = 0; j < sizeTableValue; j++) {
        rowSet.add(matrix[i][j]);
        colSet.add(matrix[j][i]);
      }
      if (rowSet.size !== sizeTableValue || colSet.size !== sizeTableValue) {
        isSudomu = false;
        break;
      }
    }

    const outputCheckEl = document.querySelector("p#check");
    if (isSudomu) {
      outputCheckEl.textContent = "Success!";
      tableEl.style.border = "2px solid green";
    } else {
      outputCheckEl.textContent = "Keep trying...";
      tableEl.style.border = "2px solid red";
    }
  }

  const resetBtnEl = document.querySelector('form#solutionCheck div.buttons input[type="reset"]');
  resetBtnEl.addEventListener("click", resetBoard);

  function resetBoard(event) {
    event.preventDefault();
    event.stopPropagation();

    const tableEl = document.querySelector("form#solutionCheck table");
    tableEl.style.border = "";
    const outputCheckEl = document.querySelector("p#check");
    outputCheckEl.textContent = "";

    const sizeTableValue = Number(sizeTable.value);

    for (let row = 0; row < sizeTableValue; row++) {
      for (let col = 0; col < sizeTableValue; col++) {
        tableEl.rows[row].cells[col].firstElementChild.value = "";
      }
    }
  }
}
