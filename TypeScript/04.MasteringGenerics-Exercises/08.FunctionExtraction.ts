type FunctionKeys<T> = {
    [K in keyof T]: T[K] extends Function ? K : never;
}[keyof T];

type AllFunctions<T> = Pick<T, FunctionKeys<T>>;


type testTwo = { 
   name: string,
   age: number,
   test:() => string;
}
type extractedTwo = AllFunctions<testTwo>

type Employee = {
    name: string,
    salary: number,
    work: () => void,
    takeBreak: () => string
};

type extractedThree = AllFunctions<Employee>;

type Nope = {
    name: string
};

type extractedFour = AllFunctions<Nope>;





