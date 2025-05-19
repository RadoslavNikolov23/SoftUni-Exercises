

function isNonEmptyStringArray(argum:unknown):argum is string{

    return Array.isArray(argum)
        && argum.length>=1
        && argum.every(e=>typeof (e) === "string")
}




let arr: unknown = {};
if(isNonEmptyStringArray(arr)) {
    console.log(arr.length);  
}

arr = { test: 'one' };
if(isNonEmptyStringArray(arr)) {
    console.log(arr.length);
}

arr = [];
if(isNonEmptyStringArray(arr)) {
    console.log(arr.length);
}

arr = undefined;
if(isNonEmptyStringArray(arr)) {
    console.log(arr.length);
}

arr = null;
if(isNonEmptyStringArray(arr)) {
    console.log(arr.length);
}

arr = [12, 13];
if(isNonEmptyStringArray(arr)) {
    console.log(arr.length);
}

arr = ['test', 123];
if(isNonEmptyStringArray(arr)) {
    console.log(arr.length);
}

arr = ['a', 'b', 'c'];
if(isNonEmptyStringArray(arr)) {
    console.log(arr.length);
}
