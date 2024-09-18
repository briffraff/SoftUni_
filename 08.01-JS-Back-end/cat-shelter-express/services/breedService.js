const path = require('path')
const fs = require('fs').promises;

const breedsDB = path.join("data", "breeds.json");

async function getAllBreeds() {
    const data = await fs.readFile(breedsDB);
    return JSON.parse(data);
}

async function addBreed(fields) {
    const breeds = await getAllBreeds();
    const lastIdx = breeds.length;
    const nextIdx = lastIdx + 1;

    const newBreed = {
        id: nextIdx,
        type: Array.isArray(fields.name) ? fields.name[0] : fields.name
    }

    breeds.push(newBreed);

    await fs.writeFile(breedsDB, JSON.stringify(breeds, null, 2))
}

module.exports = {
    getAllBreeds,
    addBreed
}