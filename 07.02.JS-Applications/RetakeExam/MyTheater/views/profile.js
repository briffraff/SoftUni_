import { getAllByProfile } from "../scripts/data.js";
import { html, until } from "../scripts/lib.js";
import { getUserData } from "../scripts/service.js";


let itemTemplate = (item) => html`
<div class="eventBoard">
    <div class="event-info">
        <img src="${item.imageUrl}">
        <h2>${item.title}</h2>
        <h6>${item.date}</h6>
        <a href="/details/${item._id}" class="details-button">Details</a>
    </div>
</div>
`;

let result = (user, mappedtTheathers) => html`
<!--Profile Page-->
<section id="profilePage">
    <div class="userInfo">
        <div class="avatar">
            <img src="/images/profilePic.png">
        </div>
        <h2>${user.email}</h2>
    </div>
    <div class="board">
        ${until(mappedtTheathers, html`<p class="no-result">Loading...</p>`)}
    </div>;
</section>
`;


let nodata = (user) => html`
<section id="profilePage">
    <div class="userInfo">
        <div class="avatar">
            <img src="/images/profilePic.png">
        </div>
        <h2>${user.email}</h2>
    </div>
    <div class="board">
        <div class="no-events">
            <p>This user has no events yet!</p>
        </div>
    </div>
</section>
`;

export function profileView(ctx) {
    console.log('profile view');
    let user = getUserData();

    update();
    async function update() {
        let theathers = await getAllByProfile(user.id);

        // result
        if (theathers.length >= 1) {
            let mappedtTheathers = theathers.map(itemTemplate);
            ctx.render(result(user, mappedtTheathers));
        }
        // no result
        else {
            ctx.render(nodata(user))
        }
    }
}

