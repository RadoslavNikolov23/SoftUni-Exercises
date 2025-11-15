function solve(inputArr) {

    let parkingLot = {};

    for(let element of inputArr){
        let [takeNumber, carInfo] = element.split(" - ");

        if(!parkingLot.hasOwnProperty(takeNumber)){
            parkingLot[takeNumber]=[];
        }

        const carInfoArr = carInfo.split(", ");
        
        let car = [];
        for(const infoPart of carInfoArr){
            let [key,value] = infoPart.split(": ");
            car.push(`${key} - ${value}`);
        }

        parkingLot[takeNumber].push(car);
    }

    const parkingLotEntries = Object.entries(parkingLot);

    for(const [number,carInfo] of parkingLotEntries){
        console.log(`Garage № ${number}`);
        for(const car of carInfo){
            console.log(`--- ${car.join(", ")}`);
        }
    }
}

solve([
  "1 - color: blue, fuel type: diesel",
  "1 - color: red, manufacture: Audi",
  "2 - fuel type: petrol",
  "4 - color: dark blue, fuel type: diesel, manufacture: Fiat",
]);

solve([
  "1 - color: green, fuel type: petrol",
  "1 - color: dark red, manufacture: WV",
  "2 - fuel type: diesel",
  "3 - color: dark blue, fuel type: petrol",
]);
