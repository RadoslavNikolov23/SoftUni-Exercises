function solve(numOne, numTwo, numThree) {

    let largest = 0;

    if (numOne >= numTwo && numOne >= numThree) {
        largest = numOne;
    }
    else if (numTwo >= numOne && numTwo >= numThree) {
        largest = numTwo;
    }
    else {
        largest = numThree;
    }

    console.log(`The largest number is ${largest}.`);

}

solve(5, -3, 16);
solve(-3, -5, -22.5);
solve(3, 3, 3);
solve(10, 20, 15);

