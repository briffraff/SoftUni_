import { register, gc } from "../scripts/data.js";
import { html, until } from "../scripts/lib.js";

let registerTemplate = (onSubmit) => html`
    <!--Register Page-->
    <section id="registerPage">
        <form @submit="${onSubmit}" class="registerForm">
            <h2>Register</h2>
            <div class="on-dark">
                <label for="email">Email:</label>
                <input id="email" name="email" type="text" placeholder="steven@abv.bg" value="">
            </div>
    
            <div class="on-dark">
                <label for="password">Password:</label>
                <input id="password" name="password" type="password" placeholder="********" value="">
            </div>
    
            <div class="on-dark">
                <label for="repeatPassword">Repeat Password:</label>
                <input id="repeatPassword" name="repeatPassword" type="password" placeholder="********" value="">
            </div>
    
            <button class="btn" type="submit">Register</button>
    
            <p class="field">
                <span>If you have profile click <a href="/login">here</a></span>
            </p>
        </form>
    </section>
`;

export function registerView(ctx) {
    console.log('register view');

    update();
    function update() {
        ctx.render(registerTemplate(onSubmit));
    }

    async function onSubmit(event) {
        event.preventDefault();

        let formData = new FormData(event.target);
        let email = formData.get('email').trim();
        let password = formData.get('password').trim();
        let confirmPassword = formData.get('repeatPassword').trim();

        if (email != '' && password != '' & confirmPassword != '') {
            if (password == confirmPassword) {
                await register(email, password);
                ctx.updateUserNav();
                ctx.page.redirect(gc.nav.home);
            } else {
                let error = new Error("Password don't match");
                alert(error);
            }
        }

    }
}