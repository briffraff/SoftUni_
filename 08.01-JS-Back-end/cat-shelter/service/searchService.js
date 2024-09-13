const formidable = require('formidable');
const catService = require('./catService');

async function search(query) {
    const cats = await catService.getCats();
    var searchResult = "";

    if (query !== "") {
        searchResult = cats.filter(c => c.breed.toLowerCase().includes(query.toLowerCase()));
    }

    return searchResult;
}

async function generateSearchBarHTML() {
    return `      
        <form action="/search" method="POST">
            <input type="text" name="search">
            <button type="submit">Search</button>
        </form>`
}

module.exports = {
    search,
    generateSearchBarHTML
}