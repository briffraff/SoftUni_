import { html, until } from "../scripts/lib.js";
import { getAll } from "../scripts/data.js";

let count = null;
let isLoggedUser = null;

let homeTemplate = (theaterPromise) => html`
        <!--Home Page-->
        <section class="welcomePage">
            <div id="welcomeMessage">
                <h1>My Theater</h1>
                <p>Since 1962 World Theatre Day has been celebrated by ITI Centres, ITI Cooperating Members, theatre professionals, theatre
                organizations, theatre universities and theatre lovers all over the world on the 27th of March. This day is a
                celebration for those who can see the value and importance of the art form “theatre”, and acts as a wake-up-call for
                governments, politicians and institutions which have not yet recognised its value to the people and to the individual
                and have not yet realised its potential for economic growth.</p>
            </div>
            <div id="events">
                <h1>Future Events</h1>
                <div class="theaters-container">
                    <!-- No Theaters -->
                    ${count == 0 ? html`<h4 class="no-event">No Events Yet...</h4>` : null}

                    <!--Created Events-->
                    ${until(theaterPromise, html`<p>Loading...</p>`)}

                </div>
            </div>
        </section>
`;

let theatherTemplate = (theather) => html`
<div class="eventsInfo">
    <div class="home-image">
        <img src="${theather.imageUrl}">
    </div>
    <div class="info">
        <h4 class="title">${theather.title}</h4>
        <h6 class="date">${theather.date}</h6>
        <h6 class="author">${theather.author}</h6>
        <div class="info-buttons">
            <a class="btn-details" href="/details/${theather._id}">Details</a>
        </div>
    </div>
</div>
`;

export function homeView(ctx) {
    ctx.render(homeTemplate(loadItems(ctx)));
    console.log('home/catalog view');
}

async function loadItems(ctx) {
    isLoggedUser = ctx.getUserData();
    
    let getTheathers = await getAll();

    if (getTheathers == [] && getTheathers.length == 0) {
        count = 0;
    }

    let mappedtTheathers = getTheathers.map(theatherTemplate);
    return mappedtTheathers;
}