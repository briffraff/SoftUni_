
export const constants = {
    userData: 'userData',

    urls: {
        Host: 'http://localhost:3030',
        Login: '/users/login',
        Register: '/users/register',
        Logout: '/users/logout',

        AllFurniture: '/data/catalog',
        FurnitureById: '/data/catalog/',
        myFurniture: (userId) => `/data/catalog?where=_ownerId%3D%22${userId}%22`,
        create: '/data/catalog',
        edit: '/data/catalog/',
        delete: '/data/catalog/',
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
        create: '/create',
        my: '/my-furniture',
        details: '/details/:id',
        edit: '/edit/:id',
        login: '/login',
        register: '/register',
    }
};