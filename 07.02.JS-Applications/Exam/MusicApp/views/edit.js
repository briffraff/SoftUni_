import { editItem, gc, getById } from "../scripts/data.js";
import { html, until } from "../scripts/lib.js";

let editTemplate = (onEdit, albumInfo) => html`
<!--Edit Page-->
<section class="editPage">
    <form @submit="${onEdit}">
        <fieldset>
            <legend>Edit Album</legend>

            <div class="container">
                <label for="name" class="vhide">Album name</label>
                <input id="name" name="name" class="name" type="text" value=${albumInfo.name}>

                <label for="imgUrl" class="vhide">Image Url</label>
                <input id="imgUrl" name="imgUrl" class="imgUrl" type="text" value=${albumInfo.imgUrl}>

                <label for="price" class="vhide">Price</label>
                <input id="price" name="price" class="price" type="text" value="${albumInfo.price}">

                <label for="releaseDate" class="vhide">Release date</label>
                <input id="releaseDate" name="releaseDate" class="releaseDate" type="text"
                    value=${albumInfo.releaseDate}>

                <label for="artist" class="vhide">Artist</label>
                <input id="artist" name="artist" class="artist" type="text" value=${albumInfo.artist}>

                <label for="genre" class="vhide">Genre</label>
                <input id="genre" name="genre" class="genre" type="text" value=${albumInfo.genre}>

                <label for="description" class="vhide">Description</label>
                <textarea name="description" class="description" rows="10" cols="10">${albumInfo.description}</textarea>

                <button class="edit-album" type="submit">Edit Album</button>
            </div>
        </fieldset>
    </form>
</section>
`;

export async function editView(ctx) {
    console.log('edite view');

    //get info for the album and pass to the form fields
    let albumId = ctx.params.id;
    let userId = ctx.getUserData().id;

    let albumInfo = await getById(albumId);

    let albumOwnerId = albumInfo._ownerId
    let isOwner = userId == albumOwnerId;

    if (isOwner == false) {
        alert("Please log in first!");
    } else {
        update();
    }

    // render template
    function update() {
        ctx.render(editTemplate(onEdit, albumInfo));
    }

    // update database info for the album with edited fields
    async function onEdit(event) {
        event.preventDefault();

        let formData = new FormData(event.target);
        let fields = Object.fromEntries(formData);
        let isSomeEmpty = Object.values(fields).some(f => f == '');

        if (isSomeEmpty) {
            alert('Please check empty fields!')
        }
        else {
            await editItem(albumId, fields);
            ctx.page.redirect(gc.nav.details.replace(':id', albumId));
        }
    }
}