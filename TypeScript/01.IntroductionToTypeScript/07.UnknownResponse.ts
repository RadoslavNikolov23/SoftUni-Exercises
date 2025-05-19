function unknownRespone(param:unknown):string{
    if("value" in (param as any)
      && typeof (param as any).value==="string"){
    return (param as any).value
    }

    return "-";
}

console.log(unknownRespone({ code: 200, text: 'Ok', value: [1, 2, 3] }))
console.log(unknownRespone({ code: 301, text: 'Moved Permanently', value: 'New Url' }))
console.log(unknownRespone({ code: 201, text: 'Created', value: { name: 'Test', age: 20 } }))
console.log(unknownRespone({ code: 201, text: 'Created', value: 'Object Created' }))
console.log(unknownRespone({ code: 404, text: 'Not found' }))
console.log(unknownRespone({ code: 500, text: 'Internal Server Error' }))