import { createIdea } from '../scripts/data.js';
import { constants as gc } from '../scripts/globalConstants.js';

const viewName = gc.views.create;
const viewId = viewName + 'View';
const view = document.getElementById(viewId);
view.remove();

const form = view.querySelector('form');
form.addEventListener('submit', onCreate);

let ctx = null;

export async function showCreateView(ctxTarget) {
    ctx = ctxTarget;
    ctx.showView(view);
}

async function onCreate(event) {
    event.preventDefault();
    let userData = JSON.parse(sessionStorage.getItem(gc.userData));
    if (userData != null) {
        let formData = new FormData(form);

        let title = formData.get('title').trim();
        let description = formData.get('description').trim();
        let img = formData.get('imageURL').trim();

        if (title.length < 6) {
            return alert('Tittle must be at least 6 characters long');
        }
        if (description.length < 10) {
            return alert('Description must be at least 10 characters long');
        }
        if (img.length < 5) {
            return alert('Image url must be at least 5 characters long');
        }

        await createIdea({ title, description, img });
        form.reset();
        ctx.goTo(gc.views.catalog);
    }

}