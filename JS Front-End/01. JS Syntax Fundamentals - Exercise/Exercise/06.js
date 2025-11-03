function solve(number){
    let result = 0;

    for(let digit of number.toString()){
        result += Number(digit);
    }

    console.log(result);
}

solve(245678);
solve(97561);
solve(543);
