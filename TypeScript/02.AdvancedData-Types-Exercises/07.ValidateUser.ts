
type User = {
        id: number | string,
        username: string,
        passwordHash: string | string[],
        status: 'Locked' | 'Unlocked' | 'Deleted',
        email?: string
}

function validatedUser(user: User) : Boolean{

    let isValid:boolean = false;
    let isValidId:boolean = false;
    let isValidUserName:boolean = false;
    let isValidPassword:boolean = false;
    let isValidStatus:boolean = false;

    if(typeof user.id === "number" && user.id > 100 ){
        isValidId = true;
    }
    else if(typeof user.id === "string" && user.id.length===14){
        isValidId = true;
    }

    if(user.username.length>=5 && user.username.length<=10){
        isValidUserName=true;
    }

    if(typeof user.passwordHash === "string" && user.passwordHash.length===20){
        isValidPassword=true;
    }
    else if((Array.isArray(user.passwordHash) && user.passwordHash.every((item)=>typeof item==="string")) 
            && (user.passwordHash.length===4 && user.passwordHash.every((item)=>item.length===8))){
        isValidPassword=true;
    }

    if(user.status === "Locked" || user.status === "Unlocked"){
        isValidStatus = true;
    }

    if(isValidId && isValidUserName && isValidPassword && isValidStatus){
        isValid = true;
    }

    return isValid;
}


console.log(validatedUser({ id: 120, username: 'testing', passwordHash: '123456-123456-123456', status: 'Deleted', email: 'something' }));
console.log(validatedUser({ id: '1234-abcd-5678', username: 'testing', passwordHash: '123456-123456-123456', status: 'Unlocked' }));
console.log(validatedUser({ id: '20', username: 'testing', passwordHash: '123456-123456-123456', status:'Deleted', email: 'something' }));
console.log(validatedUser({ id: 255, username: 'Pesho', passwordHash: ['asdf1245', 'qrqweggw', '123-4567','98765432'], status: 'Locked', email: 'something' }));
console.log(validatedUser({ id: 'qwwe-azfg-ey38', username: 'Someone', passwordHash: ['qwezz8jg', 'asdg-444','12-34-56'], status: 'Unlocked' }));
console.log(validatedUser({ id: 1344, username: 'wow123', passwordHash: '123456-123456-1234567', status: 'Locked', email: 'something@abv.bg' }));

