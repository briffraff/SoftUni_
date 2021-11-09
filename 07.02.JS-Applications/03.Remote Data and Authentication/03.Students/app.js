
let constants = {
    tbody: 'tbody',
    submitId: '#submit',
    tableId: '#results',
    inputsClass: '.inputs',
    notificationClass: '.notification',
    invalidMsg: 'Invalid input!',
    doneMsg: 'Done',
    completeMsg: 'Add Student complete! response: ',
    studentsUrl: 'http://localhost:3030/jsonstore/collections/students',
};

LoadTable();
let table = document.querySelector(constants.tableId);
let tableBody = table.querySelector(constants.tbody);
let inputs = document.querySelector(constants.inputsId).children;
let submit = document.querySelector(constants.submitId);
submit.addEventListener('click', onSubmit);

function onSubmit(e) {
    e.preventDefault();
    let notification = document.querySelector(constants.notificationClass);

    let someEmpty = [...inputs].some(input => isEmpty(input));
    let [firstName, lastName, facNumber, grade] = [...inputs];

    let isGradeNumber = isNumber(grade.value);
    let isFacNumber = isNumber(facNumber.value);

    if (someEmpty == false && isGradeNumber && isFacNumber) {
        notification.textContent = '';

        let student = {
            firstName: firstName.value.trim(),
            lastName: lastName.value.trim(),
            facultyNumber: facNumber.value.trim(),
            grade: grade.value.trim()
        };

        Add(student);

        ClearField(firstName, lastName, facNumber, grade);
        notification.textContent = constants.doneMsg;
    }
    else {
        notification.textContent = constants.invalidMsg;
    }

    LoadTable();
}

async function LoadTable() {
    const request = await fetch(constants.studentsUrl);
    const students = await request.json();

    Object.values(students).forEach(student => {
        let tr = document.createElement('tr');
        tr.innerHTML = `
                <td>${student.firstName}</td>
                <td>${student.lastName}</td>
                <td>${student.facultyNumber}</td>
                <td>${student.grade}</td>
            `;

        let isExists = [...tableBody.children].some(r => r.innerHTML == tr.innerHTML);
        if (isExists == false) {
            tableBody.appendChild(tr);
        }
    });
}

function ClearField(...args) {
    [...args].forEach(f => f.value = '');
}

function Add(student) {
    let url = constants.studentsUrl;
    let message = constants.completeMsg;

    POST(url, student, message);
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

function isEmpty(node) {
    return node.value.trim() === '';
}

function isNumber(input) {
    return isNaN(Number(input)) == false;
}
