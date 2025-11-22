function convertToObject(strInput) {
    let obj = JSON.parse(strInput);
    let entries = Object.entries(obj);

    for (let [key,value] of entries) {
        console.log(`${key}: ${value}`);
    }

}

convertToObject('{"name": "George", "age": 40, "town": "Sofia"}');
convertToObject('{"name": "Peter", "age": 35, "town": "Plovdiv"}');