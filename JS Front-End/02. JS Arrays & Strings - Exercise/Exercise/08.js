function solve (array){

    let pattern = /[A-Z][a-z]*/g;
    let matches = array.match(pattern);
    console.log(matches.join(', '));

}

solve('SplitMeIfYouCanHaHaYouCantOrYouCan');
solve('HoldTheDoor');
solve('ThisIsSoAnnoyingToDo');