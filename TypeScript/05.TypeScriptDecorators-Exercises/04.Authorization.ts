export { }

class MockAuthorizationService {
    constructor(private userRole: 'Guest' | 'PersonalDataAdministrator' | 'Admin') { }

    canViewData(property: string) {
        switch (this.userRole) {
            case 'Admin': return true;
            case 'PersonalDataAdministrator': return ['name', 'age'].includes(property);
            default: return false;
        }
    }
}

//Should return all three properties
//let mockAuthorizationService = new MockAuthorizationService('Admin');

//Should return only the first two properties and an Error for not authorize
//let mockAuthorizationService = new MockAuthorizationService('PersonalDataAdministrator');

//Should return Error for not authorize from the start
let mockAuthorizationService = new MockAuthorizationService('Guest');


function decortorMockAuthServize(mockAuthServize:MockAuthorizationService) {
    return function (targe:any, propertyName:string, descriptor:PropertyDescriptor){
        const originGetter = descriptor.get;

        descriptor.get=function(){
                const hasAuthoriz = mockAuthServize.canViewData(propertyName);

                if(!hasAuthoriz){
                    throw new Error('You are not authorized to view this information');     
                }
                
                return originGetter?.call(this);
        }

        return descriptor;
    }
}

class User {
    private _name:string;
    private _age:number;
    private _creditCardNumber:string;

    constructor(name:string, age:number, creditCardNumber:string){
        this._name=name;
        this._age=age;
        this._creditCardNumber=creditCardNumber
    }

    @decortorMockAuthServize(mockAuthorizationService)
    get name() { return this._name;}

    @decortorMockAuthServize(mockAuthorizationService)
    get age() { return this._age;}

    @decortorMockAuthServize(mockAuthorizationService)
    get creditCardNumber() { return this._creditCardNumber;}
}

const user1 = new User("John Doe", 30, 'ABCD-1234');
console.log(user1.name);
console.log(user1.age);
console.log(user1.creditCardNumber);

