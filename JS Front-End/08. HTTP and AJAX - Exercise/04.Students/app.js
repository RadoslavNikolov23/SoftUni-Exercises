const urlResponse = 'http://localhost:3030/jsonstore/collections/students';

const tableResultsElt = document.querySelector('table#results > tbody');
const formEl = document.querySelector('form#form');
    
formEl.addEventListener('submit', async (event)=>{
    event.preventDefault();
    event.stopPropagation();

    const formData = new FormData(event.target);

    const firstName = formData.get('firstName').trim();
    const lastName = formData.get('lastName').trim();
    const facultyNumber = formData.get('facultyNumber').trim();
    const grade = formData.get('grade').trim();

    // Validation checks (commented out)
    // if (!firstName || !lastName) {
    //     return;
    // }

    // if (!/^[a-zA-Z]+$/.test(firstName) || !/^[a-zA-Z]+$/.test(lastName)) {
    //     return;
    // }

    // if (!facultyNumber || isNaN(facultyNumber)) {
    //     return;
    // }

    // if (!grade || isNaN(grade)) {
    //     return;
    // }

    const student = {
        firstName,
        lastName,
        facultyNumber,
        grade: Number(grade)
    };

    await fetch(urlResponse, {
        method: 'POST',
        headers: {'Content-Type': 'application/json'},
        body: JSON.stringify(student)
    });

    event.target.reset();
    await loadStudents();
});

async function loadStudents(){
    tableResultsElt.innerHTML = '';

    const loadElemets = await fetch(urlResponse);
    const dataElements = await loadElemets.json();

    Object.values(dataElements).forEach(student => {
        const tr = document.createElement('tr');
        
        const firstNameTD = document.createElement('td');
        firstNameTD.textContent = student.firstName;
        tr.appendChild(firstNameTD);

        const lastNameTD = document.createElement('td');
        lastNameTD.textContent = student.lastName;
        tr.appendChild(lastNameTD);

        const facultyNumberTD = document.createElement('td');
        facultyNumberTD.textContent = student.facultyNumber;
        tr.appendChild(facultyNumberTD);

        const gradeTD = document.createElement('td');
        gradeTD.textContent = student.grade;
        tr.appendChild(gradeTD);

        tableResultsElt.appendChild(tr);
    });
}


loadStudents();



