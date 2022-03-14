//  imports
import { constants as gc } from './globalConstants.js';
import { showView } from './dom.js';
import { showHomeView } from '../views/home.js';
import { showCatalogView } from '../views/catalog.js';
import { showCreateView } from '../views/create.js';
import { showDetailsView } from '../views/details.js';
import { showLoginView } from '../views/login.js';
import { showRegisterView } from '../views/register.js';
import { logout } from './api.js';

// navigation
const links = {
    'homeNav': gc.views.home,
    'catalogNav': gc.views.catalog,
    'createNav': gc.views.create,
    'loginNav': gc.views.login,
    'registerNav': gc.views.register,
};

const views = {
    'home': showHomeView,
    'dashboard-holder': showCatalogView,
    'create': showCreateView,
    'login': showLoginView,
    'register': showRegisterView,
    'details': showDetailsView,
};

// get nav
const nav = document.querySelector('nav');
nav.addEventListener('click', onNav);

//  logout button
const logoutNav = nav.querySelector(gc.nav.logout);
logoutNav.addEventListener('click', Logout);

// context
const ctx = {
    goTo,
    showView,
    updateNav
};

updateNav();
//  start application
goTo(gc.views.home);

function onNav(event) {
    const name = links[event.target.id];
    if (name) {
        event.preventDefault();
        goTo(name);
    }
}

function goTo(name, ...params) {
    const view = views[name];
    if (typeof view == 'function') {
        view(ctx, ...params);
    }
}

function updateNav() {
    let userData = JSON.parse(sessionStorage.getItem(gc.userData));
    if (userData != null) {
        [...nav.querySelectorAll('.user')].forEach(button => button.style.display = 'block');
        [...nav.querySelectorAll('.guest')].forEach(button => button.style.display = 'none');
    }
    else {
        [...nav.querySelectorAll('.user')].forEach(button => button.style.display = 'none');
        [...nav.querySelectorAll('.guest')].forEach(button => button.style.display = 'block');
    }
}

async function Logout(event) {
    let userData = JSON.parse(sessionStorage.getItem(gc.userData));

    if (userData != null) {
        if ('#' + event.target.id == gc.nav.logout) {
            event.preventDefault();
            await logout();
        }

        setTimeout(() => updateNav(), 300);
        setTimeout(() => goTo(gc.views.home), 300);
    }
}