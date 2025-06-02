abstract class Shape{

    public color:string;

    constructor(color:string){
        this.color=color;
    }

    // Can make it more compactable with the prime constructor syntax
    // constructor(public color:string){}

    public abstract getArea():number;
}

class Circle extends Shape{

    public radius:number;

    constructor(color:string, radius:number) {
        super(color);
        this.radius=radius;
    }

    public getArea(): number {
        return Math.PI*Math.pow(this.radius,2);
    }

}

class Rectangle extends Shape{

    public sidaA:number;
    public sideB:number;

    constructor(color:string, sideA:number, sideB:number) {
        super(color);
        this.sidaA=sideA;
        this.sideB=sideB;
    }

    public getArea(): number {
        return this.sidaA*this.sideB
    }
}

const circle = new Circle("red", 5);
console.log(circle.getArea());


const rectangle = new Rectangle("blue", 4, 6);
console.log(rectangle.getArea());
