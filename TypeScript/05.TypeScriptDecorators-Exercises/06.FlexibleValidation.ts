export {}

function validNameUser(minLengthName:number){
    return function(target:any, propertyName:string, descriptor:PropertyDescriptor){
        const orignalSetter = descriptor.set;

        descriptor.set=function(val:string){
            if(val.length< minLengthName){
                throw new Error (`The name must have a min length of ${minLengthName} characters!`);
            }

            orignalSetter?.call(this,val);
        }

        return descriptor;
    }
}

function validAgeUser(minAge:number,maxAge:number){
    return function(target:any, propertyName:string, descriptor:PropertyDescriptor){
        const orignalSetter = descriptor.set;

        descriptor.set=function(val:number){
            if(val<minAge || val>maxAge){
                throw new Error (`The age must be between ${minAge} and ${maxAge}!`);
            }

            orignalSetter?.call(this,val);
        }

        return descriptor;
    }
}

function validPasswordUser (regexPattern:RegExp){
    return function(target:any, propertyName:string, descriptor:PropertyDescriptor){
        const orignalSetter = descriptor.set;

        descriptor.set=function(val:string){
            if(!val.match(regexPattern)){
                throw new Error (`The password neeeds to match ${regexPattern}`);
            }

            orignalSetter?.call(this,val);
        }

        return descriptor;
    }
}

class User {
    private _name!: string;
    private _age!: number;
    private _password!: string;

    constructor(name: string, age: number, password: string) {
        this.name = name;
        this.age = age;
        this.password = password;
    }

    @validNameUser(3)
    set name(val: string) { this._name = val; }

    @validAgeUser(1,100)
    set age(val: number) { this._age = val; }

    @validPasswordUser(/^[a-zA-Z0-9]+$/g)
    set password(val: string) { this._password = val; }

    get name() { return this._name; }
    get age() { return this._age; }
}

//With the given values to the decorators these should return run time errors:
//let user = new User('John', 130, 'hardPassword12');
//let user2 = new User('John', 30, '!test');
//let user3 = new User('John', 25, '@werty');
//let user4 = new User('Jo', 20, 'password123');



