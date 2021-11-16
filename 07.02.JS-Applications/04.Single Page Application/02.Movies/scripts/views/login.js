//imports
import { globalConstants as gc } from '../globalConstants.js';
import { showView, findEmpty } from '../dom.js';
import * as crud from '../service.js';
import { showHome } from './home.js';
import { updateNav } from '../app.js';

//initialization 
let loginView = document.querySelector(gc.loginId);

//detach from dom
loginView.remove();

// get form 
let form = loginView.querySelector('form');
form.reset();
form.addEventListener('submit', onLogin);

async function onLogin(event) {
    event.preventDefault();

    let formData = new FormData(form);
    let email = formData.get('email').trim();
    let password = formData.get('password').trim();

    let isEmpty = [email, password,].some(x => x == '');
    if (isEmpty) {
        let result = findEmpty(loginView, 'input', 'textarea');
        alert(result);
        return;
    }

    let url = `${gc.localhost}${gc.usersUrl}`;
    let user = { email, password };

    try {
        let data = await crud.POST(url, user, gc.postMsg);
        sessionStorage.setItem('userData', JSON.stringify({
            email: data.email,
            id: data._id,
            token: data.accessToken
        }));

        form.reset();
        updateNav();
        showHome();

    } catch (error) {
        alert(error.message);
    }
}


// export view
export function showLogin() {
    showView(loginView);
}