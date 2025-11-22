function cat(arrStrings){

    class Cat{

        constructor(name,age){
            this.name = name;
            this.age = age;
        }

        meow(){
            console.log(`${this.name}, age ${this.age} says Meow`);
        }

    }

    for(let str of arrStrings){
        let [name,age] = str.split(" ");
        let cat = new Cat(name,age);
        cat.meow();
    }

}

cat(['Mellow 2', 'Tom 5']);
cat(['Candy 1', 'Poppy 3', 'Nyx 2']);