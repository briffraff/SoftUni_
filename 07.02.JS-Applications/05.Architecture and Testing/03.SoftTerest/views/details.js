import { deleteById, getById } from '../scripts/data.js';
import { cre } from '../scripts/dom.js';
import { constants as gc } from '../scripts/globalConstants.js';

const viewName = gc.views.details;
const viewId = viewName + 'View';
const view = document.getElementById(viewId);
view.remove();

let ctx = null;

export async function showDetailsView(ctxTarget, id) {
    ctx = ctxTarget;
    ctx.showView(view);
    loadIdea(id);
}

async function loadIdea(id) {
    let loading = cre('p', {}, 'Loading..');
    view.replaceChildren(loading);

    const idea = await getById(id);
    createIdeaDetails(idea);

}

function createIdeaDetails(idea) {
    let userData = JSON.parse(sessionStorage.getItem('userData'));

    let img = `<img class="det-img" src="${idea.img}" />`;
    let description =
        `<div class="desc">
            <h2 class="display-5">${idea.title}</h2>
            <p class="infoType">Description:</p>
            <p class="idea-description">${idea.description}</p>
        </div>`;
    let controls =
        `<div class="text-center">
            <a class="btn detb" href="">Delete</a>
        </div>`;

    let result = '';

    if (userData != null && userData.id == idea._ownerId) {
        result = `${img}\n${description}\n${controls}`;
    } else {
        result = `${img}\n${description}\n`;
    }

    var fragment = document.createRange().createContextualFragment(result);
    view.replaceChildren(fragment);

    if (userData != null && userData.id == idea._ownerId) {

        let deleteBtn = view.querySelector('a.btn');
        deleteBtn.addEventListener('click', onDelete);

        async function onDelete(event) {
            event.preventDefault();
            const confirmed = confirm('Are you sure you want to delete this idea?');
            if (deleteBtn.tagName == 'A' && confirmed) {
                await deleteById(idea._id);
                ctx.goTo(gc.views.catalog);
            }
        }
    }

}

