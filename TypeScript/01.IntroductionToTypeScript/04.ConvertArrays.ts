function arrayConvert(array:string[]):[string,number]{
    const result = array.join("");
    return [ result,result.length]
}

console.log(arrayConvert(['How', 'are', 'you?']));
console.log(arrayConvert(['Today', ' is', ' a ', 'nice', ' ', 'day for ', 'TypeScript']));
