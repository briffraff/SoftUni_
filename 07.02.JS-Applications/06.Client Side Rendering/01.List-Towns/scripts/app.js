import { html, render } from '../node_modules/lit-html/lit-html.js';

let form = document.querySelector('form')
form.addEventListener('submit', onSubmit);

let townsInput = form.querySelector('#towns');
let root = document.querySelector('#root');

function onSubmit(event) {
    event.preventDefault();

    // make all names and double namedwith first capital letter
    let towns = townsInput.value
        .split(',')
        .map(town => town.trim())
        .map(t => t.split(' ') == 1
            ? t.charAt(0).toUpperCase() + t.slice(1).toLowerCase()
            : t.split(' ')
                .map(n => n.charAt(0).toUpperCase() + n.slice(1).toLowerCase())
                .join(' ')
        )

    render(template(towns), root);
}

const template = (towns) => html`
    <ul>
        ${towns.map(t => html`<li>${t}</li>`)}
        <ul>
`;
