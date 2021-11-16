//imports
import { showView } from '../dom.js';
import { globalConstants as gc } from '../globalConstants.js';
import * as crud from '../service.js';
import { cre } from '../dom.js';
import { showHome } from './home.js';
import { showEditMovieView as shoeEdit } from './editMovie.js';


//initialization 
let detailsMovieView = document.querySelector(gc.detailsId);

//detach from dom
detailsMovieView.remove();

// export view
export function showDetailsMovieView(id) {
    showView(detailsMovieView);
    loadMovie(id);
}

async function loadMovie(id) {

    try {
        detailsMovieView.replaceChildren(cre('p', {}, 'Loading ...'));

        let url = `${gc.localhost}${gc.movieUrl}${id}`;
        let movieDetails = await crud.GET(url);

        let likesUrl = gc.localhost + `data/likes?where=movieId%3D%22${id}%22&distinct=_ownerId&count`;
        let likes = await crud.GET(likesUrl);
        let hasLiked = '';

        //userData
        const userData = JSON.parse(sessionStorage.getItem('userData'));

        if (userData != null) {
            let likeUrl = gc.localhost + `data/likes?where=movieId%3D%22${id}%22%20and%20_ownerId%3D%22${userData.id}%22`;
            hasLiked = await crud.GET(likeUrl);
        }

        let movie = createMovieDetails(movieDetails, likes, hasLiked, userData);
        detailsMovieView.replaceChildren(movie);


        //  DELETE / EDIT
        //  if user is logged in and is owner of the movie
        if (userData != null && movieDetails._ownerId == userData.id) {
            detailsMovieView.querySelector('#delete').addEventListener('click', await onDelete);
            detailsMovieView.querySelector('#edit').addEventListener('click', await onEdit);
        }

        // LIKE / UNLIKE
        // if the user is logged in and is NOT owner of the movie
        if (userData != null && movieDetails._ownerId != userData.id) {
            if (hasLiked.length == 0) {
                detailsMovieView.querySelector('#like').addEventListener('click', onLike);
            }
            else {
                detailsMovieView.querySelector('#unlike').addEventListener('click', onUnlike);
            }
        }

        async function onEdit() {
            console.log('Edit');
            shoeEdit(id);
        }

        async function onDelete() {
            console.log('delete OK!');
            await fetch(url, {
                method: 'DELETE',
                headers: {
                    'X-Authorization': userData.token,
                },
            });
            showHome();
        }

        async function onLike() {
            console.log('like');

            let lurl = 'http://localhost:3030/data/likes';
            let data = {
                movieId: id
            };

            await fetch(lurl, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                    'X-Authorization': userData.token,
                },
                body: JSON.stringify(data)
            });

            showDetailsMovieView(id);
        }

        async function onUnlike() {
            console.log('unlike');
            let likeId = hasLiked[0]._id;

            let unlikesUrl = 'http://localhost:3030/data/likes/' + likeId;
            await fetch(unlikesUrl, {
                method: 'DELETE',
                headers: {
                    'X-Authorization': userData.token,
                },
            });

            showDetailsMovieView(id);
        }

    } catch (error) {
        alert(error.message);
    }
}

function createMovieDetails(movie, likes, hasLiked, userData) {
    let container = cre('div', { className: 'container' });

    let deleteBtn = '<a id="delete" class="btn btn-danger" href="#">Delete</a>';
    let editBtn = '<a id="edit" class="btn btn-warning" href="#">Edit</a>';
    let likeBtn = '<a id="like" class="btn btn-primary" href="#">Like</a>';
    let unlikeBtn = '<a id="unlike" class="btn btn-primary" href="#">Unlike</a>';
    let liked = `<span class="enrolled-span">Liked ${likes}</span>`;

    let buttons = '';

    //logged user
    if (userData != null) {
        // if user has already liked movie
        if (hasLiked.length == 0) {
            buttons = `${likeBtn} ${liked}`;
        }
        else {
            buttons = `${unlikeBtn} ${liked}`;
        }

        // if logged user is owner of the movie
        if (movie._ownerId == userData.id) {
            buttons = `${deleteBtn} ${editBtn} ${liked}`;
        }
    }
    //not logged
    else {
        buttons = `${liked}`;
    }

    let controls =
        `<div class="col-md-4 text-center">
            <h3 class="my-3 ">Movie Description</h3>
            <p>${movie.description}</p>
            ${buttons}
        </div>`;

    container.innerHTML =
        `<h1>Movie title: ${movie.title}</h1>
        <div class="row bg-light text-dark">
            <div class="col-md-8">
            <img class="img-thumbnail" src="${movie.img}" alt="Movie">
            </div>
            ${controls}
        </div>`;

    return container;
}


