function solve() {

    const infoEl = document.getElementsByClassName('info')[0];
    const departBtn = document.getElementById('depart');
    const arriveBtn = document.getElementById('arrive');
    let stop = {
        next: "depot"
    };

    async function depart() {
        try {
            const result = await fetch(`http://localhost:3030/jsonstore/bus/schedule/${stop.next}`);
            if (!result.ok) {
                throw new Error();
            }
            stop = await result.json();
            infoEl.textContent = `Next stop ${stop.name}`;

            departBtn.disabled = true;
            arriveBtn.disabled = false;
        } catch (error) {
            infoEl.textContent = 'Error';
            departBtn.disabled = true;
            arriveBtn.disabled = true;
        }
    }

    function arrive() {
        infoEl.textContent = `Arriving at ${stop.name}`;
        departBtn.disabled = false;
        arriveBtn.disabled = true;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();