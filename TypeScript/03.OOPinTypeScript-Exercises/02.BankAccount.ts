class BankAccount {
    private balance:number;
    
    constructor(amount:number){
        this.balance=amount;
    }

    public deposit(amount:number):void{
        if(amount>0){
            this.balance+=amount;
        }
    }

    public withdraw(amount:number):void{
        if(this.balance>=amount){
            this.balance-=amount;
        }
       
    }

    public getBalance():number{
        return this.balance;
    }
}
    
const account = new BankAccount(100);
account.deposit(50);
account.withdraw(30);
console.log(account.getBalance());

const accountTwo = new BankAccount(20);
accountTwo.withdraw(30);
console.log(accountTwo.getBalance());

