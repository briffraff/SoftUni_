//imports
import { showView } from '../dom.js';
import { globalConstants as gc } from '../globalConstants.js';
import { showHome } from './home.js';
import { findEmpty } from '../dom.js';

//initialization 
let addMovieView = document.querySelector(gc.addMovieId);

//detach from dom
addMovieView.remove();

let form = addMovieView.querySelector('form');
form.addEventListener('submit', onAdd);


async function onAdd(event) {
    let userData = JSON.parse(sessionStorage.getItem('userData'));

    event.preventDefault();
    let url = `${gc.localhost}${gc.movieUrl}`;

    let formData = new FormData(form);
    let title = formData.get('title').trim();
    let description = formData.get('description').trim();
    let imageUrl = formData.get('imageUrl').trim();

    // validations
    let isEmpty = [title, description, imageUrl].some(x => x == '');

    if (isEmpty) {
        let result = findEmpty(addMovieView, 'input', 'textarea');
        alert(result);
        return;
    }

    let movie = {
        // '_ownerId': userData.id,
        title,
        description,
        'img': imageUrl,
        // '_createdOn': Date.now(),
    };

    try {
        await createMovie(url, movie, userData);

        form.reset();
        showHome();

    } catch (error) {
        alert(error.message);
    }
}

async function createMovie(url, data ,userData) {
    await fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': userData.token,
        },
        body: JSON.stringify(data)
    });
}

// export view
export function showAddMovieView() {
    showView(addMovieView);

}