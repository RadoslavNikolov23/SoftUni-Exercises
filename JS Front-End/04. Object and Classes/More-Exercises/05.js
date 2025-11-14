function solve (inputArray){
    const pattern = /Student name: (?<name>[A-Za-z]+), Grade: (?<grade>\d+), Graduated with an average score: (?<score>\d+(\.\d+)?)/;
    const studentsRegister = {};

    for(const element of inputArray){
        const match = element.match(pattern);
        const name = match.groups.name;
        const grade = Number(match.groups.grade);
        const score = Number(match.groups.score);

        if(score>=3){
            if (!studentsRegister[grade + 1]) {
                studentsRegister[grade + 1] = { names: [], score: 0 };
            }
            studentsRegister[grade + 1].names.push(name);
            studentsRegister[grade + 1].score += score;

        }
    }

    const sortedStudents = Object.entries(studentsRegister).sort((a,b) => a.grade - b.grade);

    for(const [grade,student] of sortedStudents){
        console.log(`${grade} Grade`);
        const averageScore = (student.score/student.names.length).toFixed(2);
        console.log(`List of students: ${student.names.join(', ')}`);
        console.log(`Average annual score from last year: ${averageScore}\n`);
        //console.log(``);
    }
    
}

solve([
    "Student name: Mark, Grade: 8, Graduated with an average score: 4.75",
        "Student name: Ethan, Grade: 9, Graduated with an average score: 5.66",
        "Student name: George, Grade: 8, Graduated with an average score: 2.83",
        "Student name: Steven, Grade: 10, Graduated with an average score: 4.20",
        "Student name: Joey, Grade: 9, Graduated with an average score: 4.90",
        "Student name: Angus, Grade: 11, Graduated with an average score: 2.90",
        "Student name: Bob, Grade: 11, Graduated with an average score: 5.15",
        "Student name: Daryl, Grade: 8, Graduated with an average score: 5.95",
        "Student name: Bill, Grade: 9, Graduated with an average score: 6.00",
        "Student name: Philip, Grade: 10, Graduated with an average score: 5.05",
        "Student name: Peter, Grade: 11, Graduated with an average score: 4.88",
        "Student name: Gavin, Grade: 10, Graduated with an average score: 4.00"
    ]);

solve([
    'Student name: George, Grade: 5, Graduated with an average score: 2.75',
    'Student name: Alex, Grade: 9, Graduated with an average score: 3.66',
    'Student name: Peter, Grade: 8, Graduated with an average score: 2.83',
    'Student name: Boby, Grade: 5, Graduated with an average score: 4.20',
    'Student name: John, Grade: 9, Graduated with an average score: 2.90',
    'Student name: Steven, Grade: 2, Graduated with an average score: 4.90',
    'Student name: Darsy, Grade: 1, Graduated with an average score: 5.15'
    ]);