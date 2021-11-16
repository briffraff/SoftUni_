//imports
import { globalConstants as gc } from '../globalConstants.js';
import * as crud from '../service.js';
import { cre, showView } from '../dom.js';
import { showAddMovieView } from './addMovie.js';
import { showDetailsMovieView } from './detailsMovie.js';

//initialization 
let homeView = document.querySelector(gc.homeId);
//detach from dom
homeView.remove();

//initialize addMovieBtn
let addMovieBtn = homeView.querySelector(gc.addMovieBtnId);
addMovieBtn.addEventListener('click', onAddMovie);

function updateAddMovieBtn() {
    const userData = JSON.parse(sessionStorage.getItem('userData'));
    if (userData != null) {
        addMovieBtn.style.display = 'inner-sblock';
    }
    else {
        addMovieBtn.style.display = 'none';
    }
}

//  add movie event
function onAddMovie(event) {
    event.preventDefault();
    showAddMovieView();
}

//  movie catalog container
let catalog = homeView.querySelector('.card-deck.d-flex.justify-content-center');
catalog.addEventListener('click', onDetails);

//  details for clicked film
function onDetails(event) {
    let target = event.target;
    if (target.tagName == 'BUTTON' && target.textContent.includes('Details')) {
        let targetId = target.dataset.id;
        showDetailsMovieView(targetId);
    }
}

async function loadMovies() {
    // LOADING
    catalog.replaceChildren(cre('p', {}, gc.loading));

    let url = `${gc.localhost}${gc.movieUrl}`;
    // console.log(url);
    // getMovies
    try {
        let movies = await crud.GET(url);
        catalog.replaceChildren(...movies.map(movie => createMovieCard(movie)));

    } catch (error) {
        alert(error.message);
    }
}

function createMovieCard(movie) {
    let card = cre('div', { className: 'card mb-4' });
    card.innerHTML = `
        <img class="card-img-top" src="${movie.img}" alt="Card image cap" width="400">
        <div class="card-body">
            <h4 class="card-title">${movie.title}</h4>
        </div>
        <div class="card-footer">
            <a href="#">
                <button data-id="${movie._id}" type="button" class="btn btn-info">Details</button>
            </a>
        </div>`;

    return card;
}

// export view
export function showHome() {
    showView(homeView);
    updateAddMovieBtn();
    loadMovies();
}