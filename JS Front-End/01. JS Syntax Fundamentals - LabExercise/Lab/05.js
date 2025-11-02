function solve(numOne, numTwo, operator){
    let result = 0;

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
        case '%':
            result = numOne % numTwo;
            break;
        case '**':
            result = numOne ** numTwo;
            break;
        default:
            console.log("Invalid operator");
            return;
    }

    console.log(result);
}


solve(5, 6, '+');
solve(3, 5.5, '*');
solve(3, 5.5, '&');