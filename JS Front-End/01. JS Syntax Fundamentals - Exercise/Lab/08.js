function solve(number){
    if(typeof number !== 'number'){
        console.log(`We can not calculate the circle area, because we receive a ${typeof(number)}.`);
    }
    else{
        let area = Math.PI * (number * number);
        console.log(area.toFixed(2));
    }

}

solve(5);
solve('name');