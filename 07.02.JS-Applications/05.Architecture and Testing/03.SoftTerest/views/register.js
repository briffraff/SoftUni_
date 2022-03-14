import { register } from '../scripts/data.js';
import { constants as gc } from '../scripts/globalConstants.js';

const viewName = gc.views.register;
const viewId = viewName + 'View';
const view = document.getElementById(viewId);
view.remove();

let form = view.querySelector('form');
form.addEventListener('submit', onSubmit);

let ctx = null;

async function onSubmit(event) {
    event.preventDefault();

    let formData = new FormData(form);

    let email = formData.get('email').trim();
    let password = formData.get('password').trim();
    let repeatPassword = formData.get('repeatPassword').trim();

    if (email != '') {
        if (password == repeatPassword) {
            await register(email, password);
        }
        else {
            alert('Passwords not match');
        }
    } else {
        alert('Check your input info!');
        return;
    }
    form.reset();

    ctx.goTo(gc.views.home);
    ctx.updateNav();
}

export async function showRegisterView(ctxTarget) {
    ctx = ctxTarget;
    ctx.showView(view);
}