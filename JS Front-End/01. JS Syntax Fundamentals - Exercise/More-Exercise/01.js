function solve(numOneX, numOneY, numTwoX, numTwoY) {

    let result = Math.sqrt(Math.pow((numOneX - 0),2) + Math.pow((numOneY - 0),2));

    if(result % 1 === 0){
        console.log(`{${numOneX}, ${numOneY}} to {${0}, ${0}} is valid`);
    }
    else{
        console.log(`{${numOneX}, ${numOneY}} to {${0}, ${0}} is invalid`);
    }

    result = Math.sqrt(Math.pow((numTwoX - 0),2) + Math.pow((numTwoY - 0),2));

    if(result % 1 === 0){
        console.log(`{${numTwoX}, ${numTwoY}} to {${0}, ${0}} is valid`);
    }
    else{
        console.log(`{${numTwoX}, ${numTwoY}} to {${0}, ${0}} is invalid`);
    }

    result = Math.sqrt(Math.pow((numTwoX - numOneX),2) + Math.pow((numTwoY - numOneY),2));

    if(result % 1 === 0){
        console.log(`{${numOneX}, ${numOneY}} to {${numTwoX}, ${numTwoY}} is valid`);
    }
    else{
        console.log(`{${numOneX}, ${numOneY}} to {${numTwoX}, ${numTwoY}} is invalid`);
    }

}


solve(3, 0, 0, 4);

solve(2, 1, 1, 1);
