/**
 * 
 * @param {number} elemNumber 
 * @param {array} arrayOriginal 
 */


function solve(elemNumber,arrayOriginal){
   
    let resultArray= arrayOriginal.slice(0,elemNumber);

    console.log(resultArray.reverse().join(' '));

}

solve(3, [10, 20, 30, 40, 50]);
solve(4, [-1, 20, 99, 5]);
solve(2, [66, 43, 75, 89, 47]);
