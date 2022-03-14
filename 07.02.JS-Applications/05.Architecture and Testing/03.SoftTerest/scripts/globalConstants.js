export const constants = {
    userData: 'userData',

    urls: {
        Host: 'http://localhost:3030',
        Login: '/users/login',
        Register: '/users/register',
        Logout: '/users/logout',
        IdeasFilter: '/data/ideas?select=_id%2Ctitle%2Cimg&sortBy=_createdOn%20desc',
        Ideas: '/data/ideas'
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
        catalog: 'dashboard-holder',
        create: 'create',
        login: 'login',
        register: 'register',
        details: 'details',
    },

    nav: {
        getStartedNav: '#getStartedNav',
        'home': '#homeNav',
        'catalog': '#catalogNav',
        'create': '#createNav',
        'login': '#loginNav',
        'register': '#registerNav',
        'logout': '#logoutNav'
    }
};