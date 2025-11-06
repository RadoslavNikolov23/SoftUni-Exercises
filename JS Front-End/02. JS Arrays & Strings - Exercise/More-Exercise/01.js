/**
 * 
 * @param {array} arrayInput 
 */

function solve(arrayInput) {
    const userName = arrayInput.shift();
    const reverseUserName = userName.split('').reverse().join('');
    let counter = 0;
    for (let word of arrayInput) {

        if (word === reverseUserName) {
            console.log(`User ${userName} logged in.`);
            return;
        }
        else {
            counter++;
            if (counter === 4) {
                console.log(`User ${userName} blocked!`);
                return;
            }
            console.log(`Incorrect password. Try again.`);
        }
    }
}

solve(['Acer', 'login', 'go', 'let me in', 'recA']);
solve(['momo', 'omom']);
solve(['sunny', 'rainy', 'cloudy', 'sunny', 'not sunny']);