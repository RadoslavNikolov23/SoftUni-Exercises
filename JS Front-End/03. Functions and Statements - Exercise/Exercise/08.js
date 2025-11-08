function perfectNumber(number) {

  function isPerfectNumber(number) {
    let sum = 0;
    
    for (let i = 1; i <= number / 2; i++) {
      if (number % i === 0) {
        sum += i;
      }
    }
    return sum === number;
  }

  const isPerfect = isPerfectNumber(number);

  if (isPerfect) {
    console.log("We have a perfect number!");
  } else {
    console.log("It's not so perfect.");
  }
}

perfectNumber(6);
perfectNumber(28);
perfectNumber(1236498);
