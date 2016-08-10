import {inject} from 'aurelia-framework';
import {HttpClient} from 'aurelia-fetch-client';
import 'fetch';

@inject(HttpClient)
export class ServiceBase {
    constructor(http) {
        http.configure(config => {
            config
              .useStandardConfiguration()
              .withBaseUrl('http://localhost:4753/api/');
        });

        this.http = http;
    }

    fetch(o) {
        return this.http.fetch(o);
    }
}