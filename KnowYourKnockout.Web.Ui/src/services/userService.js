import {inject} from 'aurelia-framework';
import {HttpClient} from 'aurelia-fetch-client';
import 'fetch';

@inject(HttpClient)
export class UserService{
    constructor(http) {
        http.configure(config => {
            config
              .useStandardConfiguration()
              .withBaseUrl('http://localhost:4753/api/');
        });

        this.http = http;
    }

    getUser(id) {
        return this.http.fetch('values/' + id)
            .then(response => response.json())
            .then(user => console.log(user));
    }
}