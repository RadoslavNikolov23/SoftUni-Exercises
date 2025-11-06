function signCheck(...numbers){

    let result = 'Positive';

    for(let num of numbers){
        if(num < 0){
            result = result === 'Positive' ? 'Negative' : 'Positive';
        }
    }

    console.log(result);

}

signCheck( 5,12,-15);
signCheck(-6,-12,14);
signCheck(-1,-2,-3);
signCheck(-5,1,1);