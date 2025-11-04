function solve(startYield) {
    let totalSpices = 0;
    let days = 0;

    while (startYield >= 100) {
        totalSpices += startYield;
        startYield -= 10;
        totalSpices -= 26;
        days++;
    }
    if (totalSpices >= 26) {
        totalSpices -= 26;
    }
    else {
        totalSpices = 0;
    }

    console.log(days);
    console.log(totalSpices);

}

solve(111);
solve(450);