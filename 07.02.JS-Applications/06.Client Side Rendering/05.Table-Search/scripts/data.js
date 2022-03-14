import * as api from './api.js';
import { constants as gc } from './globalConstants.js';

export async function getAllStudents() {
    return api.get(gc.urls.Students);
}
