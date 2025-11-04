function solve(numOne,operator,numTwo){
    let result;
    switch(operator){
        case '+':
            result = numOne + numTwo;
            break;
        case '-':
            result = numOne - numTwo;
            break;
        case '*':
            result = numOne * numTwo;
            break;
        case '/':
            result = numOne / numTwo;
            break;
        default:
            console.log('Invalid operator');
            return;
    }
    console.log(result.toFixed(2));
}

solve(5,'+',10);
solve(25.5,'-',3);
solve(6,'*',7);
solve(20,'/',5);