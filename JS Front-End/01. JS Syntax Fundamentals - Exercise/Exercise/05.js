function solve(number){

    for(let times = 1; times <= 10; times++){
        let result = number * times;
        
        console.log(`${number} X ${times} = ${result}`);
    }

}

solve(5);
solve(2);