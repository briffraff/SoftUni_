import { editItem, gc, getById } from "../scripts/data.js";
import { html, until } from "../scripts/lib.js";

let editTemplate = (onEdit, theaterInfo) => html`
        <!--Edit Page-->
        <section id="editPage">
            <form @submit="${onEdit}" class="theater-form">
                <h1>Edit Theater</h1>
                <div>
                    <label for="title">Title:</label>
                    <input id="title" name="title" type="text" placeholder="Theater name" .value=${theaterInfo.title}>
                </div>
                <div>
                    <label for="date">Date:</label>
                    <input id="date" name="date" type="text" placeholder="Month Day, Year" .value=${theaterInfo.date}>
                </div>
                <div>
                    <label for="author">Author:</label>
                    <input id="author" name="author" type="text" placeholder="Author" .value=${theaterInfo.author}>
                </div>
                <div>
                    <label for="description">Theater Description:</label>
                    <textarea id="description" name="description"
                        placeholder="Description">${theaterInfo.description}</textarea>
                </div>
                <div>
                    <label for="imageUrl">Image url:</label>
                    <input id="imageUrl" name="imageUrl" type="text" placeholder="Image Url"
                        .value=${theaterInfo.imageUrl}>
                </div>
                <button class="btn" type="submit">Submit</button>
            </form>
        </section>
`;

export async function editView(ctx) {
    console.log('edite view');

    //get info for the album and pass to the form fields
    let theaterId = ctx.params.id;
    let userId = ctx.getUserData().id;

    let theaterInfo = await getById(theaterId);

    let theaterOwnerId = theaterInfo._ownerId;
    let isOwner = userId == theaterOwnerId;

    if (isOwner == false) {
        alert("Please log in first!");
    } else {
        update();
    }

    // render template
    function update() {
        ctx.render(editTemplate(onEdit, theaterInfo));
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
            await editItem(theaterId, fields);
            ctx.page.redirect(gc.nav.details.replace(':id', theaterId));
        }
    }
}