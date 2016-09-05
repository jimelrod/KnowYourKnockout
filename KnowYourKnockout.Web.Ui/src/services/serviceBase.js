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

    get(endpoint, params) {
        if (params) {
            if (typeof params === 'object') {
                let queryString = "?";
                let kvpAry = [];

                for (var key in params) {
                    if (params.hasOwnProperty(key)) {
                        console.log(key + " -> " + p[key]);
                        kvpAry.push(`${param}=${param[key]}`);
                    }
                }

                endpoint += `?${kvpAry.join('&')}`;
            }
            else if (typeof params === 'string') {
                endpoint += `?${params}`;
            }
        }

        return this.http.fetch(endpoint)
            .then(response => {
                console.log(response);
                return response.json();
            });
    }

    post(endpoint, body) {
        return this.http.fetch(endpoint, {
            method: 'post',
            body: json(body)
        }).then(response => {
            console.log(response);
            return response.json();
        });
    }

    put() {
        return this.http.fetch(endpoint, {
            method: 'put',
            body: json(body)
        }).then(response => response.json());
    }

    remove() {
        return this.http.fetch(endpoint, {
            method: 'delete',
            body: json(body)
        }).then(response => response.status);
    }
}