enum TravelVacation {
    Abroad = 'Abroad',
    InCountry = 'InCountry'
}

enum MountainVacation {
    Ski = 'Ski',
    Hiking = 'Hiking'
}

enum BeachVacation {
    Pool = 'Pool',
    Sea = 'Sea',
    ScubaDiving = 'ScubaDiving'
}

interface Holiday {
    set start(val: Date);
    set end(val: Date);
    getInfo(): string;
}

interface VacationManager<T, V> {
    reserveVacation(holiday: T, vacationType: V): void;
    listReservations(): string;
}


class PlannedHoliday implements Holiday{
    private starDate!:Date;
    private endDate!:Date;

    constructor(startDate:Date, endDate:Date){
        this.start=startDate;
        this.end=endDate;
    }

    set start(val: Date) {
        if(val>this.endDate){
            throw new Error("Start date cannot be after end date");
        }

        this.starDate=val;
    }

    set end(val: Date) {
   
         if(this.starDate>val){
            throw new Error("End date cannot be before start date");
        }

        this.endDate=val;    }

    getInfo(): string {
        return `Holiday: ${this.starDate.getDate()}/${this.starDate.getMonth()}/${this.starDate.getFullYear()} - ${this.endDate.getDate()}/${this.endDate.getMonth()}/${this.endDate.getFullYear()}`
    }
}

class HolidayManager<T extends Holiday,V extends TravelVacation | MountainVacation | BeachVacation> implements VacationManager<T,V>{

    public holidayVacation: Map<T,V> = new Map();

    reserveVacation(holiday: T, vacationType: V): void {
        this.holidayVacation.set(holiday,vacationType);

    }

    listReservations(): string {
        let resultText:string = "";

        this.holidayVacation.forEach((value,key) => {
            resultText+=`${key.getInfo()} => ${value} \n`;
        });

        return resultText;
    }

}

let holiday = new PlannedHoliday(new Date(2024, 1, 1), new Date(2024, 1, 4));
let holiday2 = new PlannedHoliday(new Date(2025, 3, 14), new Date(2025, 3, 17));
let holidayManager = new HolidayManager<Holiday, TravelVacation>();
holidayManager.reserveVacation(holiday, TravelVacation.Abroad);
holidayManager.reserveVacation(holiday2, TravelVacation.InCountry);
console.log(holidayManager.listReservations())


let holiday3 = new PlannedHoliday(new Date(2022, 10, 11), new Date(2022, 10, 18));
let holiday4 = new PlannedHoliday(new Date(2024, 5, 18), new Date(2024, 5, 22));
let holidayManager1 = new HolidayManager<Holiday, BeachVacation>();
holidayManager1.reserveVacation(holiday3, BeachVacation.ScubaDiving);
holidayManager1.reserveVacation(holiday4, BeachVacation.Sea);
console.log(holidayManager1.listReservations())


//Should return error at RunTime
let holiday5 = new PlannedHoliday(new Date(2021, 3, 14), new Date(2020, 3, 17));
let holiday6 = new PlannedHoliday(new Date(2024, 2, 1), new Date(2024, 1, 4));

//Should return TS error at CompileTime
// let holiday7 = new PlannedHoliday(new Date(2024, 1, 1), new Date(2024, 1, 4));
// let holiday8 = new PlannedHoliday(new Date(2025, 3, 14), new Date(2024, 3, 17));
// let holidayManager3 = new HolidayManager<Holiday, MountainVacation>();
// holidayManager3.reserveVacation(holiday, BeachVacation.ScubaDiving);
// holidayManager3.reserveVacation(holiday2, TravelVacation.InCountry);
// console.log(holidayManager3.listReservations())
