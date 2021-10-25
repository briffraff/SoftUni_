function create(words) {

    let input = words;

    let contentDiv = document.getElementById('content');

    for (const element of input) {

        let div = document.createElement('div');
        let p = document.createElement('p');
        p.textContent = element;
        p.style.display = 'none';

        div.appendChild(p);
        div.addEventListener('click', showP);

        contentDiv.appendChild(div);

        function showP(ev) {
            let clickedElement = ev.currentTarget;
            let p = clickedElement.children[0];
            p.style.display = '';
        }
    }
}
