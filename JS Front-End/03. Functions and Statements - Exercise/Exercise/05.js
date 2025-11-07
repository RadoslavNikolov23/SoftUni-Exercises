/**
 * 
 * @param {arrayNums} arrayNums 
 */

function solve(arrayNums) {

    /**
     * 
     * @param {number} number 
     * @returns 
     */

    function checkIfPalendrom(number){
        const strNum = number.toString();

        for(let i=0;i<strNum.length/2;i++){
            if(strNum[i]!==strNum[strNum.length-1-i]){
                return false;
            }
        }
        return true;

    }

    for(let number of arrayNums){
        console.log(checkIfPalendrom(number) ? "true" : "false");
    }

}

solve([123,323,421,121]);
solve([32,2,232,1010]);