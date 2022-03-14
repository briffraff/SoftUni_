import * as api from './api.js';

export const gc = api.gc;
export const register = api.register;
export const login = api.login;
export const logout = api.logout;

export async function getAll() {
    return api.get(gc.urls.catalog);
}

export async function getById(id) {
    return api.get(gc.urls.details(id));
}

export async function getAllByProfile(id) {
    return api.get(gc.urls.profile(id));
}

export async function getLikes(theaterId, userId) {
    return api.get(gc.urls.own(theaterId,userId));
}

export async function createItem(data) {
    return api.post(gc.urls.create, data);
}

export async function editItem(id, data) {
    return api.put(gc.urls.edit(id), data);
}

export async function deleteItem(id) {
    return api.del(gc.urls.delete(id));
}