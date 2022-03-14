export const constants = {
    userData: 'userData',

    urls: {
        Host: 'http://localhost:3030',
        Login: '/users/login',
        Register: '/users/register',
        Logout: '/users/logout',
        Students: "/jsonstore/advanced/table",
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
};