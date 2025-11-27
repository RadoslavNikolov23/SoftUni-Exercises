document.addEventListener('DOMContentLoaded', solve);

function solve() {

    const conversionRates = {
        "km": 1000,
        "m": 1,
        "cm": 0.01,
        "mm": 0.001,
        "mi": 1609.34,
        "yrd": 0.9144,
        "ft": 0.3048,
        "in": 0.0254
    };

    const inputDistanceField = document.querySelector('#inputDistance');
    const inputUnitSelect = document.querySelector('#inputUnits');

    const outputUnitSelect = document.querySelector('#outputUnits');
    const outputDistanceField = document.querySelector('#outputDistance');
    
    const convertButton = document.querySelector('#convert');

    convertButton.addEventListener('click', convertUnitToDistance);

    function convertUnitToDistance(event) {
        event.preventDefault();
        event.stopPropagation();

        const inputDistance = Number(inputDistanceField.value);
        const inputUnit = inputUnitSelect.value;
        const outputUnit = outputUnitSelect.value;

        const distanceInMeters = inputDistance * conversionRates[inputUnit];
        const convertedDistance = distanceInMeters / conversionRates[outputUnit];

        outputDistanceField.value = convertedDistance;
    }
}