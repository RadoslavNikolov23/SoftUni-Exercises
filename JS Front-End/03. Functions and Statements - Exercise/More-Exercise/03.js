function solve(arrayNumbers) {
    function writeLine(isValid, pointA, pointB) {
        if (isValid) {
          console.log(`{${pointA}} to {${pointB}} is valid`);
        } else {
          console.log(`{${pointA}} to {${pointB}} is invalid`);
        }
      }


      let formula = (numTwoX, numOneX, numTwoY, numOneY) => {
        return Math.sqrt(
          Math.pow(numTwoX - numOneX, 2) + Math.pow(numTwoY - numOneY, 2)
        );
      };

      function pointsValdiation(numOneX, numOneY, numTwoX, numTwoY){
          let result = formula(numTwoX, numOneX, numTwoY, numOneY);
          if(result % 1 === 0){
              writeLine(true, `${numOneX}, ${numOneY}`, `${numTwoX}, ${numTwoY}`);
          }
          else{
              writeLine(false, `${numOneX}, ${numOneY}`, `${numTwoX}, ${numTwoY}`);
          }
      }

    let numOneX = arrayNumbers[0];
    let numOneY = arrayNumbers[1];
    let numTwoX = arrayNumbers[2];
    let numTwoY = arrayNumbers[3];

    pointsValdiation(numOneX, numOneY, 0, 0);
    pointsValdiation(numTwoX, numTwoY, 0, 0);
    pointsValdiation(numOneX, numOneY,numTwoX ,numTwoY);
}


solve([3, 0, 0, 4]);
solve([2, 1, 1, 1]);
