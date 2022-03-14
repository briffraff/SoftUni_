//  imports
import { logout, gc } from './data.js';
import { page, render } from './lib.js';
import { getUserData } from './service.js';

import { homeView } from '../views/home.js';
import { createView } from '../views/create.js';
import { myFurnitureView } from '../views/my-furniture.js';
import { detailsView } from '../views/details.js';
import { editView } from '../views/edit.js';
import { loginView } from '../views/login.js';
import { registerView } from '../views/register.js';

// import * as data from './data.js';
// window.data = data;

document.querySelector('#logoutBtn').addEventListener('click', onLogout);

let root = document.querySelector('div.container');
let nav = document.querySelector('header nav');

// navigation
page(decorateContext);
page(gc.nav.home, homeView);
page(gc.nav.create, createView);
page(gc.nav.my, myFurnitureView);
page(gc.nav.details, detailsView);
page(gc.nav.edit, editView);
page(gc.nav.login, loginView);
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
        nav.querySelector('#user').style.display = 'inline-block';
        nav.querySelector('#guest').style.display = 'none';
    } else {
        nav.querySelector('#user').style.display = 'none';
        nav.querySelector('#guest').style.display = 'inline-block';
    }
}