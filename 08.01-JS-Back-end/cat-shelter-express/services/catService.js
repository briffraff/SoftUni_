const path = require('path')
const fs = require('fs').promises;

const catsDb = path.join("data", "cats.json");

async function getCats() {
    const data = await fs.readFile(catsDb);
    const parsedData = JSON.parse(data);
    const filteredData = parsedData.filter(c => c.isDeleted === false);
    return filteredData;
}

async function getCatById(id) {
    const cats = await getCats();
    const cat = cats.find(c => c.id == id);
    return cat;
}

async function addCat(fields) {
    const cats = await getCats();
    const lastIdx = cats.length;
    const nextIdx = lastIdx + 1;

    const newCat = {
        id: nextIdx,
        name: Array.isArray(fields.name) ? fields.name[0] : fields.name,
        price: "",
        breed: Array.isArray(fields.breed) ? fields.breed[0] : fields.breed,
        description: Array.isArray(fields.description) ? fields.description[0] : fields.description,
        imageUrl: Array.isArray(fields.imageUrl) ? fields.imageUrl[0] : fields.imageUrl,
        isDeleted: false
    }

    cats.push(newCat);

    await fs.writeFile(catsDb, JSON.stringify(cats, null, 2));
}

async function updateCat(id, fields) {
    const cats = await getCats();
    const catIndex = cats.findIndex(c => c.id === parseInt(id));

    if (catIndex !== -1) {
        const updatedCat = {
            name: Array.isArray(fields.name) ? fields.name[0] : fields.name,
            breed: Array.isArray(fields.breed) ? fields.breed[0] : fields.breed,
            description: Array.isArray(fields.description) ? fields.description[0] : fields.description,
            imageUrl: Array.isArray(fields.imageUrl) ? fields.imageUrl[0] : fields.imageUrl,
            price: ""
        };

        cats[catIndex] = { ...cats[catIndex], ...updatedCat };

        await fs.writeFile(catsDb, JSON.stringify(cats, null, 2));
    }
}

async function removeCat(id) {
    const cats = await getCats();
    const catIndex = cats.findIndex(c => c.id === parseInt(id));

    if (catIndex !== -1) {
        const remove = {
            isDeleted: true
        }

        cats[catIndex] = { ...cats[catIndex], ...remove };

        await fs.writeFile(catsDb, JSON.stringify(cats, null, 2));
    }
}


module.exports = {
    getCats,
    getCatById,
    addCat,
    removeCat,
    updateCat,
}