
function validNumberAge(constructor:any,propertyName:string,descriptor:PropertyDescriptor) {
    const originalPropertySetter = descriptor.set;

    descriptor.set = function(value:number){

        if(value<1 || value >200){
            throw new Error (`Age must be between 1 and 200.`)
        }
        originalPropertySetter?.call(this,value);
    }

    return descriptor;
}


class Age {
    private _age!: number;

    constructor(age: number){ 
        this.age = age;
     }

    @validNumberAge
    set age(val: number){ this._age = val; }

    get age() { return this._age;  }
}


let ageVal = new Age(10);
ageVal.age = -10;
