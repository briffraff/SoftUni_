function attachEventsListeners() {
    let inputDistance = document.querySelector('#inputDistance');
    let inputUnits = inputDistance.parentElement.querySelector('select#inputUnits');

    let outputDistance = document.querySelector('#outputDistance');
    let outputUnits = outputDistance.parentElement.querySelector('#outputUnits');

    var convertButton = inputDistance.parentElement.querySelector('input[type=button]');

    convertButton.addEventListener('click', getValues);

    let ratios = {
        'km': 1000,
        'm': 1,
        'cm': 0.01,
        'mm': 0.001,
        'mi': 1609.34,
        'yrd': 0.9144,
        'ft': 0.3048,
        'in': 0.0254,
    };

    function getValues() {
        let input = inputDistance.value;
        let fromUnit = inputUnits.value;
        let toUnit = outputUnits.value;

        function convert(input, fromUnit, toUnit) {
            let distanceToM = input * ratios[fromUnit];
            let result = distanceToM / ratios[toUnit];

            return result;
        }
        
        outputDistance.value = convert(input, fromUnit, toUnit);

    }
}