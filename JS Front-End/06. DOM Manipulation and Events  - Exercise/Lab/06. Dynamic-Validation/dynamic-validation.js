document.addEventListener('DOMContentLoaded', solve);

function solve() {
   
    const emailInput = document.getElementById('email');
   const pattern = /^[a-zA-Z0-9]+@[a-zA-Z]+\.[a-zA-Z]{2,3}$/;

   emailInput.addEventListener('change', (event) => {
    const emailValie = pattern.test(event.target.value);
    if (!emailValie) {
        event.target.classList.add('error');
    } else {
        event.target.classList.remove('error');
    }
    });

}
