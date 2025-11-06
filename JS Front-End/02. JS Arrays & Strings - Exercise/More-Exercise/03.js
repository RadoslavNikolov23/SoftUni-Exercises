function solve(baseWidLen, heightStep) {

    let totalStones = 0;
    let totalMarble = 0;
    let totalLapis = 0;
    let totalGold = 0;

    let currentHeight = 0;

    let stepCount = 0;
    for (let i = baseWidLen; i > 0; i -= 2) {
        currentHeight++;
        stepCount++;
        if (i > 2) {
            let stoneAmount = (i - 2) * (i - 2) * heightStep;
            totalStones += stoneAmount;

            if (stepCount === 5) {
                let lapisAmount = (i * i - (i - 2) * (i - 2)) * heightStep;
                totalLapis += lapisAmount;

                stepCount = 0;
            } else {
                let marbleAmount = (i * i - (i - 2) * (i - 2)) * heightStep;
                totalMarble += marbleAmount;
            }


        }
        else {
            let goldAmount = i * i * heightStep;
            totalGold += goldAmount;
            break;
        }

    }

    console.log(`Stone required: ${Math.ceil(totalStones)}`);
    console.log(`Marble required: ${Math.ceil(totalMarble)}`);
    console.log(`Lapis Lazuli required: ${Math.ceil(totalLapis)}`);
    console.log(`Gold required: ${Math.ceil(totalGold)}`);
    console.log(`Final pyramid height: ${Math.floor(currentHeight * heightStep)}`);

}


//stone, marble, lapis lazuli, and gold

solve(11, 1);
solve(11, 0.75);
solve(12, 1);
solve(23, 0.5);