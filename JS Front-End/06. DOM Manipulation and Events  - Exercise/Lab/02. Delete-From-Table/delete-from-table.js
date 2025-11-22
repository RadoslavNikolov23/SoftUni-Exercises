function deleteByEmail() {
    
    const inputEl = document.querySelector('input[name="email"]');
    const emal = inputEl.value;

    const allEmails = document.querySelectorAll(`#customers tbody tr td:nth-child(2)`);
    let resultText = `Not found.`;
    
    allEmails.forEach(email => {
        if(email.textContent === emal) {
            email.parentElement.remove();
            resultText = `Deleted.`;
        }});

    const resultEl = document.querySelector('#result');
    resultEl.textContent = resultText;

    // Alternative solution with for...of loop
    // for(const email of allEmails) {

    //     if(email.textContent === emal) {
    //         email.parentElement.remove();
    //         resultText = `Deleted.`;
    //         break;
    //     }
    // }

}
