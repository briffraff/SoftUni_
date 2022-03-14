//  imports
import { logout, gc } from './data.js';
import { page, render } from './lib.js';
import { getUserData } from './service.js';

import { homeView } from '../views/home.js';
import { catalogView } from '../views/catalog.js';
import { registerView } from '../views/register.js';
import { loginView } from '../views/login.js';
import { editView } from '../views/edit.js';
import { detailsView } from '../views/details.js';
import { createView } from '../views/create.js';
import { searchView } from '../views/search.js';


import * as data from './data.js';
window.data = data;

document.querySelector('#logoutNav').addEventListener('click', onLogout);

let root = document.querySelector('#main-content');
let nav = document.querySelector('header nav');

// navigation
page(decorateContext);
page("/", homeView); //<----
page(gc.nav.home, homeView);
page(gc.nav.create, createView);
page(gc.nav.catalog, catalogView);
page(gc.nav.details, detailsView);
page(gc.nav.edit, editView);
page(gc.nav.login, loginView);
page(gc.nav.search, searchView);
page(gc.nav.register, registerView);

//  start application
updateUserNav();
page.start();

function decorateContext(ctx, next) {
    ctx.render = (content) => render(content, root);
    ctx.updateUserNav = updateUserNav;
    ctx.getUserData = getUserData;
    next();
}

async function onLogout(event) {
    if (event.target.textContent.toLowerCase() == 'logout') {
        await logout();
        page.redirect(gc.nav.home);
    }
    updateUserNav();
}

function updateUserNav() {
    let userData = getUserData();
    if (userData) {
        [...nav.querySelectorAll('.user')].forEach(button => button.style.display = 'inline');
        [...nav.querySelectorAll('.guest')].forEach(button => button.style.display = 'none');
    } else {
        [...nav.querySelectorAll('.user')].forEach(button => button.style.display = 'none');
        [...nav.querySelectorAll('.guest')].forEach(button => button.style.display = 'inline');
    }
}