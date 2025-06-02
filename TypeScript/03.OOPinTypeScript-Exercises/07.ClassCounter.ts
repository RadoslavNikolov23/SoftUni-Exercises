class Counter {
    private static count:number = 0;

    public static increment():void {
        Counter.count++;
    }

    public static getCount():number {
        return Counter.count;
    }
}

Counter.increment();
Counter.increment();
console.log(Counter.getCount());

//This should return error
//Counter.count = 10;