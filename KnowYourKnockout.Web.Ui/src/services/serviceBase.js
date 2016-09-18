import {inject} from 'aurelia-framework';
import {HttpClient} from 'aurelia-fetch-client';
import 'fetch';

@inject(HttpClient)
export class ServiceBase {
    // TODO: Add configuration for environments...
    baseUrl = 'http://localhost:4753/api/';
    
    constructor(http) {
        http.configure(config => {
            config
              .useStandardConfiguration()
              .withBaseUrl(this.baseUrl);
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

    put(endpoint, body) {
        return this.http.fetch(endpoint, {
            method: 'put',
            body: json(body)
        }).then(response => response.json());
    }

    remove(endpoint, body) {
        return this.http.fetch(endpoint, {
            method: 'delete',
            body: json(body)
        }).then(response => response.status);
    }
}