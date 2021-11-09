let constants = {
    booksUrl: 'http://localhost:3030/jsonstore/collections/books',
    loadBooksId: '#loadBooks',
    titleId: '#title',
    authorId: '#author',
    tbody: 'tbody',
    form: 'form',
    button: 'button',
    completeMsg: 'Create Book complete! response: ',
    deleteMsg: 'Delete Book complete! response: ',
    editMsg: 'Edit Book complete! response: ',
    errorGET: 'Error on GET request!',
    dynamicId: '',
};

let formTag = document.querySelector(constants.form);
let formTitle = formTag.querySelector(constants.titleId);
let formAuthor = formTag.querySelector(constants.authorId);
let tableBody = document.querySelector(`body > table > ${constants.tbody}`);
let submitBtn = formTag.querySelector(constants.button);
let loadBtn = document.querySelector(constants.loadBooksId);

LoadBooks();
submitBtn.addEventListener('click', onSubmit);
loadBtn.addEventListener('click', LoadBooks);
document.addEventListener('click', onEdit);
document.addEventListener('click', onDelete);
document.addEventListener('click', onSave);

function onEdit(event) {
    event.preventDefault();
    if (event.target.textContent.trim() == 'Edit') {
        EditBook(event);
    }
}

function onDelete(event) {
    event.preventDefault();
    if (event.target.textContent.trim() == 'Delete') {
        DeleteBook(event);
    }
}

function onSave(event) {
    event.preventDefault();
    if (event.target.textContent.trim() == 'Save') {
        SaveChanges(event);
    }
}

function onSubmit(event) {
    event.preventDefault();
    if (event.target.textContent.trim() == 'Submit') {
        CreateBook();
    }
}

function onLoad(event) {
    event.preventDefault();
    LoadBooks();
}

async function SaveChanges() {
    let isEmptyTitle = isEmpty(formTitle);
    let isEmptyAuthor = isEmpty(formAuthor);

    if (isEmptyTitle == false && isEmptyAuthor == false) {

        let id = constants.dynamicId;
        let url = constants.booksUrl + `/${id}`;
        let data = {
            author: formAuthor.value,
            title: formTitle.value,
        };
        let returnMessage = constants.editMsg;

        await PUT(url, data, returnMessage);
    }

    submitBtn.textContent = 'Submit';
    constants.dynamicId = '';
    ClearField(formTitle, formAuthor);
    LoadBooks();
}

async function EditBook(event) {
    let rowToEdit = event.target.parentElement.parentElement.children;
    let author = rowToEdit[0].textContent;
    let title = rowToEdit[1].textContent;

    // change input fields accordingly edited row
    formAuthor.value = author;
    formTitle.value = title;
    submitBtn.textContent = 'Save';

    let request = await fetch(constants.booksUrl);
    let books = await request.json();

    let id = Object.entries(books).filter(e => event.target.parentElement.parentElement.textContent.includes(e[1].title))[0][0];

    // set id for the current edit row; it will need for save(put request) 
    constants.dynamicId = id;
}

async function DeleteBook(event) {

    let request = await fetch(constants.booksUrl);
    let books = await request.json();

    let id = Object.entries(books).filter(d => event.target.parentElement.parentElement.textContent.includes(d[1].title))[0][0];

    let url = constants.booksUrl + `/${id}`;
    DELETE(url);

    // event.target.parentElement.parentElement.remove();
    LoadBooks();
}

async function LoadBooks() {
    tableBody.replaceChildren();
    let data = await Promise.all([GET(constants.booksUrl)]);

    let books = Object.values(data[0]);
    books.forEach(book => {
        let tr = document.createElement('tr');
        tr.innerHTML = `
                <td>${book.title}</td>
                <td>${book.author}</td>
                <td>
                    <button>Edit</button>
                    <button>Delete</button>
                </td>`;

        // check if already exist to avoid doubles on the screen
        let isExists = [...tableBody.children].some(r => r.innerHTML == tr.innerHTML);
        if (isExists == false) {
            tableBody.appendChild(tr);
        }
    });
}

async function CreateBook() {
    let isEmptyTitle = isEmpty(formTitle);
    let isEmptyAuthor = isEmpty(formAuthor);

    if (isEmptyTitle == false && isEmptyAuthor == false) {
        let url = constants.booksUrl;
        let data = {
            author: formAuthor.value,
            title: formTitle.value,
        };
        let returnMessage = constants.completeMsg;

        // check if already exist to avoid adding to server same info ,but different id
        let isExists = [...tableBody.children].some(tr => {
            let rowChildren = [...tr.children];
            let trtitle = rowChildren[0].textContent;
            let trauthor = rowChildren[1].textContent;

            let trObj = {
                author: trauthor,
                title: trtitle
            };

            if (trObj.author == data.author && trObj.title == data.title) {
                return true;
            }
        });

        //if not - add it with POST request
        if (isExists == false) {
            await POST(url, data, returnMessage);
            console.log('OK!');
        }
    }

    ClearField(formTitle, formAuthor);
    LoadBooks();
}

async function DELETE(url) {
    await fetch(url, {
        method: 'DELETE',
        headers: {
            'Content-type': 'application/json'
        }
    }).then(res => {
        console.log(constants.deleteMsg, res);
    });
}

async function GET(url) {
    let request = await fetch(url);

    if (request.ok == false) {
        throw new Error(constants.errorGET);
    }

    let data = await request.json();
    return data;
}

async function POST(url, data, messageToReturn) {
    await fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    }).then(res => {
        console.log(messageToReturn, res);
    });
}

async function PUT(url, data, messageToReturn) {
    await fetch(url, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    }).then(res => {
        console.log(messageToReturn, res);
    });
}

function ClearField(...args) {
    [...args].forEach(f => f.value = '');
}

function isEmpty(node) {
    return node.value.trim() === '';
}