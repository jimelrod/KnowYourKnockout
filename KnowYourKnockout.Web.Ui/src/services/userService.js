﻿import {ServiceBase} from './serviceBase';

export class UserService extends ServiceBase {
    endpointBase = 'Users';

    getUser(id) {        
        return super.get('values/' + id);
    }

    // REMOVE THIS FOR PRODUCTION
    getUsers() {
        console.warn("REMOVE THIS METHOD!!! UserService.getUsers()");

        return super.get(this.endpointBase);
    }
}