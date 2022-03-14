import { getByName } from "../scripts/data.js";
import { html, until, nothing } from "../scripts/lib.js";

let searchTemplate = (onSearch) => html`
    <!--Search Page-->
    <section id="searchPage">
        <h1>Search by Name</h1>
    
        <div class="search">
            <input id="search-input" type="text" name="search" placeholder="Enter desired albums's name">
            <button @click="${onSearch}" class="button-list">Search</button>
        </div>
    </section>`;

let result = (onSearch, albumsPromise) => html`
    ${searchTemplate(onSearch)}
    
    <!--Show after click Search button-->
    <div class="search-result">
        <h2>Results:</h2>
        ${until(albumsPromise, html`<p class="no-result">Loading...</p>`)}
    </div>`;

let noresult = (onSearch) => html`
    ${searchTemplate(onSearch)}
    
    <!--Show after click Search button-->
    <div class="search-result">
        <h2>Results:</h2>
        ${html`<p class="no-result">No result.</p>`}
    </div>`;

let buttons = (album) => html`
    <div class="btn-group">
        <a href="/details/${album._id}" id="details">Details</a>
    </div>`;

let albumTemplate = (album, isLogged) => html`
    <!--If have matches-->
    <div class="card-box">
        <img src="${album.imgUrl}">
        <div>
            <div class="text-center">
                <p class="name">Name: ${album.name}</p>
                <p class="artist">Artist: ${album.artist}</p>
                <p class="genre">Genre: ${album.genre}</p>
                <p class="price">Price: $${album.price}</p>
                <p class="date">Release Date: ${album.releaseDate}</p>
            </div>
            <!--buttons-->
            ${isLogged != null ? html`${buttons(album)}` : nothing}
        </div>
    </div>`;


export function searchView(ctx) {
    // render search form
    ctx.render(searchTemplate(onSearch))

    // render init state
    update();

    // render updates on screen
    async function update() {
        let searchField = document.querySelector('#search-input');
        let searchValue = searchField.value;
        let albums = await loadItems(searchValue);

        // result
        if (searchValue != '' && albums.length >= 1) {
            let mappedAlbums = albums.map(a => albumTemplate(a, ctx.getUserData()));
            ctx.render(result(onSearch, mappedAlbums))
        }
        // no result
        else {
            ctx.render(noresult(onSearch))
        }
    }

    // search event 
    function onSearch(event) {
        event.preventDefault();
        update();
    }

    // get items
    async function loadItems(searchValue) {
        let foundAlbums = await getByName(searchValue);
        return foundAlbums;
    }
}

