
type InputParameterType<T> = T  extends number ? number : string;

function conditionalNumber<T >(item:InputParameterType<T> ):void{
    if(typeof item === 'number'){
        console.log(item.toFixed(2))
    }
    else{
        console.log(item);
    }
}

conditionalNumber<number>(20.3555);
conditionalNumber<string>('wow');
conditionalNumber<boolean>('a string');

//These shoudl return erros
//conditionalNumber<boolean>(30);
//conditionalNumber<number>('test');
