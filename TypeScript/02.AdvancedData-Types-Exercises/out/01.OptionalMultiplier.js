"use strict";
function optionalMultiplier(parmOne, parmTwo, parmThree) {
    let numberOne = parmOne ? typeof parmOne === "string" ? parseInt(parmOne) : parmOne : 1;
    let numberTwo = parmTwo ? typeof parmTwo === "string" ? parseInt(parmTwo) : parmTwo : 1;
    let numberThree = parmThree ? typeof parmThree === "string" ? parseInt(parmThree) : parmThree : 1;
    let result = numberOne * numberTwo * numberThree;
    return result;
}
console.log(optionalMultiplier('3', 5, '10'));
console.log(optionalMultiplier('2', '2'));
console.log(optionalMultiplier(undefined, 2, 3));
console.log(optionalMultiplier(7, undefined, '2'));
console.log(optionalMultiplier(2, 2, 2));
console.log(optionalMultiplier());
//# sourceMappingURL=01.OptionalMultiplier.js.map