function solve(numOne,numTwo,numThree) {

    const result = subtract(sum(numOne,numTwo),numThree);
    console.log(result);


  function sum(numOne,numTwo) {
    return numOne + numTwo;
  }

  function subtract(numOne,numTwo) {
    return numOne - numTwo;
  }
}

solve(23, 6, 10);
solve(1, 17, 30);
solve(42, 58, 100);
