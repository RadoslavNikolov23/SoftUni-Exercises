enum DayOfWeekReverse{
    Monday = 1,
    Tuesday = 2,
    Wednesday = 3,
    Thursday = 4,
    Friday = 5,
    Saturday = 6,
    Sunday = 7
}

function reverseDayWeek(dayName:string):void{
   console.log(DayOfWeekReverse[dayName as keyof typeof DayOfWeekReverse] || "error");
}

reverseDayWeek("Monday");
reverseDayWeek("Wednesday");
reverseDayWeek("Invalid");
reverseDayWeek("Sunday");
reverseDayWeek("Monday");