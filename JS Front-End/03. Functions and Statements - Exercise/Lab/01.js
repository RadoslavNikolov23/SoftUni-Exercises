function formatGrade(grade) {

    let formattedGrade = '';
    if (grade < 3.00) {
        formattedGrade = 'Fail (2)';
    } else if (grade >= 3.00 && grade < 3.50) {
        formattedGrade = `Poor (${grade.toFixed(2)})`;
    } else if (grade >= 3.50 && grade < 4.50) {
        formattedGrade = `Good (${grade.toFixed(2)})`;
    } else if (grade >= 4.50 && grade < 5.50) {
        formattedGrade = `Very good (${grade.toFixed(2)})`;
    } else if (grade >= 5.50) {
        formattedGrade = `Excellent (${grade.toFixed(2)})`;
    }
    console.log(formattedGrade);

}

formatGrade(3.33);
formatGrade(4.50);
formatGrade(2.99);

