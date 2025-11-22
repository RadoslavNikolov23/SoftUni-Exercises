function solve(input){

    let parkingLot = {};
    for (const entry of input) {
        const [direction, plate] = entry.split(', ');
        if (direction === 'IN') {
            parkingLot[plate] = true;
        } else {
            delete parkingLot[plate];
        }
    }
    console.log(Object.keys(parkingLot)
                      .sort((a,b)=> a.localeCompare(b))
                      .join('\n') 
            || 'Parking Lot is Empty');
};

solve(['IN, CA2844AA',
'IN, CA1234TA',
'OUT, CA2844AA',
'IN, CA9999TT',
'IN, CA2866HI',
'OUT, CA1234TA',
'IN, CA2844AA',
'OUT, CA2866HI',
'IN, CA9876HH',
'IN, CA2822UU']
);
solve(['IN, CA2844AA',
'IN, CA1234TA',
'OUT, CA2844AA',
'OUT, CA1234TA']
);