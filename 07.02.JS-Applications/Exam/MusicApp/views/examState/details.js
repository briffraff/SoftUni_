import { getById } from "../scripts/data.js";
import { html, until } from "../scripts/lib.js";
import { getUserData } from "../scripts/service.js";

let detailsTemplate = (album, isUser) => html`
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
    
                ${isUser ? html`
                    <!-- Only for registered user and creator of the album-->
                    <div class="actionBtn">
                        <a href="/edit/${album._id}" class="edit">Edit</a>
                        <a href="#" class="remove">Delete</a>
                    </div>
                ` : null}
    
            </div>
        </div>
    </section>
`;

export async function detailsView(ctx) {
    console.log('details view');
    let isUser = getUserData();
    let album = await getById(ctx.params.id);

    ctx.render(detailsTemplate(album, isUser));
}

