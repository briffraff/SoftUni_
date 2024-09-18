const path = require('path')
const fs = require('fs').promises;

const catsDb = path.join("data", "cats.json");

const breedsService = require('./breedService');

async function getCats() {
    const data = await fs.readFile(catsDb);
    const parsedData = JSON.parse(data);
    const filteredData = parsedData.filter(c => c.isDeleted === false);
    return filteredData;
}

async function getCatById(id) {
    const cats = await getCats();
    const cat = cats.find(c => c.id === parseInt(id));
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
        imageUrl: Array.isArray(fields.imageUrl) ? fields.imageUrl[0] : fields.imageUrl
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
            isDeleted : true
        }

        cats[catIndex] = { ...cats[catIndex], ...remove };

        await fs.writeFile(catsDb, JSON.stringify(cats, null, 2));
    }
}

async function generateAddCatHTML() {

    const newCat = {
        "name": "",
        "breed": "",
        "price": "",
        "description": "",
        "imageUrl": ""
    }

    return generateEditCatDetailsHTML(newCat);
}

async function generateCatShelterHTML(cat) {

    const breedsOptions = await breedsService.getAllBreeds();

    const breedOptionsHtml = breedsOptions.map(breed =>
        `<option value="${breed.type}" ${breed.type === cat.breed ? 'selected' : ''}>${breed.type}</option>`
    ).join('\n');

    return `
        <form action="/shelter/${cat.id}" method="POST" class="cat-form" enctype="multipart/form-data">
            <h2>Shelter the cat</h2>
            <img src="${cat.imageUrl}" alt="">
            <label for="name">Name</label>
            <input type="text" id="name" value="${cat.name}" disabled>
            <label for="description">Description</label>
            <textarea id="description" disabled>${cat.description}</textarea>
            <label for="group">Breed</label>
            <select id="group" disabled>${breedOptionsHtml}</select>
            <button type="submit">SHELTER THE CAT</button>
        </form>`
}


async function generateCatsHTML(cats) {
    const cathtml = (catInfo) => {
        return `
        <li>
            <img src="${catInfo.imageUrl}"
            alt="Black Cat">
            <h3>${catInfo.name}</h3>
            <p><span>Breed: </span>${catInfo.breed}</p>
            <p><span>Description: </span>${catInfo.description}</p>
            <ul class="buttons">
                <li class="btn edit"><a href="/edit/${catInfo.id}">Change Info</a></li>
                <li class="btn delete"><a href="/shelter/${catInfo.id}">New Home</a></li>
            </ul>
        </li>`;
    }

    let catList = cats.map(cathtml).join('\n');

    return catList;
}

async function generateEditCatDetailsHTML(cat) {
    const newCat = cat.name === "" && cat.imageUrl === "" && cat.description === "";

    const breedsOptions = await breedsService.getAllBreeds();

    const breedOptionsHtml = breedsOptions.map(breed =>
        `<option value="${breed.type}" ${breed.type === cat.breed ? 'selected' : ''}>${breed.type}</option>`
    ).join('\n');

    return `
    <form action="${newCat ? '/add-cat' : `/edit/${cat.id}`}" method="POST" class="cat-form" enctype="multipart/form-data">
        <h2>Edit Cat</h2>
        <label for="name">Name</label>
        <input type="text" id="name" name="name" value="${cat.name}" required>
        <label for="description">Description</label>
        <textarea id="description" name="description" required>${cat.description}</textarea>
        <label for="imageUrl">Image</label>
        <input type="text" id="imageUrl" name="imageUrl" value="${cat.imageUrl}" required>
        <label for="group">Breed</label>
        <select id="group" name="breed" required>${breedOptionsHtml}</select>
        <button type="submit">${newCat ? 'Add Cat' : 'Edit Cat'}</button>
    </form>`
}

module.exports = {
    getCats,
    getCatById,
    updateCat,
    addCat,
    removeCat,
    generateCatShelterHTML,
    generateAddCatHTML,
    generateCatsHTML,
    generateEditCatDetailsHTML
};