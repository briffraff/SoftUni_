// function solve() {
//     // get references to elements of interest
//     // configure event listeners
//     const fields = document.querySelectorAll('#container input');
//     const addBtn = document.querySelector('#container button');
//     const petList = document.querySelector('#adoption ul');
//     const adoptedList = document.querySelector('#adopted ul');

//     const input = {
//         name: fields[0],
//         age: fields[1],
//         kind: fields[2],
//         owner: fields[3],
//     };

//     addBtn.addEventListener('click', addPet);

//     // # Add new pet
//     // Read input fields
//     // Validate values
//     // Create new list item
//     // Configure event listener for newly created element
//     function addPet(event) {
//         event.preventDefault();

//         const name = input.name.value.trim();
//         const age = Number(input.age.value.trim());
//         const kind = input.kind.value.trim();
//         const owner = input.owner.value.trim();

//         if (name == '' || input.age.value.trim() == '' || Number.isNaN(age) || kind == '' || owner == '') {
//             return;
//         }

//         const contactBtn = e('button', {}, 'Contact with owner');

//         const pet = e('li', {},
//             e('p', {},
//                 e('strong', {}, name),
//                 ' is a ',
//                 e('strong', {}, age),
//                 ' year old ',
//                 e('strong', {}, kind)
//             ),
//             e('span', {}, `Owner: ${owner}`),
//             contactBtn
//         );

//         contactBtn.addEventListener('click', contact);

//         petList.appendChild(pet);

//         input.name.value = '';
//         input.age.value = '';
//         input.kind.value = '';
//         input.owner.value = '';

//         // # Contact owner
//         // Create confirmation div
//         // Configure event listener for new button
//         // Replace existing button with confirmation div
//         function contact() {
//             const confirmInput = e('input', { placeholder: 'Enter your names' });
//             const confirmBtn = e('button', {}, 'Yes! I take it!');
//             const confirmDiv = e('div', {},
//                 confirmInput,
//                 confirmBtn
//             );

//             confirmBtn.addEventListener('click', adopt.bind(null, confirmInput, pet));

//             contactBtn.remove();
//             pet.appendChild(confirmDiv);
//         }
//     }

//     // # Adopt a pet
//     // Read and validate input
//     // Create new button for checking
//     // Configure event listener for new button
//     // Replace confirmation div with new button
//     // Change text content of Owner span
//     // Move element to other list
//     function adopt(input, pet) {
//         const newOwner = input.value.trim();

//         if (newOwner == '') {
//             return;
//         }

//         const checkBtn = e('button', {}, 'Checked');
//         checkBtn.addEventListener('click', check.bind(null, pet));

//         pet.querySelector('div').remove();
//         pet.appendChild(checkBtn);

//         pet.querySelector('span').textContent = `New Owner: ${newOwner}`;

//         adoptedList.appendChild(pet);
//     }

//     // # Checking of adopted pet
//     // Remove element from DOM
//     function check(pet) {
//         pet.remove();
//     }

//     function e(type, attr, ...content) {
//         const element = document.createElement(type);

//         for (let prop in attr) {
//             element[prop] = attr[prop];
//         }
//         for (let item of content) {
//             if (typeof item == 'string' || typeof item == 'number') {
//                 item = document.createTextNode(item);
//             }
//             element.appendChild(item);
//         }

//         return element;
//     }
// }

function solve() {
    let container = document.querySelector('#container').children;
    // var el = $('*[placeholder="Name"]');

    // let input = {
    //     name: container[0],
    //     age: container[1],
    //     kindInput: container[2],
    //     ownerInput: container[3],
    //     addBtn: container[4]
    // };

    let nameInput = container[0];
    let ageInput = container[1];
    let kindInput = container[2];
    let ownerInput = container[3];
    let addBtn = container[4];
    addBtn.addEventListener('click', addPet);

    function isEmpty(str) {
        return !str.value.trim().length;
    }

    function isNumber(number) {
        let a = Number(number.value.trim());
        return !Number.isNaN(a);
    }

    function addPet(evt) {
        evt.preventDefault();

        let isThereEmpty = [nameInput, ageInput, kindInput, ownerInput].some(x => isEmpty(x));

        if (isThereEmpty == false && isNumber(ageInput) == true) {

            let adobptionID = document.querySelector('#adoption > ul');

            let pet = document.createElement('li');
            let p = document.createElement('p');
            let span = document.createElement('span');
            span.textContent = `Owner: ${ownerInput.value}`;
            let btn = document.createElement('button');
            btn.textContent = 'Contact with owner';
            pet.appendChild(p);
            let strong = `<strong>${nameInput.value}</strong> is a <strong>${ageInput.value}</strong> year old <strong>${kindInput.value}</strong>`;
            p.innerHTML = strong;
            pet.appendChild(span);
            pet.appendChild(btn);
            adobptionID.appendChild(pet);
            btn.addEventListener('click', contactTheOwner.bind(null, pet));

            adobptionID.appendChild(pet);
            nameInput.value = '';
            ageInput.value = '';
            kindInput.value = '';
            ownerInput.value = '';
        }
    }

    function contactTheOwner(pet) {
        pet.querySelector('button').remove();

        let div = document.createElement('div');

        let input = document.createElement('input');
        input.placeholder = 'Enter your names';
        div.appendChild(input);

        let adoptBtn = document.createElement('button');
        adoptBtn.textContent = 'Yes! I take it!';
        adoptBtn.addEventListener('click', adopted.bind(null, pet, input));
        div.appendChild(adoptBtn);

        pet.appendChild(div);
    }

    function adopted(pet, input) {
        if (isEmpty(input) == false) {
            let newOwner = input.value.trim();

            pet.querySelector('div').remove();
            pet.querySelector('span').textContent = `New Owner: ${newOwner}`;

            let checkedBtn = document.createElement('button');
            checkedBtn.textContent = 'Checked';
            checkedBtn.addEventListener('click', finish.bind(null, pet));
            pet.appendChild(checkedBtn);

            let adoptedID = document.querySelector('#adopted > ul');
            adoptedID.appendChild(pet);
        }
    }

    function finish(pet) {
        pet.remove();
    }

    // function crtel(type, attr, ...content) {
    //     const element = document.createElement(type);

    //     for (let prop in attr) {
    //         element[prop] = attr[prop];
    //     }
    //     for (let item of content) {
    //         if (typeof item == 'string' || typeof item == 'number') {
    //             item = document.createTextNode(item);
    //         }
    //         element.appendChild(item);
    //     }

    //     return element;
    // }
}



