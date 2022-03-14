import { createItem, gc } from "../scripts/data.js";
import { html, page } from "../scripts/lib.js";

let createTemplate = (onSubmit) => html`
        <!--Create Page-->
        <section id="createPage">
            <form @submit="${onSubmit}" class="create-form">
                <h1>Create Theater</h1>
                <div>
                    <label for="title">Title:</label>
                    <input id="title" name="title" type="text" placeholder="Theater name" value="">
                </div>
                <div>
                    <label for="date">Date:</label>
                    <input id="date" name="date" type="text" placeholder="Month Day, Year">
                </div>
                <div>
                    <label for="author">Author:</label>
                    <input id="author" name="author" type="text" placeholder="Author">
                </div>
                <div>
                    <label for="description">Description:</label>
                    <textarea id="description" name="description" placeholder="Description"></textarea>
                </div>
                <div>
                    <label for="imageUrl">Image url:</label>
                    <input id="imageUrl" name="imageUrl" type="text" placeholder="Image Url" value="">
                </div>
                <button class="btn" type="submit">Submit</button>
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
        let theater = {
            title: fields.title,
            date: fields.date,
            author: fields.author,
            imageUrl: fields.imageUrl,
            description: fields.description
        }

        await createItem(theater);

        page.redirect(gc.nav.home);
        event.target.reset();
    }
}