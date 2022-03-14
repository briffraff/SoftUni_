import { getAll } from "../scripts/data.js";
import { html, until } from "../scripts/lib.js";

let count = null;
let isLoggedUser = null;

let catalogTemplate = (albumsPromise) => html`
    <!--Catalog-->
    <section id="catalogPage">
        <h1>All Albums</h1>
    
        ${until(albumsPromise, html`<p>Loading...</p>`)}
    
        <!--No albums in catalog-->
        ${count == 0 ? html`<p>No Albums in Catalog!</p>` : null}
    </section>`;

let albumTemplate = (album, isLoggedUser) => html`
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

        ${isLoggedUser ? html`
        <div class="btn-group">
            <a href="/details/${album._id}" id="details">Details</a>
        </div>` : null}
    </div>
</div>`;

export function catalogView(ctx) {
    console.log('catalog view');
    ctx.render(catalogTemplate(loadItems(ctx)));
}

async function loadItems(ctx) {
    isLoggedUser = ctx.getUserData();

    let getAlbums = await getAll();
    // let getAlbums = [];

    count = getAlbums.length;

    let mappedAlbums = getAlbums.map(a => albumTemplate(a, isLoggedUser));
    return mappedAlbums;
}
