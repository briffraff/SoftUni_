//  imports
import { globalConstants as gc } from './globalConstants.js';

//  delete method
export async function DELETE(url,userData) {
    let request = await fetch(url, {
        method: 'DELETE',
        headers: {
            // 'Content-type': 'application/json',
            'X-Authorization': userData.token,
        }
    });
    
    if (request.ok == false) {
        const error = request.json();
        throw new Error(error.message);
    }
    console.log(gc.deleteMsg, request);

    let data = await request.json();
    return data;
}

//  get/read method
export async function GET(url) {
    let request = await fetch(url);

    if (request.ok == false) {
        throw new Error(gc.errorGET);
    }

    let data = await request.json();
    return data;
}

//  post/create method
export async function POST(url, data, messageToReturn) {
    let request = await fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    });

    if (request.ok == false) {
        let error = await request.json();
        throw new Error(error.message);
    }
    console.log(messageToReturn, request);

    let dataReq = await request.json();
    return dataReq;
}

//  put/edit/update method
export async function PUT(url, data, messageToReturn) {
    let request = await fetch(url, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    });

    if (request.ok == false) {
        const error = await request.json();
        throw new Error(error.message);
    }
    console.log(messageToReturn, request);
    
    let dataReq = await request.json();
    return dataReq;
}