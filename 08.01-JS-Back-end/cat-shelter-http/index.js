const http = require("http");
const fs = require('fs').promises;
const path = require('path');
const formidable = require('formidable');

const catsService = require('./service/catService');
const breedService = require('./service/breedService');
const searchService = require('./service/searchService')

const port = 2300;
const startMessage = `Server is running on http://localhost:${port}`;

const server = http.createServer(async (req, res) => {
    res.setHeader("content-type", "text/html");

    if (req.url === "/" && req.method === "GET") {
        const searchBarHTML = await searchService.generateSearchBarHTML();

        const cats = await catsService.getCats();
        const catsListHtml = await catsService.generateCatsHTML(cats);

        const filePath = path.join(__dirname, 'views', 'home', 'index.html');
        await loadHTMLFile(filePath, res, { catList: catsListHtml, searchBar: searchBarHTML });
    }
    else if (req.url === "/search" && req.method === "POST") {
        const form = new formidable.IncomingForm();

        form.parse(req, async (err, fields) => {
            if (err) {
                res.writeHead(500, { 'Content-Type': 'text/html' });
                res.end('Error processing the form');
                return;
            }

            const searchField = fields.search[0];

            if (searchField !== "") {
                const searchResults = await searchService.search(searchField);
                const catsListHtml = await catsService.generateCatsHTML(searchResults);
                const searchBarHTML = await searchService.generateSearchBarHTML();

                const filePath = path.join(__dirname, 'views', 'home', 'index.html');
                await loadHTMLFile(filePath, res, { catList: catsListHtml, searchBar: searchBarHTML });

                res.end();
            }
        });
    }
    else if (req.url.match(/^\/edit\/([0-9a-zA-Z-]+)$/) && req.method === "GET") {
        const catId = req.url.split("/")[2];
        const cat = await catsService.getCatById(catId);

        if (cat) {

            const catEditHtml = await catsService.generateEditCatDetailsHTML(cat);
            const filePath = path.join(__dirname, 'views', 'editCat.html');
            await loadHTMLFile(filePath, res, { catEdit: catEditHtml });

        } else {
            res.statusCode = 404;
            res.end("<h1>Cat not found! 404!</h1>");
        }
    }
    else if (req.url.match(/^\/edit\/([0-9a-zA-Z-]+)$/) && req.method === "POST") {
        const catId = req.url.split("/")[2];

        const form = new formidable.IncomingForm({
            allowEmptyFiles: true,
            minFileSize: 0
        });

        form.parse(req, async (err, fields) => {
            if (err) {
                res.writeHead(500, { 'Content-Type': 'text/html' });
                res.end('Error processing the form');
                return;
            }

            await catsService.updateCat(catId, fields);
            res.writeHead(302, { 'Location': '/' });
            res.end();
        });
    }
    else if (req.url === "/add-breed" && req.method === "GET") {
        const breedForm = await breedService.generateBreedFormHTML("");

        const filePath = path.join(__dirname, 'views', 'addBreed.html');
        await loadHTMLFile(filePath, res, { addBreed: breedForm });
    }
    else if (req.url === "/add-breed" && req.method === "POST") {

        const form = new formidable.IncomingForm();

        form.parse(req, async (err, fields) => {
            if (err) {
                res.writeHead(500, { 'Content-Type': 'text/html' });
                res.end('Error processing the form');
                return;
            }

            await breedService.addBreed(fields);
            res.writeHead(302, { 'Location': '/' });
            res.end();
        });
    }
    else if (req.url === "/add-cat" && req.method === "GET") {
        const addCatHtml = await catsService.generateAddCatHTML();

        const filePath = path.join(__dirname, 'views', 'addCat.html');
        await loadHTMLFile(filePath, res, { addCat: addCatHtml });
    }
    else if (req.url === "/add-cat" && req.method === "POST") {
        const form = new formidable.IncomingForm();

        form.parse(req, async (err, fields) => {
            if (err) {
                res.writeHead(500, { 'Content-Type': 'text/html' });
                res.end('Error processing the form');
                return;
            }

            console.log("Fields :", fields);

            await catsService.addCat(fields);
            res.writeHead(302, { 'Location': '/' });
            res.end();
        });
    }
    else if (req.url.match(/^\/shelter\/([0-9a-zA-Z-]+)$/) && req.method === 'GET') {
        const catId = req.url.split("/")[2];
        const cat = await catsService.getCatById(catId);
        const shelterFormHTML = await catsService.generateCatShelterHTML(cat);

        const filepath = path.join(__dirname, "views", "catShelter.html")
        await loadHTMLFile(filepath, res, { catShelter: shelterFormHTML });
    }
    else if (req.url.match(/^\/shelter\/([0-9a-zA-Z-]+)$/) && req.method === 'POST') {
        const catId = req.url.split('/')[2];

        await catsService.removeCat(catId);
        res.writeHead(302, { 'Location': '/' });
        res.end();
    }
    else if (req.url.startsWith('/content/')) {
        var staticFilePath = path.join(__dirname, req.url);

        if (staticFilePath.endsWith("favicon.ico")) {
            staticFilePath = staticFilePath.replace("favicon", "cat")
            console.log(staticFilePath);
        }

        await loadStaticFile(staticFilePath, res);
    }
    else {
        res.statusCode = 404;
        res.end("<h1>Page Not found! 404!</h1>");
    }
});

server.listen(port, () => {
    console.log(startMessage);
});

async function loadHTMLFile(filepath, res, includes) {
    try {
        let data = await fs.readFile(filepath, 'utf-8');
        data = data.replace('{{catList}}', includes.catList);
        data = data.replace('{{catEdit}}', includes.catEdit);
        data = data.replace('{{searchBar}}', includes.searchBar);
        data = data.replace('{{addCat}}', includes.addCat);
        data = data.replace('{{catShelter}}', includes.catShelter);
        data = data.replace('{{addBreed}}', includes.addBreed);
        res.statusCode = 200;
        res.end(data);
    } catch (err) {
        res.statusCode = 500;
        res.end('Error loading the page');
    }
}

async function loadStaticFile(filepath, res) {
    try {
        const data = await fs.readFile(filepath);
        res.statusCode = 200;

        if (filepath.endsWith('.css')) {
            res.setHeader('Content-Type', 'text/css');
        } else if (filepath.endsWith('.ico')) {
            res.setHeader('Content-Type', 'image/x-icon');
        }
        res.end(data);
    } catch (err) {
        res.statusCode = 404;
        res.end('File not found');
    }
}