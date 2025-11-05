/**
 * 
 * @param {string} input 
 * @param {*} starNum 
 * @param {*} countNum 
 */


function solve(input,starNum,countNum){

    const substring = input.slice(starNum,countNum+starNum);
    console.log(substring);
}

solve('ASentence', 1, 8);
solve('SkipWord', 4, 7);
