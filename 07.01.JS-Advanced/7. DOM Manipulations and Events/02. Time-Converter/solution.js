function attachEventsListeners() {

    let mainDivs = document.querySelectorAll('main div');
    let daysInput = mainDivs[0].children[1];
    let hoursInput = mainDivs[1].children[1];
    let minutesInput = mainDivs[2].children[1];
    let secondsInput = mainDivs[3].children[1];

    for (const div of mainDivs) {
        let divButton = div.children[2];
        divButton.addEventListener('click', calc);
    }

    let day = 1;
    let hoursPerDay = 24;
    let minutesPerDay = 1440;
    let secondsPerDay = 86400;

    let days = 'days';
    let hours = 'hours';
    let minutes = 'minutes';
    let seconds = 'seconds';

    function calc(evt) {
        let parentInput = evt.target.parentElement.children[1];
        let id = parentInput.id;
        let value = parentInput.value;

        let aDays = 0;

        if (id === nameOf(days)) { aDays = value / day; }
        if (id === nameOf(hours)) { aDays = value / hoursPerDay; }
        if (id === nameOf(minutes)) { aDays = value / minutesPerDay; }
        if (id === nameOf(seconds)) { aDays = value / secondsPerDay; }

        let [d, h, m, s] = [
            aDays,
            aDays * hoursPerDay,
            aDays * minutesPerDay,
            aDays * secondsPerDay
        ];

        daysInput.value = d;
        hoursInput.value = h;
        minutesInput.value = m;
        secondsInput.value = s;
    }

    function nameOf(obj) {
        let temp = {};
        temp[obj] = '';
        return Object.keys(temp)[0];
    }
}
