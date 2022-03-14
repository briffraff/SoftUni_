import { constants as gc } from './globalConstants.js';

async function request(url, options) {
    try {
        const response = await fetch(gc.urls.Host + url, options);

        if (response.ok != true) {
            if (response.status == gc.errors.err403) {
                sessionStorage.removeItem(gc.userData);
            }
            const error = await response.json();
            throw new Error(error.message);
        }

        if (response.status == gc.errors.err204) {
            return response;
        } else {
            return response.json();
        }

    } catch (err) {
        alert(err.message);
        throw err;
    }
}

function createOptions(method, data) {
    const options = {
        method,
        headers: {},
    };

    if (data != undefined) {
        options.headers[gc.headers.ContentType] = gc.headers.values.ContentType;
        options.body = JSON.stringify(data);
    }

    const userData = JSON.parse(sessionStorage.getItem(gc.userData));
    if (userData != null) {
        options.headers[gc.headers.XAuthorization] = userData.token;
    }

    return options;
}

export async function post(url, data) {
    return request(url, createOptions(gc.requestMethods.POST, data));
}

export async function get(url) {
    return request(url, createOptions(gc.requestMethods.GET));
}

export async function put(url, data) {
    return request(url, createOptions(gc.requestMethods.PUT, data));
}

export async function del(url) {
    return request(url, createOptions(gc.requestMethods.DELETE));
}
