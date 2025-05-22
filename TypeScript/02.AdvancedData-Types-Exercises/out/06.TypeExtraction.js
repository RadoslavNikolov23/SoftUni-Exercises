"use strict";
let names = { fName: 'John',
    lName: 'Doe',
    age: 22,
    getPersonInfo() { return `${this.fName} ${this.lName}, age ${this.age}`; } };
let localPerson = { city: 'Boston',
    street: 'Nowhere street',
    number: 13,
    postalCode: 51225,
    getAddressInfo() { return `${this.street} ${this.number}, ${this.city} ${this.postalCode}`; } };
function createCombinedFunction(names, localPerson) {
    return (combineNameLocationPerson) => {
        console.log(`Hello, ${combineNameLocationPerson.getPersonInfo()} from ${combineNameLocationPerson.getAddressInfo()}`);
    };
}
let combinedFunction = createCombinedFunction(names, localPerson);
let combinedPerson = Object.assign({}, names, localPerson);
combinedFunction(combinedPerson);
//# sourceMappingURL=06.TypeExtraction.js.map