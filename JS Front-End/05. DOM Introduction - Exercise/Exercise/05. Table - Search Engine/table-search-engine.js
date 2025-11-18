function solve() {
   const tableBody = document.querySelector('tbody');
   const seatchText = document.getElementById('searchField').value;


   for(let row of tableBody.rows){

      for(let cell of row.cells){
         if(seatchText !== '' && cell.textContent.toLowerCase().includes(seatchText.toLowerCase())){
            row.classList.add('select');
            break;
         }
         else{
            row.classList.remove('select');
         }
      }
   }
}