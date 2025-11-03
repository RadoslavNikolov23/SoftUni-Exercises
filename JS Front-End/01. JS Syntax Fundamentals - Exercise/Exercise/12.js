function solve(number, ...operations) {
    let num = Number(number);
    for (let operation of operations) {
        if (operation === 'chop') {
            num /= 2;
        }
        else if (operation === 'dice') {
            num = Math.sqrt(num);
        }
        else if (operation === 'spice') {
            num += 1;
        }
        else if (operation === 'bake') {
            num *= 3;
        }
        else if (operation === 'fillet') {
            num *= 0.8;
        }
        
        let result = num % 1 === 0 ? num : num.toFixed(1);
        console.log(result);
    }

}
solve('32', 'chop', 'chop', 'chop', 'chop', 'chop');
solve('9', 'dice', 'spice', 'chop', 'bake', 'fillet');




