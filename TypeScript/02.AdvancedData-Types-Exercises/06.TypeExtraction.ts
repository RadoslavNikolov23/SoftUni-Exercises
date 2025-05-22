let names = { fName: 'John', 
              lName: 'Doe', 
              age: 22, 
              getPersonInfo() { return `${this.fName} ${this.lName}, age ${this.age}` } };

let localPerson = { city:'Boston', 
                   street: 'Nowhere street',
                   number: 13, 
                   postalCode: 51225, 
                   getAddressInfo() { return `${this.street} ${this.number}, ${this.city} ${this.postalCode}`} };

type Names = typeof names;
type LocationPerson = typeof localPerson;

function createCombinedFunction(names:Names,localPerson:LocationPerson){
   return (combined: Names & LocationPerson) =>{
      console.log(`Hello, ${combined.getPersonInfo()} from ${combined.getAddressInfo()}`);
   };   
 }

let combinedFunction = createCombinedFunction(names, localPerson);
let combinedPerson = Object.assign({}, names, localPerson);

combinedFunction(combinedPerson);
