type Operator =  'power' | 'log' | 'add' | 'subtract' | 'multiply' | 'divide';

interface ICalculator{
    calculate(operation:'add' | 'subtract' | 'multiply' | 'divide', 
              numberOne:number, numberTwo:number,
              numberThree?:number, numberFour?:number):number;

}

class Calculator implements ICalculator {

    public calculate(operation: 'power' | 'log', a: number, b: number): number;
    public calculate(operation: 'add' | 'subtract' | 'multiply' | 'divide', a: number, b: number, c?: number, d?: number): number;


    public calculate(operation:Operator,
                     numberOne:number, numberTwo:number,
                     numberThree?:number, numberFour?:number):number{

        if(operation=='power'){
            return Math.pow(numberOne,numberTwo);
        }
        else if(operation=='log'){
            return Math.log(numberTwo)/Math.log(numberTwo);
        }

        let numberArray = [numberOne,numberTwo,numberThree, numberFour]
                          .filter((num) => num !== undefined) as number[];
        let result:number;

        if(operation=='add'){
           result=numberArray.reduce((sum,numb)=>sum+numb,0);
        }
        else if(operation=='subtract'){
            result=numberArray.reduce((subst,numb)=>subst-numb);
        }
        else if(operation=='multiply'){
            result=numberArray.reduce((mult,numb)=>mult*numb,1);
        }
        else{
            result=numberArray.reduce((dev,numb)=>dev/numb);
        }
        
        return result;

    }
}

const calc = new Calculator();
console.log(calc.calculate('power', 2, 3));
console.log(calc.calculate('power', 4, 1/2));
console.log(calc.calculate('log', 8, 2));
console.log(calc.calculate('add', 10, 5));
console.log(calc.calculate('add', 10, 5, 3));
console.log(calc.calculate('subtract', 10, 5));
console.log(calc.calculate('multiply', 2, 3, 4));
console.log(calc.calculate('divide', 100, 5, 2, 2));

//These should return Errors:
//const calc = new Calculator();
//console.log(calc.calculate('power', 2, 3, 2));
//console.log(calc.calculate('add', 2));
//console.log(calc.calculate('log', 2, 3, 4, 5)); 
//console.log(calc.calculate('multiply', 2, 3, 4, 5, 6));
