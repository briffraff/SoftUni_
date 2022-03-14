import { html } from "../scripts/lib.js";

export function detailsView(ctx) {
    console.log('details view', ctx.params.id);

    console.log(ctx);
}

let detailsTemplate = () => html`
    <div class="container">
        <div class="row space-top">
            <div class="col-md-12">
                <h1>Furniture Details</h1>
            </div>
        </div>
        <div class="row space-top">
            <div class="col-md-4">
                <div class="card text-white bg-primary">
                    <div class="card-body">
                        <img src="/images/chair.jpg" />
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <p>Make: <span>make</span></p>
                <p>Model: <span>model</span></p>
                <p>Year: <span>year</span></p>
                <p>Description: <span>description</span></p>
                <p>Price: <span>price</span></p>
                <p>Material: <span>material</span></p>
                <div>
                    <a href="/edit/123"" class=" btn btn-info">Edit</a>
                    <a href="/delete/123" class="btn btn-red">Delete</a>
                </div>
            </div>
        </div>
    </div>`;


