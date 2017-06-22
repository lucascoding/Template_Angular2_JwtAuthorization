import { Injectable } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map'
import { WebApiService } from "app/_services/webApi.service";
import { Router } from "@angular/router";

@Injectable()
export class AuthenticationService {
    constructor(private http: Http,
        public webApiService: WebApiService,
        public router: Router) { }

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
                    this.setSession(user.token);
                }

                return user;
            });
    }

    private setSession(token: string) {
        // store user details and jwt token in local storage to keep user logged in between page refreshes
        const expiresAt = JSON.stringify(10000 + new Date().getTime());
        localStorage.setItem('access_token', JSON.stringify(token));
        localStorage.setItem('expires_at', expiresAt);
    }

    private clearSession() {
        localStorage.removeItem('access_token');
        localStorage.removeItem('expires_at');
    }

    logout() {
        // remove user from local storage to log user out
        this.clearSession();
        this.router.navigate(['/']);
    }

    public isAuthenticated(): boolean {
        // Check whether the current time is past the
        // access token's expiry time
        const expiresAt = JSON.parse(localStorage.getItem('expires_at'));
        let isExperied = !(new Date().getTime() < expiresAt);

        if (isExperied) {
            this.logout();
            return false;
        }
        else return true;

    }
}