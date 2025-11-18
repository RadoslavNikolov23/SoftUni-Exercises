function solve() {
  
  const textArea = document.getElementById('input');
  const outputArea = document.getElementById('output');
  const arraySentance = textArea.value
                                .split('.')
                                .map((s) => s.trim())
                                .filter(s => s !== '' && s.length > 0);
                                 
  for(let i = 0; i < arraySentance.length; i+=3){

    let result = [];
    result.push(arraySentance.slice(i, i + 3)
                             .join('. ') + '.');  

    let p = document.createElement('p');

    p.textContent = result;
    outputArea.appendChild(p);
  }

}