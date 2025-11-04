function solve(lostFightsCount, helmetPrice, swordPrice, shieldPrice, armorPrice) {

    if ((lostFightsCount < 0 || lostFightsCount > 1000)
        || (helmetPrice < 0 || helmetPrice > 1000)
        || (swordPrice < 0 || swordPrice > 1000)
        || (shieldPrice < 0 || shieldPrice > 1000)
        || (armorPrice < 0 || armorPrice > 1000)) {
        return;
    }

    let totalExpenses = 0;
    let shieldBrakenCount = 0;

    for (let fight = 1; fight <= lostFightsCount; fight++) {

        if (fight % 2 === 0) {
            totalExpenses += helmetPrice;
        }
        if (fight % 3 === 0) {
            totalExpenses += swordPrice;
        }

        if (fight % 2 === 0 && fight % 3 === 0) {
            totalExpenses += shieldPrice;
            shieldBrakenCount++;

            if (shieldBrakenCount === 2) {
                totalExpenses += armorPrice;
                shieldBrakenCount = 0;
            }
        }

    }

    console.log(`Gladiator expenses: ${totalExpenses.toFixed(2)} aureus`);


}

solve(7, 2, 3, 4, 5);
solve(23, 12.50, 21.50, 40, 200);
