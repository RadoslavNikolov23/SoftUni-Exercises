function solve() {
  const inputText = document.getElementById(`searchText`).value;
  const allTowns = document.getElementById(`towns`);
  const resultDiv = document.getElementById(`result`);

  const matchTowns = [];
  for (const town of allTowns.children) {
    if (inputText !== "" && town.textContent.includes(inputText)) {
      town.style.fontWeight = "bold";
      town.style.textDecoration = "underline";
      matchTowns.push(town);
    }
    else{
      town.style.fontWeight = "";
      town.style.textDecoration = "";

   }
  }

   resultDiv.textContent = `${matchTowns.length} matches found`;
}
