import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import { User } from "app/_models/user";
import { WebApiService } from "app/_services/webApi.service";


@Injectable()
export class UserService {
    constructor(private http: Http,
        public webApiService: WebApiService) { }

    getMyInfo() {
        return this.http.get(`${this.webApiService.webServiceAddressIp}/user/GetMyInfo`, this.jwt()).map((response: Response) => response.json());
    }

    getAll() {
        return this.http.get('/api/users', this.jwt()).map((response: Response) => response.json());
    }

    getById(id: number) {
        return this.http.get('/api/users/' + id, this.jwt()).map((response: Response) => response.json());
    }

    create(user: User) {
        return this.http.post('/api/users', user, this.jwt()).map((response: Response) => response.json());
    }

    update(user: User) {
        return this.http.put('/api/users/' + user.id, user, this.jwt()).map((response: Response) => response.json());
    }

    delete(id: number) {
        return this.http.delete('/api/users/' + id, this.jwt()).map((response: Response) => response.json());
    }

    // private helper methods

    private jwt() {
        // create authorization header with jwt token
        let token = JSON.parse(localStorage.getItem('access_token'));
        let headers = this.webApiService.headers;
        if (token) {
            headers.delete('Authorization');
            headers.append('Authorization', 'Bearer ' + token);
            return new RequestOptions({ headers: headers });
        }
    }
}