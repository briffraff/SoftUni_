
export const constants = {
    userData: 'userData',

    urls: {
        Host: 'http://localhost:3030',
        Login: '/users/login',
        Register: '/users/register',
        Logout: '/users/logout',

        catalog: '/data/albums?sortBy=_createdOn%20desc&distinct=name',
        create: '/data/albums',
        details: (id) => `/data/albums/${id}`,
        delete: (id) => `/data/albums/${id}`,
        edit: (id) => `/data/albums/${id}`,
        search: (name) => `/data/albums?where=name%20LIKE%20%22${name}%22`
    },

    headers: {
        ContentType: 'Content-Type',
        XAuthorization: 'X-Authorization',

        values: {
            ContentType: 'application/json'
        }
    },

    errors: {
        err403: 403,
        err204: 204,
    },

    requestMethods: {
        POST: 'post',
        GET: 'get',
        PUT: 'put',
        DELETE: 'delete',
    },

    views: {
        home: 'home',
        login: 'login',
        register: 'register',
    },

    nav: {
        home: '/home',
        login: '/login',
        register: '/register',
        create: '/create',
        details: '/details/:id',
        edit: '/edit/:id',
        catalog: '/catalog',
        search: '/search',  
    }
};