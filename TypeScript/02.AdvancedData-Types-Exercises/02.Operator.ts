function operatorChoose( paramOne: string | number | string[],
                         paramTwo: "Index" | "Length" | "Add",
                         paramThree: number) : void{

        const isArrayString = Array.isArray(paramOne) && paramOne.every((item)=>typeof item==="string"); 
        const isString = typeof paramOne === "string";

        if(( isArrayString || isString) 
            && paramTwo==="Index"){
                console.log(paramOne[paramThree]);
         }
         else if((isArrayString || isString) 
            && paramTwo==="Length"){

                console.log(paramOne.length % paramThree);
        }
        else if(paramTwo==="Add"){

            if(isString){
                console.log(parseInt(paramOne,10)+paramThree);
            }
            else if (typeof paramOne === "number"){
                console.log(paramOne +paramThree);
            }
        }
}


operatorChoose(['First', 'Second', 'Third'], 'Index', 1);
operatorChoose('string', 'Index', 1);
operatorChoose(['Just', 'Two'], 'Length', 5);
operatorChoose('short string1', 'Length', 5);
operatorChoose('7', 'Add', 3);
operatorChoose(11, 'Add', 3);