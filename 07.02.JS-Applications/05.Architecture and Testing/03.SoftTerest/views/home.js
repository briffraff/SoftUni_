import { constants as gc } from '../scripts/globalConstants.js';

const viewName = gc.views.home;
const viewId = viewName + 'View';
const view = document.getElementById(viewId);
view.remove();

view.querySelector(gc.nav.getStartedNav).addEventListener('click', (ev) => {
    ev.preventDefault();
    ctx.goTo(gc.views.catalog);
});

let ctx = null;

export async function showHomeView(ctxTarget) {
    ctx = ctxTarget;
    ctx.showView(view);
}