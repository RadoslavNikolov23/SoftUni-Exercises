"use strict";
function arrayConvert(array) {
    const result = array.join("");
    return [result, result.length];
}
console.log(arrayConvert(['How', 'are', 'you?']));
console.log(arrayConvert(['Today', ' is', ' a ', 'nice', ' ', 'day for ', 'TypeScript']));
//# sourceMappingURL=04.ConvertArrays.js.map