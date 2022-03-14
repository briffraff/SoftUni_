import { login, gc } from "../scripts/data.js";
import { html } from "../scripts/lib.js";
import { findEmpty } from "../scripts/dom.js";

let loginTemplate = (onSubmit, errorMsg, empties) => html`
    <div class="row space-top">
        <div class="col-md-12">
            <h1>Login User</h1>
            <p>Please fill all fields.</p>
        </div>
    </div>
    <form @submit="${onSubmit}">
        <div class="row space-top">
            <div class="col-md-4">
                <div class="form-group error">${errorMsg}</div>
                <div class="form-group">
                    <label class="form-control-label" for="email">Email</label>
                    <input class=${errorMsg == '' || !empties.includes('email')
                        ? 'form-control'
                        : 'form-control is-invalid' } id="email" type="text" name="email">
                </div>
                <div class="form-group">
                    <label class="form-control-label" for="password">Password</label>
                    <input class=${errorMsg == '' || !empties.includes('password')
                        ? 'form-control'
                        : 'form-control is-invalid' } id="password" type="password" name="password">
                </div>
                <input type="submit" class="btn btn-primary" value="Login" />
            </div>
        </div>
    </form>`;

export function loginView(ctx) {
    console.log('login view');
    update();

    function update(errorMsg = '', empties = '') {
        ctx.render(loginTemplate(onSubmit, errorMsg, empties));
    }

    async function onSubmit(event) {
        event.preventDefault();

        let formData = new FormData(event.target);
        let email = formData.get('email').trim();
        let password = formData.get('password').trim();

        let empties = findEmpty(document.querySelector('form'), 'input');

        try {
            await login(email, password);
            ctx.updateUserNav();
            ctx.page.redirect(gc.nav.home);
        } catch (err) {
            let error = err.message;
            update(error, empties);
        }
    }

}
