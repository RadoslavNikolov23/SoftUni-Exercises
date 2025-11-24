function attachGradientEvents() {
    
    const gradienEl = document.getElementById('gradient');
    const resultEl = document.getElementById('result');

    gradienEl.addEventListener('mousemove', (e) => {
        const boxWidth = e.target.clientWidth;
        const offsetX = e.offsetX;
        const percentage = Math.floor((offsetX / boxWidth) * 100);
        resultEl.textContent = `${percentage}%`;
    });

    gradienEl.addEventListener('mouseout', () => {
        resultEl.textContent = '';
    });

}
