//imports
import { showView } from '../dom.js';
import { globalConstants as gc } from '../globalConstants.js';
import { showDetailsMovieView } from './detailsMovie.js';
import { findEmpty } from '../dom.js';

//initialization 
let editMovieView = document.querySelector(gc.editId);

//detach from dom
editMovieView.remove();

// export view
export function showEditMovieView(id) {
    showView(editMovieView);
    editMovie(id);
}

async function editMovie(id) {
    let userData = JSON.parse(sessionStorage.getItem('userData'));

    let form = editMovieView.querySelector('form');
    form.addEventListener('submit', onSubmit);

    let title = form.querySelector('input[name="title"]');
    let description = form.querySelector('textarea[name="description"]');
    let imageUrl = form.querySelector('input[name="imageUrl"]');

    debugger;
    let url = `${gc.localhost}${gc.movieUrl}${id}`;
    let request = await fetch(url);
    let data = await request.json();

    title.value = data.title;
    description.value = data.description;
    imageUrl.value = data.img;

    async function onSubmit(event) {
        event.preventDefault();

        let isEmpty = [title, description, imageUrl].filter(x => x == '');

        if (isEmpty > 0) {
            let result = findEmpty(editMovieView, 'input', 'textarea');
            alert(result);
            return;
        }

        let movie = {
            title: title.value,
            description: description.value,
            img: imageUrl.value,
        };

        try {
            let request = await fetch(url, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json',
                    'X-Authorization': userData.token
                },
                body: JSON.stringify(movie)
            });

            if (request.ok == false) {
                let error = await request.json();
                throw new Error(error.message);
            }

            title.value = '';
            description.value = '';
            imageUrl.value = '';

            showDetailsMovieView(id);
        } catch (err) {
            alert(err.message);
        }
    }
}