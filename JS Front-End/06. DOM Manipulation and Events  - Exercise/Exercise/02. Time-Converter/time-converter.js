document.addEventListener('DOMContentLoaded', solve);

function solve() {

    const times = {
        days: 86400,
        hours: 3600,
        minutes: 60,
        seconds: 1
    };
    
    const submitInputEl = document.querySelectorAll('input[type="submit"]');

    for (const submitEl of submitInputEl) {
        submitEl.addEventListener('click', convert);
    }

    function convert(event) {
        event.preventDefault();
        event.stopPropagation();
        
        const parentEl = event.target.parentElement;
        const inputEl = parentEl.querySelector('input[type="number"]');
        const inputId = inputEl.id;
        const firstEl = inputId.split('-')[0];
        const timeValue = Number(inputEl.value);
        const totalSeconds = timeValue * times[firstEl];
        
        for (const key in times) {
            const currentInputEl = document.getElementById(`${key}-input`);
            currentInputEl.value = (totalSeconds / times[key]).toFixed(2);
        }

    }

}