const getDayNameFromDate = (date: Date):string =>{
 const days = ['Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday','Sunday'];
    return days[date.getDay()-1];
}    


function isFridayThe13(param:unknown[]):void{

    param.forEach(element => {
        if(element instanceof Date){

            const dayString=getDayNameFromDate(element);
            const dayNumber=element.getDate();

            if(dayString==="Friday" && dayNumber === 13){
                const monthName:string = new Intl.DateTimeFormat("en", {month:"long"}).format(element);

                console.log(`${dayNumber}-${monthName}-${element.getFullYear()}`);
            }
        }

    });
}


isFridayThe13([
    {},
    new Date(2025, 4, 13),
    null,
    new Date(2025, 5, 13),
    '13-09-2023',
    new Date(2025, 6, 13),
])


isFridayThe13([
    new Date(2024, 0, 13),
    new Date(2024, 1, 13),
    new Date(2024, 2, 13),
    new Date(2024, 3, 13),
    new Date(2024, 4, 13),
    new Date(2024, 5, 13),
    new Date(2024, 6, 13),
    new Date(2024, 7, 13),
    new Date(2024, 8, 13),
    new Date(2024, 9, 13),
    new Date(2024, 10, 13),
    new Date(2024, 11, 13)
]);