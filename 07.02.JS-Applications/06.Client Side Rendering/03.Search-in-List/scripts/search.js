import { html, render } from '../node_modules/lit-html/lit-html.js';
import { towns as townNames } from './towns.js';

let towns = townNames.map(t => ({ name: t, match: false }));

let allTowns = document.querySelector('#towns');
let searchField = document.querySelector('#searchText')
let result = document.querySelector('#result')
let searchButton = document.querySelector('input+button');

searchButton.addEventListener('click', onSearch);


function onSearch(event) {
    event.preventDefault();

    let searchPattern = searchField.value.trim().toLowerCase();
    towns.map(t => t.match = searchPattern && t.name.toLowerCase().includes(searchPattern));
    let matches = towns.filter(t => searchPattern && t.name.toLowerCase().includes(searchPattern)).length;
    result.textContent = `${matches} matches found`;

    update();
}

let townsTemplate = (towns) => html`
    <ul>
        ${towns.map(town => html`<li class=${town.match ? 'active' : '' }>${town.name}</li>`)}
    </ul>
    `;

update();
function update() {
    render(townsTemplate(towns), allTowns);
}

