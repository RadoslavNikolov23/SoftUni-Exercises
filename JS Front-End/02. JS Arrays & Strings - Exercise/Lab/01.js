/**
 * 
 * @param {array} array 
 */


function solve(array){
    const firstElem = array.shift();
    const lastElem = array.pop();

    if(firstElem !== undefined && lastElem !== undefined){
        console.log(firstElem + lastElem);
    }

}


solve([20, 30, 40]);
solve([10, 17, 22, 33]);
solve([11, 58, 69]);



