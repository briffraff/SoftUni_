//imports
import { globalConstants as gc } from '../globalConstants.js';
import { showView, isEmpty } from '../dom.js';
import * as crud from '../service.js';
import { showHome } from './home.js';
import { updateNav } from '../app.js';

//initialization 
let registerView = document.querySelector(gc.registerId);

//detach from dom
registerView.remove();

let form = registerView.querySelector('form');
form.reset();
form.addEventListener('submit', onRegister);

async function onRegister(event) {
    event.preventDefault();

    let formData = new FormData(form);
    let email = formData.get('email').trim();
    let password = formData.get('password').trim();
    let repeatPassword = formData.get('repeatPassword').trim();

    // validations
    let isEmpty = [email, password, repeatPassword].some(x => x == '');
    let isPassLenght = password.length >= 6;
    let isEqualPass = password == repeatPassword;

    if (isEmpty == false) {
        if (isPassLenght) {
            if (isEqualPass == false) {
                alert('Password dont match!');
                return;
            }
        }
        else {
            alert('Password must be 6 or more symbols!');
            return;
        }
    }
    else {
        let emptyInputs = [...form.querySelectorAll('input')].filter(f => f.value == '');
        let result = 'Empty fields! : ';
        emptyInputs.forEach(f => result += `\n- ${f.placeholder.replace('-', ' ')}`);
        alert(result);
        return;
    }

    let url = `${gc.localhost}${gc.registerUrl}`;
    let user = { email, password, repeatPassword };

    try {
        let data = await crud.POST(url, user, gc.postMsg);
        debugger;
        console.log(data.accessToken);

        sessionStorage.setItem('userData', JSON.stringify({
            email: data.email,
            id: data._id,
            token: data.accessToken,
        }));

        form.reset();
        updateNav();
        showHome();

    } catch (error) {
        alert(error.message);
    }
}

// export view
export function showRegister() {
    showView(registerView);
}