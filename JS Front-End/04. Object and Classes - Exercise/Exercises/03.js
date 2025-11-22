function solve(productInStock,productToDeliver){

    let storeProvision = {};

    for(let i = 0; i < productInStock.length; i += 2){
        let product = productInStock[i];
        let quantity = Number(productInStock[i + 1]);

        storeProvision[product] = quantity;
    }

    for(let i = 0; i < productToDeliver.length; i += 2){
        let product = productToDeliver[i];
        let quantity = Number(productToDeliver[i + 1]);

        if(storeProvision.hasOwnProperty(product)){
            storeProvision[product] += quantity;
        } else {
            storeProvision[product] = quantity;
        }
    }

    for(let product of Object.keys(storeProvision)){
        console.log(`${product} -> ${storeProvision[product]}`);
    }

}

solve([
    'Chips', '5', 'CocaCola', '9', 'Bananas', '14', 'Pasta', '4', 'Beer', '2'
    ],
    [
    'Flour', '44', 'Oil', '12', 'Pasta', '7', 'Tomatoes', '70', 'Bananas', '30'
    ]
    );

solve([
    'Salt', '2', 'Fanta', '4', 'Apple', '14', 'Water', '4', 'Juice', '5'
    ],
    [
    'Sugar', '44', 'Oil', '12', 'Apple', '7', 'Tomatoes', '7', 'Bananas', '30'
    ]
    );