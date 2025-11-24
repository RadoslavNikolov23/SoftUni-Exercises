document.addEventListener('DOMContentLoaded', focused);

function focused(event) {

    const inputs = document.querySelectorAll('input');
    inputs.forEach(input => {

        input.addEventListener('focus', (event) => {
            event.target.parentNode.classList.add('focused');
        });

        input.addEventListener('blur', (event) => {
            event.target.parentNode.classList.remove('focused');
        });
    });
}
