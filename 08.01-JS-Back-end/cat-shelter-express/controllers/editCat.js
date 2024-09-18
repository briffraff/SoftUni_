const { getCatById, updateCat } = require("../services/catService");
const { getAllBreeds } = require("../services/breedService");
const formidable = require('formidable');

async function getRouteHandler(req, res) {
    const id = req.params.id;
    const cat = await getCatById(id);
    const breeds = await getAllBreeds();

    breeds.forEach(breed => {
        breed.selected = (breed.type === cat.breed) ? 'selected' : '';
    });

    res.render('editCat', { cat, breeds });
}

async function postRouteHandler(req, res) {
    const catId = req.params.id;
    const fields = req.body;
    await updateCat(catId, fields);
    
    // const form = new formidable.IncomingForm({
    //     allowEmptyFiles: true,
    //     minFileSize: 0
    // });

    // form.parse(req, async (err, fields) => {
    //     if (err) {
    //         res.writeHead(500, { 'Content-Type': 'text/html' });
    //         res.end('Error processing the form');
    //         return;
    //     }

    //     await updateCat(catId, fields);
    // });
    res.redirect("/");
}

module.exports = {
    getRouteHandler,
    postRouteHandler
}