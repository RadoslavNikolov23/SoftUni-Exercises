function colorize() {
    
  const tableRowEl = document.querySelectorAll("tbody tr:nth-child(even)");
  
  for (let row of tableRowEl) {
    row.style.backgroundColor = "teal";
  }
}
