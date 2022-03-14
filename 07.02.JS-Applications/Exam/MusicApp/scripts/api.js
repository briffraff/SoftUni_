import { constants as gc } from './globalConstants.js';

export {
    gc
}

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

export async function login(email, password) {
    const result = await post(gc.urls.Login, { email, password });
    const userData = {
        email: result.email,
        id: result._id,
        token: result.accessToken
    };
    sessionStorage.clear()
    sessionStorage.setItem(gc.userData, JSON.stringify(userData));
}

export async function register(email, password) {
    const result = await post(gc.urls.Register, { email, password });
    const userData = {
        email: result.email,
        id: result._id,
        token: result.accessToken
    };
    sessionStorage.clear()
    sessionStorage.setItem(gc.userData, JSON.stringify(userData));
}

export async function logout() {
    await get(gc.urls.Logout);
    sessionStorage.removeItem(gc.userData);
    sessionStorage.clear()
}