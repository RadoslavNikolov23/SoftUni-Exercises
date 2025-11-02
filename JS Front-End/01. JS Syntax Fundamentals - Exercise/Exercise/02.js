function solve(numberGroup, typeOfGroup, dayOfWeek) {
    let price = 0;

    if (typeOfGroup === "Students") {
        if (dayOfWeek === "Friday") {
            price = 8.45 ;
        } else if (dayOfWeek === "Saturday") {
            price = 9.80 ;
        } else if (dayOfWeek === "Sunday") {
            price = 10.46 ;
        }
    } else if (typeOfGroup === "Business") {
        if (dayOfWeek === "Friday") {
            price = 10.90;
        } else if (dayOfWeek === "Saturday") {
            price = 15.60;
        } else if (dayOfWeek === "Sunday") {
            price = 16;
        }
    } else if (typeOfGroup === "Regular") {
        if (dayOfWeek === "Friday") {
            price = 15;
        } else if (dayOfWeek === "Saturday") {
            price = 20;
        } else if (dayOfWeek === "Sunday") {
            price = 22.50;
        }
    }

    if(typeOfGroup === "Students" && numberGroup >= 30){
        price = price * 0.85;
    }

    if(typeOfGroup === "Business" && numberGroup >= 100){
        numberGroup -= 10;
    }

    if(typeOfGroup === "Regular" && numberGroup >= 10 && numberGroup <= 20){
        price = price * 0.95;
    }

    const finalPrice = numberGroup * price;
    console.log(`Total price: ${finalPrice.toFixed(2)}`);


}

solve(30, "Students", "Sunday");
solve(40, "Regular", "Saturday");