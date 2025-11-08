function matrixWrite(number){

    //Short version 01
    // const rowArray = Array(number).fill(number);
    // for(let i=0; i<number; i++){
    //     console.log(rowArray.join(' '));
    // }

    //Version 02
    let matrixArray=[];

    for(let i=0; i<number; i++){
        let rowArray=[];
        matrixArray.push(rowArray);
       for(let j=0; j<number; j++){
        rowArray.push(number);
       }
    }

   for(let row of matrixArray){
    console.log(row.join(' '));
   }
}

matrixWrite(3);
matrixWrite(7);
matrixWrite(2);
