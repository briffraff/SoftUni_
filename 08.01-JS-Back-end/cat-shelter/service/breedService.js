const { type } = require('os');
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

    await fs.writeFile(breedsDB, JSON.stringify(breeds, "asd", 2))
}

async function generateBreedFormHTML(breed) {
    return `
        <form action="/add-breed" method="POST" class="cat-form" enctype="multipart/form-data">
            <h2>Add Cat Breed</h2>
            <label for="name">Name</label>
            <input type="text" id="name" name="name" placeholder="Breed name" value="${breed}">
            <button type="submit">Add Breed</button>
        </form>`
}

module.exports = {
    getAllBreeds,
    addBreed,
    generateBreedFormHTML
}
