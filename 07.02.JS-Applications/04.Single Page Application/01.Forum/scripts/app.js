import { showHomeView } from './home.js';

document.querySelector('#homeLink').addEventListener('click', onNavigate);

showHomeView();

const sections = {
    'homeView': showHomeView,
};

function onNavigate(event) {
    debugger;
    if (event.target.tagName == 'A') {
        const view = sections[event.target.name];
        if (typeof view == 'function') {
            event.preventDefault();
            view();
        }
    }
}



