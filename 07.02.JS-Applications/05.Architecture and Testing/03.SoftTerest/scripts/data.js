import * as api from './api.js';
import { constants as gc } from './globalConstants.js';

export const register = api.register;
export const login = api.login;
export const logout = api.logout;

export async function getAllIdeas() {
    return api.get(gc.urls.IdeasFilter);
}

export async function getById(id) {
    return api.get(gc.urls.Ideas + `/${id}`)
}

export async function createIdea(idea) {
    return api.post(gc.urls.Ideas, idea);
}

export async function deleteById(id) {
    return api.del(gc.urls.Ideas + `/${id}`);
}