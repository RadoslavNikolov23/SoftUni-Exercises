function carWash(arrayCommands){

    let carCleanliness = 0;

    for (let command of arrayCommands) {
        switch (command) {
            case 'soap':
                carCleanliness += 10;
                break;
            case 'water':
                carCleanliness += carCleanliness * 0.2;
                break;
            case 'vacuum cleaner':
                carCleanliness += carCleanliness * 0.25;
                break;
            case 'mud':
                carCleanliness -= carCleanliness * 0.1;
                break;
        }
    }

    console.log(`The car is ${carCleanliness.toFixed(2)}% clean.`);
}

carWash(['soap', 'soap', 'vacuum cleaner', 'mud', 'soap', 'water']);
carWash(["soap", "water", "mud", "mud", "water", "mud", "vacuum cleaner"]);


