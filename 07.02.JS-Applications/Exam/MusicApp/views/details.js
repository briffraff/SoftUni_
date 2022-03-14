import { getById, deleteItem, gc } from "../scripts/data.js";
import { html } from "../scripts/lib.js";
import { getUserData } from "../scripts/service.js";

let detailsTemplate = (album, isLoggedUser, isAlbumOwner, onDelete) => html`
    <!--Details Page-->
    <section id="detailsPage">
        <div class="wrapper">
            <div class="albumCover">
                <img src="${album.imgUrl}">
            </div>
            <div class="albumInfo">
                <div class="albumText">
                    <h1>Name: ${album.name}</h1>
                    <h3>Artist: ${album.artist}</h3>
                    <h4>Genre: ${album.genre}</h4>
                    <h4>Price: $${album.price}</h4>
                    <h4>Date: ${album.releaseDate}</h4>
                    <p>Description: ${album.description}</p>
                </div>
    
                ${isLoggedUser && isAlbumOwner ? html`
                <!-- Only for registered user and creator of the album-->
                <div class="actionBtn">
                    <a href="/edit/${album._id}" class="edit">Edit</a>
                    <a @click="${onDelete}" href="#" class="remove">Delete</a>
                </div>
                ` : null}
    
            </div>
        </div>
    </section>`;

export async function detailsView(ctx) {
    console.log('details view');
    let isLoggedUser = getUserData();
    let album = await getById(ctx.params.id);
    let isAlbumOwner = null;

    if (isLoggedUser) {
        isAlbumOwner = isLoggedUser.id == album._ownerId;
    }

    update();
    function update() {
        ctx.render(detailsTemplate(album, isLoggedUser, isAlbumOwner, onDelete));
    }

    async function onDelete(event) {
        console.log('delete')
        event.preventDefault();

        // let choice = confirm('Are you sure?');
        // if (choice == true) {
        await deleteItem(ctx.params.id);
        // }
        ctx.page.redirect(gc.nav.catalog);

    }
}


