function solve(numOne, numTwo) {
    let sum = 0;
    let arrayNumbers = [];

    for (let i = numOne; i <= numTwo; i++) {
        arrayNumbers.push(i);
        sum += i;
    }
    console.log(arrayNumbers.join(" "));
    console.log(`Sum: ${sum}`);
}

solve(5, 10);
solve(0, 26);
solve(50, 60);