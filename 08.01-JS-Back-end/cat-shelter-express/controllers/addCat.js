const { getAllBreeds } = require("../services/breedService");
const { addCat } = require("../services/catService");
const formidable = require('formidable');

async function getRouteHandler(req, res) {
    const breeds = await getAllBreeds();
    res.render('addCat', { breeds });
}

async function postRouteHandler(req, res) {

    const fields = req.body;

    await addCat(fields);

    // const form = new formidable.IncomingForm();

    // form.parse(req, async (err, fields) => {
    //     if (err) {
    //         res.writeHead(500, { 'Content-Type': 'text/html' });
    //         res.end('Error processing the form');
    //         return;
    //     }

    //     await addCat(fields);
    // });

    res.redirect("/");
}

module.exports = {
    getRouteHandler,
    postRouteHandler
}