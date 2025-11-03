function solve(number){

    let numberAsString = number.toString();
    let sum = 0;
    let areAllSame = true;

    for(let i = 0; i < numberAsString.length; i++){
        sum += Number(numberAsString[i]);
        
        if(numberAsString[i] !== numberAsString[0]){
            areAllSame = false;
        }
    }

    console.log(areAllSame);
    console.log(sum);
}

solve(2222222);
solve(1234);