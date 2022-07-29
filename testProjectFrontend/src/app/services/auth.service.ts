import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class AuthService {
    constructor(private http: HttpClient) {
    }

    public Auth(email: string, password: string) {
        this.http.post("https://localhost:7261/api/Login/auth", { email, password })
          .subscribe(res => {
             let token = JSON.parse(JSON.stringify(res))["accessToken"]["access_token"];
              localStorage.setItem("access_token", token);
          })
    }
}
