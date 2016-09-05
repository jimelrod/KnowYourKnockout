import {inject} from 'aurelia-framework';
import {ServiceBase} from './serviceBase';

@inject(ServiceBase)
export class UserService {
    constructor(svc) {
        this.svc = svc;
    }

    getUser(id) {        
        return this.svc.get('values/' + id)
            .then(user => console.log(user));
    }
}