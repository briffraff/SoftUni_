import { getAllIdeas } from '../scripts/data.js';
import { cre, isEmpty } from '../scripts/dom.js';
import { constants as gc } from '../scripts/globalConstants.js';

const viewName = gc.views.catalog;
const viewId = 'dashboard-holder';
const view = document.getElementById(viewId);
view.remove();

view.addEventListener('click', onDetails);

let ctx = null;

export async function showCatalogView(ctxTarget) {
    ctx = ctxTarget;
    ctx.showView(view);
    loadIdeas();
}

async function loadIdeas() {
    let loading = cre('p', {}, 'Loading..');
    view.replaceChildren(loading);
    const ideas = await getAllIdeas();

    if (ideas.length == 0) {
        let element = cre('h1', {}, 'No ideas yet! Be the first one :)');
        view.replaceChildren(element);
    }
    else {
        let fragment = document.createDocumentFragment();

        ideas.map(createIdeaCard)
            .forEach(idea => fragment.appendChild(idea));

        view.replaceChildren(fragment);
    }
}

function createIdeaCard(idea) {
    const element = cre('div', { className: 'card overflow-hidden current-card details' });
    element.style.width = '20rem';
    element.style.height = '18rem';

    element.innerHTML =
        `
            <div class="card-body">
                <p class="card-text">${idea.title}</p>
            </div>
            <img class="card-image" src="${idea.img}" alt="Card image cap">
            <a data-id="${idea._id}" class="btn" href="">Details</a>
        `;

    return element;
}

function onDetails(event) {
    if (event.target.tagName == 'A') {
        const id = event.target.dataset.id;
        event.preventDefault();
        ctx.goTo(gc.views.details, id);
    }
}