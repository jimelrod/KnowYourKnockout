import {inject} from 'aurelia-framework';
import {ServiceBase} from './serviceBase';

@inject(ServiceBase)
export class UserService {
    constructor(svc) {
        this.svc = svc;
    }

    getUser(id) {        
        return this.svc.get('values/' + id);
    }

    // REMOVE THIS FOR PRODUCTION
    getUsers() {
        console.warn("REMOVE THIS METHOD!!! UserService.getUsers()");

        return this.svc.get('Users');
    }
}