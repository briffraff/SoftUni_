import { getAll } from "../scripts/data.js";
import { cre } from "../scripts/dom.js";
import { html, until } from "../scripts/lib.js";
import { getUserData } from "../scripts/service.js";

let catalogTemplate = (albums, albumsCount) => html`
    <!--Catalog-->
    <section id="catalogPage">
        <h1>All Albums</h1>
    
        ${albums};
    
        <!--No albums in catalog-->
        ${albumsCount == 0 ? html`<p>No Albums in Catalog!</p>` : null}
    </section>
`;

let albumTemplate = (album, isUser) => html`
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

        ${isUser ? html`
        <div class="btn-group">
            <a href="/details/${album._id}" id="details">Details</a>
        </div>` : null}

    </div>
</div>`;

export async function catalogView(ctx) {
    console.log('catalog view');
    let isUser = getUserData();
    let albums = await getAll();

    let albumsCount = albums.length;
    let albumsMapped = albums.map(a => albumTemplate(a, isUser));

    ctx.render(catalogTemplate(albumsMapped, albumsCount));
}