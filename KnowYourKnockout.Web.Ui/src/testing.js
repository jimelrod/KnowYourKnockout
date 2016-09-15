import {inject} from 'aurelia-framework';
import {UserService} from './services/userService.js';

@inject(UserService)
export class Testing {
    constructor(userService, testService) {
        this.userService = userService;
    }

    logUser(id) {
        this.userService.getUser(id).then(user => console.log(user));
    }

    logUsers() {
        this.userService.getUsers().then(users => console.log(users));
    }
}