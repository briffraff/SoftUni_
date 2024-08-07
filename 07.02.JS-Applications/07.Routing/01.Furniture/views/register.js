import { gc, register } from "../scripts/data.js";
import { findEmpty } from "../scripts/dom.js";
import { html } from "../scripts/lib.js";

let registerTemplate = (onSubmit, errorMsg, empties) => html`
    <div class="container">
        <div class="row space-top">
            <div class="col-md-12">
                <h1>Register New User</h1>
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
                    <div class="form-group">
                        <label class="form-control-label" for="rePass">Repeat</label>
                        <input class=${errorMsg == '' || !empties.includes('rePass')
                            ? 'form-control'
                            : 'form-control is-invalid' } id="rePass" type="password" name="rePass">
                    </div>
                    <input type="submit" class="btn btn-primary" value="Register" />
                </div>
            </div>
        </form>
    </div>`;

export function registerView(ctx) {
    console.log('register view');

    update();

    function update(errorMsg = '', empties) {
        ctx.render(registerTemplate(onSubmit, errorMsg, empties));
    }

    async function onSubmit(event) {
        event.preventDefault();

        let formData = new FormData(event.target);
        let email = formData.get('email').trim();
        let password = formData.get('password').trim();
        let rePass = formData.get('rePass').trim();
        
        let empties = '';

        try {
            empties = findEmpty(document.querySelector('form'), 'input');
            update('', empties);

            if (password == rePass) {
                await register(email, password);
                ctx.updateUserNav();
                ctx.page.redirect(gc.nav.home);
            } else {
                throw new Error("Passwords don't match");
            }

        } catch (err) {
            empties = findEmpty(document.querySelector('form'), 'input');
            let error = err.message;
            update(error, empties);
        }
    }
}