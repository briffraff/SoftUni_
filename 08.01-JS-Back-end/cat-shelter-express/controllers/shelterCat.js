const { getCatById , removeCat } = require("../services/catService");
const { getAllBreeds } = require("../services/breedService");

async function getRouteHandler(req, res) {
    const id = req.params.id;
    const cat = await getCatById(id);
    const breeds = await getAllBreeds();

    breeds.forEach(breed => {
        breed.selected = (breed.type === cat.breed) ? 'selected' : '';
    });

    res.render('catShelter', { cat, breeds });
}

async function postRouteHandler(req, res) {
    const catId = req.params.id;

    await removeCat(catId);
    res.redirect("/");
}

module.exports = {
    getRouteHandler,
    postRouteHandler
}