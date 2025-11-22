function solve(inputStr) {
    let numbersRegister = {};

    for(const line of inputStr){
        let elements=[];
        const parseInput = JSON.parse(line);

        for(let i=0;i<parseInput.length;i++){
            let num = Number(parseInput[i]);
            elements.push(num);
        }

        elements.sort((a,b)=>b-a);

        if(!numbersRegister.hasOwnProperty(elements)){
            numbersRegister[elements]=elements;
        }
    }

    let uniqueArrays = Object.values(numbersRegister);
    uniqueArrays.sort((a,b)=>a.length-b.length);
    
    for(const elements of uniqueArrays){
        console.log(`[${elements.join(', ')}]`);
    }
}

solve([
  "[-3, -2, -1, 0, 1, 2, 3, 4]",
  "[10, 1, -17, 0, 2, 13]",
  "[4, -3, 3, -2, 2, -1, 1, 0]",
]);
solve([
  "[7.14, 7.180, 7.339, 80.099]",
  "[7.339, 80.0990, 7.140000, 7.18]",
  "[7.339, 7.180, 7.14, 80.099]",
]);
