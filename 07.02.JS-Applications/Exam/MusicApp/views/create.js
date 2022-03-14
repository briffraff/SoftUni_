import { createItem, gc, getAll } from "../scripts/data.js";
import { html, page } from "../scripts/lib.js";

let createTemplate = (onSubmit) => html`
<!--Create Page-->
<section class="createPage">
    <form @submit="${onSubmit}">
        <fieldset>
            <legend>Add Album</legend>

            <div class="container">
                <label for="name" class="vhide">Album name</label>
                <input id="name" name="name" class="name" type="text" placeholder="Album name">

                <label for="imgUrl" class="vhide">Image Url</label>
                <input id="imgUrl" name="imgUrl" class="imgUrl" type="text" placeholder="Image Url">

                <label for="price" class="vhide">Price</label>
                <input id="price" name="price" class="price" type="text" placeholder="Price">

                <label for="releaseDate" class="vhide">Release date</label>
                <input id="releaseDate" name="releaseDate" class="releaseDate" type="text" placeholder="Release date">

                <label for="artist" class="vhide">Artist</label>
                <input id="artist" name="artist" class="artist" type="text" placeholder="Artist">

                <label for="genre" class="vhide">Genre</label>
                <input id="genre" name="genre" class="genre" type="text" placeholder="Genre">

                <label for="description" class="vhide">Description</label>
                <textarea name="description" class="description" placeholder="Description"></textarea>

                <button class="add-album" type="submit">Add New Album</button>
            </div>
        </fieldset>
    </form>
</section>
`;

export function createView(ctx) {
    console.log('create view');

    update();
    function update() {
        ctx.render(createTemplate(onSubmit));
    }
}

async function onSubmit(event) {
    event.preventDefault();
    let formData = new FormData(event.target);
    let fields = Object.fromEntries(formData);
    let someEmpty = Object.values(fields).some(f => f == '');

    if (someEmpty) {
        alert('Please check empty fields!');
    }
    else {
        let album = {
            name: fields.name,
            imgUrl: fields.imgUrl,
            price: fields.price,
            releaseDate: fields.releaseDate,
            artist: fields.artist,
            genre: fields.genre,
            description: fields.description,
        }

        await createItem(album);

        let allAlbums = await getAll();
        let createdAlbum = Object.values(allAlbums).filter(a => a.name == album.name && a.artist == album.artist && a.price == album.price);
        let redirectTo = `/details/${createdAlbum[0]._id}`;

        page.redirect(redirectTo);
        setTimeout(page.redirect(gc.nav.catalog))
        event.target.reset();
    }
}