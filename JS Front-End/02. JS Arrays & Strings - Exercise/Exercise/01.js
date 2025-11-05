/**
 * 
 * @param {array} array 
 * @param {number} number 
 */

function solve(array, number) {
    const length = array.length;
    number = number % length;

    for (let i = 0; i < number; i++) {
        let element = array.shift();
        array.push(element);
    }

    console.log(array.join(' '));
}

solve([51, 47, 32, 61, 21], 2);
solve([32, 21, 61, 1], 4);
solve([2, 4, 15, 31], 5);