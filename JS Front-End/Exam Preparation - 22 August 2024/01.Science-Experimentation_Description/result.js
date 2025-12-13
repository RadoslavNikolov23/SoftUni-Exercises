function solve(inputArrat) {
    
    class Chemical {
        constructor(name, quantity) {
            this.name = name;

            if(quantity > 500) {
                this.quantity = 500;
            } else if(quantity < 0) {
                this.quantity = 0;
            } else
            this.quantity = quantity;
            
        }

        replenish(amount) {
            let before = this.quantity;
            this.quantity += amount;
            if (this.quantity > 500) {
                let added = 500 - before;
                this.quantity = 500;
                return { capped: true, added };
            }
            return { capped: false, added: amount };
        }

        mix(amount) {
            if (this.quantity >= amount) {
                return true;
            }
            return false;
        }

        addFormula(formula) {
            this.formula = formula;
        }

        toString() {
            let result = `Chemical: ${this.name}, Quantity: ${this.quantity}`;
            if (this.formula) {
                result += `, Formula: ${this.formula}`;
            }
            return result;
        }
    }

    const chemicals = new Map();

    const numberOfChemicals = Number(inputArrat.shift());

    for(let i=0; i<numberOfChemicals; i++) {
        const [name, quantity] = inputArrat.shift().split(' # ');
        chemicals.set(name, new Chemical(name, Number(quantity)));
    }

    let commandLine = inputArrat.shift();

    while(commandLine !== 'End') {
        const parts = commandLine.split(' # ');
        const command = parts[0];
        const chemicalName = parts[1];

        if(command === 'Mix') {

            const chemicalNameTwo = parts[2];
            const amount = Number(parts[3]);

            if(chemicals.has(chemicalName) && chemicals.has(chemicalNameTwo)){
                const chemOne = chemicals.get(chemicalName);
                const chemTwo = chemicals.get(chemicalNameTwo);
    
                if (chemOne.mix(amount) && chemTwo.mix(amount)) {
                    chemOne.quantity -= amount;
                    chemTwo.quantity -= amount;
                    console.log(`${chemicalName} and ${chemicalNameTwo} have been mixed. ${amount} units of each were used.`);
                } else {
                    console.log(`Insufficient quantity of ${chemicalName}/${chemicalNameTwo} to mix.`) ;
                }
            }
        }else if(command === 'Replenish') {

            const amount = Number(parts[2]);

            if(!chemicals.has(chemicalName)) {
                console.log(`The Chemical ${chemicalName} is not available in the lab.`);
            }else{
                const result = chemicals.get(chemicalName).replenish(amount);
                if (result.capped) {
                    console.log(`${chemicalName} quantity increased by ${result.added} units, reaching maximum capacity of 500 units!`);
                } else {
                    console.log(`${chemicalName} quantity increased by ${result.added} units!`);
                }
            }
            
        } else if(command === 'Add Formula') {
            const formula = parts[2];
            if(!chemicals.has(chemicalName)) {
                console.log(`The Chemical ${chemicalName} is not available in the lab.`);
            }else{
                chemicals.get(chemicalName).addFormula(formula);
                console.log(`${chemicalName} has been assigned the formula ${formula}.`);
            }
        }

        commandLine = inputArrat.shift();
    }

    for(const chemical of chemicals.values()) {
        console.log(chemical.toString());
    }


}

solve([ '4',
'Water # 200',
'Salt # 100',
'Acid # 50',
'Base # 80',
'Mix # Water # Salt # 50',
'Replenish # Salt # 150',
'Add Formula # Acid # H2SO4',
'End']
);

solve([ '3',
'Sodium # 300',
'Chlorine # 100',
'Hydrogen # 200',
'Mix # Sodium # Chlorine # 200',
'Replenish # Sodium # 250',
'Add Formula # Sulfuric Acid # H2SO4',
'Add Formula # Sodium # Na',
'Mix # Hydrogen # Chlorine # 50',
'End']
);