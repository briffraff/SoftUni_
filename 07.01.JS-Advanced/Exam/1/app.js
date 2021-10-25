window.addEventListener('load', solve);

function solve() {
    const inputs = document.querySelectorAll('form input');
    const genre = inputs[0];
    const name = inputs[1];
    const author = inputs[2];
    const date = inputs[3];
    const hitsContainer = document.querySelector('div.all-hits-container');
    const savedSongsContainer = document.querySelector('div.saved-container');
    const totalLikes = document.querySelector('div.likes p');

    const addBtn = document.getElementById('add-btn');
    addBtn.addEventListener('click', addSongs);

    function addSongs(ev) {
        ev.preventDefault();

        if (genre.value == '' || name.value == '' || author.value == '' || date.value == '') {
            return;
        }

        const song = crtel('div', { classList: 'hits-info' },
            crtel('img', { src: './static/img/img.png' }),
            crtel('h2', {}, `Genre: ${genre.value}`),
            crtel('h2', {}, `Name: ${name.value}`),
            crtel('h2', {}, `Author: ${author.value}`),
            crtel('h3', {}, `Date: ${date.value}`),
            crtel('button', { classList: 'save-btn' }, 'Save song'),
            crtel('button', { classList: 'like-btn' }, 'Like song'),
            crtel('button', { classList: 'delete-btn' }, 'Delete'),
        );
        hitsContainer.appendChild(song);

        genre.value = '';
        name.value = '';
        author.value = '';
        date.value = '';

        const btnSave = song.querySelector('button[class="save-btn"]');
        const btnLike = song.querySelector('button[class="like-btn"]');
        const btnDelete = song.querySelector('button[class="delete-btn"]');

        btnSave.addEventListener('click', saveSong.bind(null, song, btnSave, btnLike, btnDelete));
        btnLike.addEventListener('click', likeSong.bind(null, song));
        btnDelete.addEventListener('click', () => { hitsContainer.removeChild(song); });
    }

    function saveSong(song, btnSave, btnLike, btnDelete) {
        const del = crtel('button', { classList: 'delete-btn' }, 'Delete');
        song.removeChild(btnSave);
        song.removeChild(btnLike);
        song.removeChild(btnDelete);
        song.appendChild(del);

        savedSongsContainer.appendChild(song);

        const deleteButton = song.querySelector('button[class="delete-btn"]');
        deleteButton.addEventListener('click', deleteSong);

    }

    function deleteSong(ev) {
        const song = ev.target.parentNode;
        savedSongsContainer.removeChild(song);
    }

    function likeSong(song) {
        let splitInput = totalLikes.textContent.split(': ');
        let total = Number(splitInput[1]); total++;
        splitInput[1] = total;
        totalLikes.textContent = splitInput.join(': ');
        song.querySelector('button[class="like-btn"]').disabled = true;
    }

    function crtel(type, attr, ...content) {
        const element = document.createElement(type);

        for (let prop in attr) {
            element[prop] = attr[prop];
        }
        for (let item of content) {
            if (typeof item == 'string' || typeof item == 'number') {
                item = document.createTextNode(item);
            }
            element.appendChild(item);
        }

        return element;
    }
}