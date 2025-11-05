/**
 * 
 * @param {array} array 
 */
function solve(array) {

    array.sort((a, b) => a.toLowerCase().localeCompare(b.toLowerCase()));

    for(let i = 0; i < array.length; i++){
        console.log(`${i + 1}.${array[i]}`);
    }
}

solve(["John", "Bob", "Christina", "Ema"]);