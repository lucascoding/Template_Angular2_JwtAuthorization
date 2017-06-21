import { Http, Response, Headers } from '@angular/http';

export class WebApiService {
    webServiceAddressIp: string = "http://localhost:51023/api";
    headers: Headers = new Headers();

    constructor() {
        this.headers = new Headers();
        this.headers.append('Content-Type', 'application/json');
        this.headers.append('Accept', 'application/json');
    }

}

