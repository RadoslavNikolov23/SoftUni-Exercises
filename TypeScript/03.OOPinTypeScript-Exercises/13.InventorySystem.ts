class Product{

    private static productCount:number = 1;

    private readonly _id:number = Product.productCount++;

    public name:string;

    public price:number;

    constructor(name:string,price:number){

        if(name.length<1){
            throw new Error("Product name must at least 1 charachers long.")
        }

        if(price<=0){
            throw new Error("Price should be a possive number.")
        }

        this.name=name;
        this.price=price;
    }

    public getDetails():string{
        return `ID: ${this._id}, Name:$${this.name}, Price: ${this.price}`;
    }
}

class Inventory{

    private products:Product[]

    constructor(){
        this.products = [];
    }

    public addProduct(product:Product):void{
        this.products.push(product);
    }

    public listProducts():string{

        let textResult:string="";

        this.products.forEach(it=> textResult+=`${it.getDetails()} \n`);
        textResult+=`Total products created: ${this.products.length}`;
        return textResult;
    }
}

const inventory = new Inventory();
const product1 = new Product("Laptop", 1200);
const product2 = new Product("Phone", 800);

inventory.addProduct(product1);
inventory.addProduct(product2);

console.log(inventory.listProducts());


//These shoudl return errors:
//Product.productCount = 10;
//const product3 = new Product("", 800);
//const product4 = new Product("Phone", 0);
//product3.id = 5;
