type floorOne = {
    number:1, 
    train: ()=>void,
    hallway: "A", 
    pass?:string
} | {
    number:1, 
    train: ()=>void,
    hallway: "C"
}

type floorTwo = {
    number:2, 
    hallway: "A", 
    dine: ()=>void,
    pass?: string
} | {
    number:2, 
    dine: ()=>void,
    hallway: "C"
}

type floorThree = {
    number:3, 
    hallway: "A" | "C", 
    sleep: ()=>void
} 

type simplified = floorOne | floorTwo | floorThree;

function visitFloor(floor: simplified){
    switch (floor.number) {
        case 1: floor.train(); return;
        case 2: floor.dine(); return;
        case 3: floor.sleep(); return;
    }
}


visitFloor({ train() { }, number: 1, hallway: 'A', pass: 'Guest' });
visitFloor({ dine() { }, number: 2, hallway: 'A' });
visitFloor({ sleep() { }, number: 3, hallway: 'C' });
visitFloor({ train() { }, number: 1, hallway: 'C' });
visitFloor({ train() { }, number: 1, hallway: 'A' });
visitFloor({ dine() { }, number: 2, hallway: 'A', pass: 'Guest' });
visitFloor({ sleep() { }, number: 3, hallway: 'A' });
visitFloor({ dine() { }, number: 2, hallway: 'C' });


//-----------These shoudl return a error --------- !
//visitFloor({ train() { }, number: 4, hallway: 'A' });
//visitFloor({ train() { }, number: 1, hallway: 'C', pass: 'Guest' });
//visitFloor({ train() { }, number: 2, hallway: 'A' });
//visitFloor({ train() { }, number: 3, hallway: 'C' });
//visitFloor({ train() { }, number: 3, hallway: 'C', pass: 'Guest' });

//visitFloor({ dine() { }, number: 1, hallway: 'A' });
//visitFloor({ dine() { }, number: 1, hallway: 'B' });
//visitFloor({ dine() { }, number: 1, hallway: 'C' });
//visitFloor({ dine() { }, number: 3, hallway: 'C' });
//visitFloor({ dine() { }, number: 2, hallway: 'C', pass: 'Guest' });
//visitFloor({ dine() { }, number: 1, hallway: 'A', pass: 'Guest' });

//visitFloor({ sleep() { }, number: 3, hallway: 'D' });
//visitFloor({ sleep() { }, number: 4, hallway: 'C' });
//visitFloor({ sleep() { }, number: 1, hallway: 'C' });
//visitFloor({ sleep() { }, number: 1, hallway: 'A' });
//visitFloor({ sleep() { }, number: 2, hallway: 'A' });
//visitFloor({ sleep() { }, number: 2, hallway: 'C' });
