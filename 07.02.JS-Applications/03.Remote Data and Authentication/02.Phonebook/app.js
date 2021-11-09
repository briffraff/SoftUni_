let choose = {
    dom: 'dom',
    server: 'server',
};

// chose dom or server
let domORserver = choose.server;

let globalConstants = {
    url: 'http://localhost:3030/jsonstore/phonebook',
    loadBtnId: '#btnLoad',
    createBtnId: '#btnCreate',
    phonebookId: '#phonebook',
    inputPersonId: '#person',
    inputPhoneId: '#phone',
    empty: '',
};

async function attachEvents() {
    let phonebook = document.querySelector(globalConstants.phonebookId);

    let loadBtn = document.querySelector(globalConstants.loadBtnId);
    loadBtn.addEventListener('click', Load.bind(null, phonebook));

    let createBtn = document.querySelector(globalConstants.createBtnId);
    createBtn.addEventListener('click', Create.bind(null, phonebook));

    document.addEventListener('click', Delete);
}

async function Delete(event) {
    if (event.target.textContent.trim() == 'Delete') {
        if (domORserver == choose.server) {

            let res = await fetch(globalConstants.url);
            let data = await res.json();

            let id = Object.values(data).filter(p => event.target.parentElement.textContent.includes(p.person))[0]._id;
            let deleteurl = globalConstants.url + `/${id}`;

            await fetch(deleteurl, {
                method: 'DELETE',
                headers: {
                    'Content-type': 'application/json'
                }
            }).then(res => {
                console.log('Delete complete! response:', res);
            });

            event.target.parentElement.remove();
        }

        if (domORserver == choose.dom) {
            event.target.parentElement.remove();
        }
    }
}

async function Load(phonebook) {
    let url = globalConstants.url;

    let response = await fetch(url);
    let data = await response.json();

    for (let record in data) {
        let [_id, person, phone] = [data[record]._id, data[record].person, data[record].phone];

        let li = createRecord(person, phone);

        let serverLi = document.createElement('li');
        serverLi.innerHTML = `${li.person}: ${li.phone} <button> Delete </button>`;
        serverLi.id = _id;

        //check if already added 
        let isLoaded = [...phonebook.children].some(x => x.innerHTML == li.innerHTML || x.innerHTML == serverLi.innerHTML);

        //if not add li element for dom or serverli for server
        if (isLoaded == false && domORserver == choose.dom) {
            phonebook.appendChild(li);
        }
        if (isLoaded == false && domORserver == choose.server) {
            phonebook.appendChild(serverLi);
        }
    }
}

//create record from input
async function Create(phonebook) {
    let inputPerson = document.querySelector(globalConstants.inputPersonId);
    let inputPhone = document.querySelector(globalConstants.inputPhoneId);

    //if input values are empty
    if (inputPerson.value != globalConstants.empty && inputPhone.value != globalConstants.empty) {
        if (domORserver == choose.dom) {
            let record = createRecord(inputPerson.value, inputPhone.value);
            phonebook.appendChild(record);
        }
        if (domORserver == choose.server) {
            let record = createRecord(inputPerson.value, inputPhone.value);

            await fetch(globalConstants.url, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(record)
            }).then(res => {
                console.log('Post complete! response:', res);
            });
        }
    }

    //clear input fields
    inputPerson.value = globalConstants.empty;
    inputPhone.value = globalConstants.empty;

    Load(phonebook);
}

//create a element template
function createRecord(person, phone) {
    if (domORserver == choose.server) {
        let record = {
            person: `${person}`,
            phone: `${phone}`
        };
        return record;
    }

    if (domORserver == choose.dom) {
        let li = document.createElement('li');
        li.innerHTML = `${person}: ${phone} <button> Delete </button>`;
        return li;
    }
}

attachEvents();