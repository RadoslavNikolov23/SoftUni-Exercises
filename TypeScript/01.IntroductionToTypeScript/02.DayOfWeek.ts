enum DayOfWeek{
    Monday = 1,
    Tuesday = 2,
    Wednesday = 3,
    Thursday = 4,
    Friday = 5,
    Saturday = 6,
    Sunday = 7
}

function DayOfWeekByNumber(day:number):string{
    return DayOfWeek[day] || 'error';
}

console.log(DayOfWeekByNumber(1));
console.log(DayOfWeekByNumber(-5));
console.log(DayOfWeekByNumber(5));
console.log(DayOfWeekByNumber(7));
console.log(DayOfWeekByNumber(8));


