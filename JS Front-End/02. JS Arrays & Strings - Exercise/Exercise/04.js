function solve(array){

    array.sort((a, b) => a - b);
    let resultArray = []; 
    const halfLength = array.length/2;

    for(let i = 0; i < halfLength; i++){

        resultArray.push(array[i]);

        if(i+1 > halfLength) break;

        resultArray.push(array[array.length - 1 - i]);
    }
    return resultArray;

}

solve([1, 65, 3, 52, 48, 63, 31, -3, 18, 56,100]);