import { login } from '../scripts/data.js';
import { constants as gc } from '../scripts/globalConstants.js';

const viewName = gc.views.login;
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

    await login(email, password);

    form.reset();
    ctx.goTo(gc.views.home);
    ctx.updateNav();
}

export async function showLoginView(ctxTarget) {
    ctx = ctxTarget;
    ctx.showView(view);
}