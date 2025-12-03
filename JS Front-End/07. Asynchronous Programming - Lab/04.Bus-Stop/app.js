async function getInfo() {
    const idEl = document.getElementById('stopId');
    const stopNameEl = document.getElementById('stopName');
    const busesEl = document.getElementById('buses');
    
    stopNameEl.textContent = '';
    busesEl.replaceChildren();
    
    try {
        const busInfo = await fetch(`http://localhost:3030/jsonstore/bus/businfo/${idEl.value}`);
        
        if (busInfo.status !== 200) {
            stopNameEl.textContent = 'Error';
            return;
        }
        const data = await busInfo.json();
        stopNameEl.textContent = data.name;
        for (const bus in data.buses) {
            const liEl = document.createElement('li');
            liEl.textContent = `Bus ${bus} arrives in ${data.buses[bus]} minutes`;
            busesEl.appendChild(liEl);
        }
    } catch (error) {
        stopNameEl.textContent = 'Error';
    }
}