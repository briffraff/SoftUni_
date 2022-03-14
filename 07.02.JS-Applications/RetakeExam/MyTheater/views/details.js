import { getById, deleteItem, gc, getLikes } from "../scripts/data.js";
import { html } from "../scripts/lib.js";
import { getUserData } from "../scripts/service.js";

let detailsTemplate = (theather, isLoggedUser, isTheatherOwner, buttons, likesCount) => html`
    <!--Details Page-->
    <section id="detailsPage">
        <div id="detailsBox">
            <div class="detailsInfo">
                <h1>${theather.title}</h1>
                <div>
                    <img src="${theather.imageUrl}" />
                </div>
            </div>
    
            <div class="details">
                <h3>Theater Description</h3>
                <p>${theather.description}</p>
                <h4>${theather.date}</h4>
                <h4>Author: ${theather.author}</h4>
    
                ${isLoggedUser && isTheatherOwner ? buttons : null}
    
                <p class="likes">Likes: ${likesCount}</p>
            </div>
        </div>
    </section>
`;

let buttons = (theather, isTheatherOwner, onDelete) => html`
<div class="buttons">
    <a @click="${onDelete}" class="btn-delete" href="#">Delete</a>
    <a class="btn-edit" href="${gc.nav.edit.replace(":id", theather._id)}">Edit</a>
    ${isTheatherOwner ? null : html`<a class="btn-like" href="#">Like</a>`}
</div>
`;

export async function detailsView(ctx) {
    console.log('details view');
    let isLoggedUser = getUserData();
    let theather = await getById(ctx.params.id);
    let isTheatherOwner = null;
    
    let likesCount = await getLikes(theather._id, theather._ownerId);

    if (isLoggedUser) {
        isTheatherOwner = isLoggedUser.id == theather._ownerId;
    }

    update();
    function update() {
        ctx.render(detailsTemplate(theather, isLoggedUser, isTheatherOwner, buttons(theather, isTheatherOwner, onDelete), likesCount));
    }

    async function onDelete(event) {
        console.log('delete')
        event.preventDefault();

        await deleteItem(ctx.params.id);

        ctx.page.redirect(gc.nav.home);
    }
}


