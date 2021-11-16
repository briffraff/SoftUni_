//imports
import { globalConstants as gc } from './globalConstants.js';
import { showHome } from './views/home.js';
import { showLogin } from './views/login.js';
import { showRegister } from './views/register.js';
// import { showEditMovieView } from './views/editMovie.js';
// import { showDetailsMovieView } from './views/detailsMovie.js';
// import { showAddMovieView } from './views/addMovie.js';

//initialize navigation
let nav = document.querySelector(gc.navId);
nav.addEventListener('click', onNavigate);

// all views
let views = {
    'homeNav': showHome,
    'loginNav': showLogin,
    'registerNav': showRegister,
    'logoutNav': logOut,
    // '': showEditMovieView,
    // '': showDetailsMovieView,
    // '': showAddMovieView,
};

// navigating across the nav and views
function onNavigate(event) {
    if (event.target.tagName == 'A') {
        const view = views[event.target.id];
        if (typeof (view) == 'function') {
            event.preventDefault();
            view();
        }
    }
}

updateNav();

//start application view
showHome();

export function updateNav() {
    const userData = JSON.parse(sessionStorage.getItem('userData'));

    if (userData != null) {
        let span = nav.querySelector('#welcomeName');
        span.textContent = `${userData.email}`;

        [...nav.querySelectorAll('.user')].forEach(button => button.style.display = 'block');
        [...nav.querySelectorAll('.guest')].forEach(button => button.style.display = 'none');
    }
    else {
        [...nav.querySelectorAll('.user')].forEach(button => button.style.display = 'none');
        [...nav.querySelectorAll('.guest')].forEach(button => button.style.display = 'block');
    }
}

async function logOut() {
    const userData = JSON.parse(sessionStorage.getItem('userData'));
    let url = `${gc.localhost}${gc.logOut}`;

    await fetch(url, {
        headers: {
            'X-Authorization': JSON.stringify(userData),
        }
    });

    sessionStorage.removeItem('userData');
    updateNav();
    showLogin();
}
