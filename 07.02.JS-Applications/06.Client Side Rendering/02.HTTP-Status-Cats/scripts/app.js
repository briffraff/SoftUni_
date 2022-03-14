import { html, render } from '../node_modules/lit-html/lit-html.js';
import { cats } from './catSeeder.js';

let allcatsSection = document.querySelector('#allCats');

// move files to folders
// fix paths
// init project ..... npm init -y
// add lit-html .... npm install lit-html

const catinfo = (cat) => html`
<div class="status" id="${cat.id}">
    <h4>Status Code: ${cat.statusCode}</h4>
    <p>${cat.statusMessage}</p>
</div>`;

const catCard = (cat) => html`
    <li>
        <img src="./images/${cat.imageLocation}.jpg" width="250" height="250" alt="Card image cap">
        <div class="info">
            <button @click=${() => showInfo(cat)} class="showBtn">${cat.show ? 'Hide' : 'Show'} status code</button>
            ${cat.show ? catinfo(cat) : null}
        </div>
    </li>`;

const ulCats = (cats) => html`
    <ul>
        ${cats.map(catCard)}
    </ul>
`;

cats.forEach(c => c.show = false);
update();

function update() {
    render(ulCats(cats), allcatsSection);
}

function showInfo(cat) {
    cat.show = !cat.show;
    update();
}

























