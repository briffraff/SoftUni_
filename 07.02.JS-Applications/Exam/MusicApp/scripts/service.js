//  imports
import { gc } from './data.js';


// exported functions
export function getUserData() {
    return JSON.parse(sessionStorage.getItem(gc.userData));
}

export function setUserData(data) {
    sessionStorage.setItem(gc.userData, JSON.stringify(data));
}

export function clearUserData() {
    sessionStorage.removeItem(gc.userData);
}