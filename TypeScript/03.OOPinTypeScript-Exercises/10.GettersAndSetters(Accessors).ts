class User{

    private _username!:string;

    constructor(username:string){
        this.username=username;
    }

    public get username() : string {
        return this._username;
    }

    public set username(newUsername : string) {
        if(newUsername.length <3){
            throw new Error(`Username should be at least 3 charackers long. Try again!`);
        }
        this._username = newUsername;
    }
}

const user = new User("Martin");
user.username = "johnDoe";
console.log(user.username);

//This should return the Error message
const userTwo = new User("jo");

//This should return the Error message
const userThree = new User("Martin");
userThree.username = "Do";


