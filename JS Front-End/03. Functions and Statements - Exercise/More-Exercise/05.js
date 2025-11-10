function solve(number) {
    
    function writeLineOne(charOne, charTwo) {
      console.log(`**${charOne}${charTwo}**`);
    }
    function writeLineTwoAndFour(charOne, charTwo) {
      console.log(`*${charOne}--${charTwo}*`);
    }
    function writeLineThree(charOne, charTwo) {
      console.log(`${charOne}----${charTwo}`);
    }

  const dnaChain = "ATCGTTAGGG";

  let dnaLength = dnaChain.length;
  let firstChar = 0;
  let secondChar = 1;
  for (let i = 0; i < number; i++) {
    if(firstChar >= dnaLength || secondChar >= dnaLength) {
        firstChar = 0;
        secondChar = 1;
    }
    let charOne = dnaChain[firstChar];
    let charTwo = dnaChain[secondChar];

    firstChar+=2;
    secondChar+=2;

    // Use different line formats based on iteration
    if (i % 4 === 0) {
      writeLineOne(charOne, charTwo);
    } else if (i % 4 === 1) {
      writeLineTwoAndFour(charOne, charTwo);
    } else if (i % 4 === 2) {
      writeLineThree(charOne, charTwo);
    } else if (i % 4 === 3) {
      writeLineTwoAndFour(charOne, charTwo);
    }
  }
}

//solve(4);
solve(10);
