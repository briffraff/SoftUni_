import { gc } from "../scripts/data.js";
import { findEmpty } from "../scripts/dom.js";
import { html } from "../scripts/lib.js";

let createTemplate = (onSubmit, errorMsg, empties) => html`
        <div class="row space-top">
            <div class="col-md-12">
                <h1>Create New Furniture</h1>
                <p>Please fill all fields.</p>
            </div>
        </div>
        <form @submit="${onSubmit}">
            <div class="row space-top">
                <div class="col-md-4">
                    <div class="form-group error">${errorMsg}</div>
                    <div class="form-group">
                        <label class="form-control-label" for="new-make">Make</label>
                        <input class=${errorMsg == '' || !empties.includes('make') ? 'form-control' : 'form-control is-invalid' } id="new-make" type="text" name="make">
                    </div>
                     <div class="form-group has-success">
                        <label class="form-control-label" for="new-model">Model</label>
                        <input class=${errorMsg == '' || !empties.includes('model') ? 'form-control' : 'form-control is-invalid' } id="new-model" type="text" name="model">
                    </div>
                    <div class="form-group has-danger">
                        <label class="form-control-label" for="new-year">Year</label>
                        <input class=${errorMsg == '' || !empties.includes('year') ? 'form-control' : 'form-control is-invalid'} id=" new-year" type="number" name="year">
                    </div>
                    <div class="form-group">
                        <label class="form-control-label" for="new-description">Description</label>
                        <input class=${errorMsg == '' || !empties.includes('description') ? 'form-control' : 'form-control is-invalid' } id="new-description" type="text" name="description">
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <label class="form-control-label" for="new-price">Price</label>
                        <input class=${errorMsg == '' || !empties.includes('price') ? 'form-control' : 'form-control is-invalid' } id="new-price" type="number" name="price">
                    </div>
                    <div class="form-group">
                        <label class="form-control-label" for="new-image">Image</label>
                        <input class=${errorMsg == '' || !empties.includes('img') ? 'form-control' : 'form-control is-invalid' } id="new-image" type="text" name="img">
                    </div>
                    <div class="form-group">
                        <label class="form-control-label" for="new-material">Material (optional)</label>
                        <input class=${errorMsg == '' || !empties.includes('material') ? 'form-control' : 'form-control is-invalid' } id="new-material" type="text" name="material">
                    </div> 
                    <input type="submit" class="btn btn-primary" value="Create" />
                </div>
            </div>
        </form>`;

export function createView(ctx) {
    console.log('create view');

    update();
    function update(errorMsg = '', empties = '') {
        ctx.render(createTemplate(onSubmit, errorMsg, empties))
    }

    async function onSubmit(event) {
        event.preventDefault();

        let formData = new FormData(event.target);
        //TODO

        let empties = findEmpty(document.querySelector('form'), 'input');

        try {
            //TODO
            throw new Error("Temporary Error!");

            ctx.updateUserNav();
            ctx.page.redirect(gc.nav.home);
        } catch (err) {
            let error = err.message;
            update(error, empties);
        }
    }
}
