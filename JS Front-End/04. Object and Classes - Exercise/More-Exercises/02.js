function solve(inputArray){

    const orderProducts = inputArray.sort((a, b) => {
        let [nameA, ] = a.split(' : ');
        let [nameB, ] = b.split(' : ');

        return nameA.toLowerCase().localeCompare(nameB.toLowerCase());
    });

    const productsByLetter = {};

    for(const product of orderProducts){
        let [name, price] = product.split(' : ');
        let firstLetter = name[0];

        if(!productsByLetter.hasOwnProperty(firstLetter)){
            productsByLetter[firstLetter] = [];
        }

        productsByLetter[firstLetter].push({name, price});
    }

    for(const letter in productsByLetter){
        console.log(letter);
        
        for(const product of productsByLetter[letter]){
            console.log(`  ${product.name}: ${product.price}`);
        }
    }

}

solve([
    'Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10'
    ]);

solve([
    'Omlet : 5.4',
    'Shirt : 15',
    'Cake : 59'
    ]);