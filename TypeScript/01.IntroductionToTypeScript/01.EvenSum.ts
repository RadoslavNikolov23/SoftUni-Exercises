function isEvenSum(numberOne:number,numberTwo:number,numberThree:number):boolean{
    const sum=numberOne+numberTwo+numberThree;
    return sum%2===0;
}

console.log(isEvenSum(1,2,3));
console.log(isEvenSum(2,2,4));
console.log(isEvenSum(1,1,1));
