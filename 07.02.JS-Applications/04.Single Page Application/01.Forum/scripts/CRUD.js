import { globalConstants as constants } from './globalConstants.js';

export async function DELETE(url) {
    await fetch(url, {
        method: 'DELETE',
        headers: {
            'Content-type': 'application/json'
        }
    }).then(res => {
        console.log(constants.deleteMsg, res);
    });
}

export async function GET(url) {
    let request = await fetch(url);

    if (request.ok == false) {
        throw new Error(constants.errorGET);
    }

    let data = await request.json();
    return data;
}

export async function POST(url, data, messageToReturn) {
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

export async function PUT(url, data, messageToReturn) {
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