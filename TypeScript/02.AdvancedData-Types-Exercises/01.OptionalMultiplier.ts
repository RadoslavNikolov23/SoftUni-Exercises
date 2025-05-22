function optionalMultiplier(parmOne?: string|number, parmTwo?: string|number, parmThree?: string|number, ) : number{
    
    let numberOne:number = parmOne? typeof parmOne === "string"? parseInt(parmOne) : parmOne : 1 ;
    let numberTwo:number = parmTwo? typeof parmTwo === "string"? parseInt(parmTwo) : parmTwo : 1 ;
    let numberThree: number = parmThree? typeof parmThree === "string"? parseInt(parmThree) : parmThree : 1 ;
    
    let result:number = numberOne * numberTwo * numberThree;
    return result;
    
}

console.log(optionalMultiplier('3', 5, '10'));
console.log(optionalMultiplier('2','2'));
console.log(optionalMultiplier(undefined, 2, 3));
console.log(optionalMultiplier(7, undefined, '2'));
console.log(optionalMultiplier(2, 2, 2));
console.log(optionalMultiplier());

