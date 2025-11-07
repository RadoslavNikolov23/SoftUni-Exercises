function smallestNumber(numOne, numTwo, numThree) {
  if (numOne === undefined || numTwo === undefined || numThree === undefined) {
    console.log("Please provide three numbers.");
    return;
  }

  let smallest = numOne;

  if (numTwo < smallest) {
    smallest = numTwo;
  }

  if (numThree < smallest) {
    smallest = numThree;
  }

  console.log(smallest);
}

smallestNumber(2, 5, 3);
smallestNumber(600, 342, 123);
smallestNumber(25, 21, 4);
smallestNumber(2, 2, 2);
