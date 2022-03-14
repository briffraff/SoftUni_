
export const constants = {
    userData: 'userData',

    urls: {
        Host: 'http://localhost:3030',
        Login: '/users/login',
        Register: '/users/register',
        Logout: '/users/logout',

        catalog: '/data/theaters?sortBy=_createdOn%20desc&distinct=title',
        create: '/data/theaters',
        like: '/data/likes',
        details: (id) => `/data/theaters/${id}`,
        delete: (id) => `/data/theaters/${id}`,
        edit: (id) => `/data/theaters/${id}`,
        profile: (userId) => `/data/theaters?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`,
        total: (theaterId) => `/data/likes?where=theaterId%3D%22${theaterId}%22&distinct=_ownerId&count`,
        own: (theaterId, userId) => `/data/likes?where=theaterId%3D%22${theaterId}%22%20and%20_ownerId%3D%22${userId}%22&count`
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
        profile: '/profile',  
    }
};