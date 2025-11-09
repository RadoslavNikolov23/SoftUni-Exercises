function numebrModification(number){

    let numberString = number.toString();
    let totalSum = 0;
    for(let i = 0; i < numberString.length; i++){
        totalSum +=Number(numberString[i]);
    }

    while(totalSum / numberString.length <= 5){
        numberString += '9';
        totalSum +=9;
    }

    console.log(Number(numberString));
}

numebrModification(101);
numebrModification(5835);