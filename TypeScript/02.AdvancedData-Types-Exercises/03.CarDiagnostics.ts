type carBodyType =  { 
    material: string, 
    state: string  
};
type tiresType = { 
    airPressure: number,
     condition: string
    };
type engineType = { 
    horsepower: number, 
    oilDensity: number
};

type additionOptionsType = {
    partName: string, 
    runDiagnostics(): string 
};


function carDiagnostics(
    carBody: {carBodyT:carBodyType} & {additionCarBodyT:additionOptionsType},
    tires: {tiresT:tiresType} & {additionTiresT:additionOptionsType},
    engine: {engineT:engineType} & {additionEngieT:additionOptionsType},
): void{
    console.log()
}