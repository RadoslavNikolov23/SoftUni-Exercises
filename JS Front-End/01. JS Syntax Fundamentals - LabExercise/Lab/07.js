function solve(typeDay, age){

    let price = 0;

    if (age < 0 || age > 122) {
        console.log('Error!');
        return;
    }

    switch(typeDay){
        case 'Weekday':
            if (age >= 0 && age <= 18) {
                price = 12;
            } else if (age <= 64) {
                price = 18;
            } else {
                price = 12;
            }
            break;
        case 'Weekend':
            if (age >= 0 && age <= 18) {
                price = 15;
            } else if (age <= 64) {
                price = 20;
            } else {
                price = 15;
            }
            break;
        case 'Holiday':
            if (age >= 0 && age <= 18) {
                price = 5;
            } else if (age <= 64) {
                price = 12;
            } else {
                price = 10;
            }
            break;
        default:
            console.log('Error!');
            return;
    }

    console.log(`${price}$`);

}


solve('Weekday', 42);		
solve('Holiday', -12);
solve('Holiday', 15);

