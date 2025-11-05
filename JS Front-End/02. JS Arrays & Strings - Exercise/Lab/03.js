function solve(aray) {
    let resultOdd = 0;
    let resultEven = 0;

    for (let i = 0; i < aray.length; i++) {

        if (aray[i] % 2 === 0)
            resultEven += aray[i];
        else
            resultOdd += aray[i];
    }

    console.log(resultEven - resultOdd);

}


solve([1, 2, 3, 4, 5, 6]);
solve([3, 5, 7, 9]);
solve([2, 4, 6, 8, 10]);
