function swap<T>(arrayA:T[],indexA:number,arrayB:T[], indexB:number):void{
    if(indexA>arrayA.length && indexB>arrayB.length){
        return;
    }

    let tempIndex:T = arrayA[indexA];
    arrayA[indexA]=arrayB[indexB];
    arrayB[indexB]=tempIndex;
}

let a = ['test', '123'];
let b = ['a', 'b', 'c'];
swap<string>(a, 0, b, 2);
console.log(a)
console.log(b)


let c = [20, 30 , 40];
let d = [1, 2, 3, 4, 5];
swap<number>(c, 0, d, 2);
console.log(c)
console.log(d)
