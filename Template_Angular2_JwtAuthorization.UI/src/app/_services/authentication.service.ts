import { Injectable } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map'
import { WebApiService } from "app/_services/webApi.service";

@Injectable()
export class AuthenticationService {
    constructor(private http: Http,
        private webApiService: WebApiService) { }

    login(username: string, password: string) {

        let body = JSON.stringify({ username: username, password: password });
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        return this.http.post(`${this.webApiService.webServiceAddressIp}/user/log`, body, options)
            .map((response: Response) => {
                console.log("Response from server received");
                // login successful if there's a jwt token in the response
                let user = response.json();
                console.log(user);
                if (user && user.token) {
                    // store user details and jwt token in local storage to keep user logged in between page refreshes
                    localStorage.setItem('currentUser', JSON.stringify(user));
                }

                return user;
            });
    }

    logout() {
        // remove user from local storage to log user out
        localStorage.removeItem('currentUser');
    }
}