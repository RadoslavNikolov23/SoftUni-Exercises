/**
 * 
 * @param {array} arrString 
 * @param {object} schedule 
 */

function meetings(arrString) {

    let schedule = {};

    for(let input of arrString){
        let [day,person]= input.split(" ");

        if(schedule.hasOwnProperty(day)){
            console.log(`Conflict on ${day}!`);
        }
        else{
            schedule[day] = person;
            console.log(`Scheduled for ${day}`);
        }
    }

    let entries = Object.entries(schedule);
    for(let [day,person] of entries){
        console.log(`${day} -> ${person}`);
    }
}

meetings([
    "Monday Peter", 
    "Wednesday Bill", 
    "Monday Tim", 
    "Friday Tim"
]);

meetings([
  "Friday Bob",
  "Saturday Ted",
  "Monday Bill",
  "Monday John",
  "Wednesday George",
]);
