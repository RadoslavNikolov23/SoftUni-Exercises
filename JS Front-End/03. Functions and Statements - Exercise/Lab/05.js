function simpleCalulator(numOne,numTwo,operator){

    let result = {
        'multiply': numOne * numTwo,
        'divide': numOne / numTwo,
        'add': numOne + numTwo,
        'subtract': numOne - numTwo
    }

    console.log(result[operator]);

    // switch(operator){
    //     case 'multiply':
    //         console.log(numOne * numTwo);
    //         break;
    //     case 'divide':
    //         console.log(numOne / numTwo);
    //         break;
    //     case 'add':
    //         console.log(numOne + numTwo);
    //         break;
    //     case 'subtract':
    //         console.log(numOne - numTwo);
    //         break;
    // }

}

simpleCalulator(5,5,'multiply');
simpleCalulator(40,8,'divide');
simpleCalulator(12,19,'add');
simpleCalulator(50,13,'subtract');