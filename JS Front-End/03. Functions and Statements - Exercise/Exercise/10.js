function factorialDevision(numOne, numTwo){

    function factorialCalcul(number){

        if(number === 0 || number === 1){
            return 1;
        }
        let sum = factorialCalcul(number - 1) * number;
        return sum;
    }

    const result = factorialCalcul(numOne) / factorialCalcul(numTwo);
    console.log(result.toFixed(2));

}

factorialDevision(5,2);
factorialDevision(6,2);
