import { getAll } from "../scripts/data.js";
import { html, until } from "../scripts/lib.js";

let homeTemplate = (furnituresPromise) => html`
    <div class="row space-top">
        <div class="col-md-12">
            <h1>Welcome to Furniture System</h1>
            <p>Select furniture from the catalog to view details.</p>
        </div>
    </div>
    <div class="row space-top">
        ${until(furnituresPromise, html`<p>Loading ...</p>`)}
    </div>`;

let itemTemplate = (item) => html`
<div class="col-md-4">
    <div class="card text-white bg-primary">
        <div class="card-body">
            <img src=${item.img} />
            <p>${item.description}</p>
            <footer>
                <p>Price: <span>${item.price} $</span></p>
            </footer>
            <div>
                <a href=${`/details/${item._id}`} class="btn btn-info">Details</a>
            </div>
        </div>
    </div>
</div>`;

export function homeView(ctx) {
    ctx.render(homeTemplate(loadItems()));
    console.log('home view');
}

async function loadItems() {
    let furnitures = await getAll();
    return furnitures.map(itemTemplate);
}