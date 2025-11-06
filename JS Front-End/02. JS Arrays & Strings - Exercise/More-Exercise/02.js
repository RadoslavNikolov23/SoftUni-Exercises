function solve(goldInput) {

    const goldPricePerGram = 67.51;
    const bitcoinPrice = 11949.16;
    let dayOfFirstPurchase = 0;
    let countBitcoins = 0;

    let totalGold = 0;
    let countRotations = 0;
    for (let i = 0; i < goldInput.length; i++) {
        countRotations++;

        if (countRotations === 3) {
            totalGold += goldInput[i] * 0.7;
            countRotations = 0;
        }
        else {
            totalGold += goldInput[i];
        }

        while (totalGold * goldPricePerGram >= bitcoinPrice) {
            if (dayOfFirstPurchase === 0)
                dayOfFirstPurchase = i+1;
            totalGold -= bitcoinPrice / goldPricePerGram;
            countBitcoins++;
        }
    }

    console.log(`Bought bitcoins: ${countBitcoins}`);

    if (dayOfFirstPurchase !== 0) {
        console.log(`Day of the first purchased bitcoin: ${dayOfFirstPurchase}`);
    }

    console.log(`Left money: ${(totalGold * goldPricePerGram).toFixed(2)} lv.`);

}

solve([100, 200, 300]);
solve([50, 100]);
solve([3124.15, 504.212, 2511.124]);
