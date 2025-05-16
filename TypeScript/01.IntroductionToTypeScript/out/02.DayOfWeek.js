"use strict";
var DayOfWeek;
(function (DayOfWeek) {
    DayOfWeek[DayOfWeek["Monday"] = 1] = "Monday";
    DayOfWeek[DayOfWeek["Tuesday"] = 2] = "Tuesday";
    DayOfWeek[DayOfWeek["Wednesday"] = 3] = "Wednesday";
    DayOfWeek[DayOfWeek["Thursday"] = 4] = "Thursday";
    DayOfWeek[DayOfWeek["Friday"] = 5] = "Friday";
    DayOfWeek[DayOfWeek["Saturday"] = 6] = "Saturday";
    DayOfWeek[DayOfWeek["Sunday"] = 7] = "Sunday";
})(DayOfWeek || (DayOfWeek = {}));
function DayOfWeekByNumber(day) {
    return DayOfWeek[day] || 'error';
}
console.log(DayOfWeekByNumber(1));
console.log(DayOfWeekByNumber(-5));
console.log(DayOfWeekByNumber(5));
console.log(DayOfWeekByNumber(7));
console.log(DayOfWeekByNumber(8));
//# sourceMappingURL=02.DayOfWeek.js.map