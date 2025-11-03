function solve(speed, area) {
    const speedLimits = {
        motorway: 130,
        interstate: 90,
        city: 50,
        residential: 20
    };

    const speedLimit = speedLimits[area];
    const difference = speed - speedLimit;

    if (difference <= 0) {
        console.log(`Driving ${speed} km/h in a ${speedLimit} zone`);
        return;
    }

    const status = difference <= 20 ? 'speeding' : 
                   difference <= 40 ? 'excessive speeding' : 
                   'reckless driving';

    console.log(`The speed is ${difference} km/h faster than the allowed speed of ${speedLimit} - ${status}`);
}




solve(40, 'city');
solve(21, 'residential');
solve(120, 'interstate');
solve(200, 'motorway');