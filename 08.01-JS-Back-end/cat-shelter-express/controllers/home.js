const { getCats } = require("../services/catService");

async function getRouteHandler(req, res) {
    const cats = await getCats();
    res.render('home/index', { cats });
}

async function search(req, res) {
    const searchQuery = req.query.search;
    let cats = await getCats();

    cats = cats.filter(cat => {
        return Object.values(cat).some(value =>
            typeof value === 'string' && value.toLowerCase().includes(searchQuery)
        );
    });

    res.render('home/index', { cats });
}

module.exports = {
    getRouteHandler,
    search
}