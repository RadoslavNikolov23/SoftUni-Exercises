function solve(inputArr) {

    const employeeList = {};

    return inputArr.forEach((employee) => {
        employeeList[employee] = employee.length;
        console.log(`Name: ${employee} -- Personal Number: ${employee.length}`);
    });

}

solve([
  "Silas Butler",
  "Adnaan Buckley",
  "Juan Peterson",
  "Brendan Villarreal",
]);

solve([
    "Samuel Jackson", 
    "Will Smith", 
    "Bruce Willis", 
    "Tom Holland"
]);
