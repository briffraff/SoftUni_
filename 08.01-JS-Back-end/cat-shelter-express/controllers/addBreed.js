
const { addBreed } = require('../services/breedService');
const formidable = require('formidable');

async function getRouteHandler(req, res) {
    res.render('addBreed');
}

async function postRouteHandler(req, res) {
    ///// req.body version
    const fields = req.body;
    await addBreed(fields);

    ///// FORMIDABLE version
    // const form = new formidable.IncomingForm();

    // form.parse(req, async (err, fields) => {
    //     if (err) {
    //         res.writeHead(500, { 'Content-Type': 'text/html' });
    //         res.end('Error processing the form');
    //         return;
    //     }

    //     await addBreed(fields);
    // });
    
        res.redirect('/');
}


module.exports = {
    getRouteHandler,
    postRouteHandler
}