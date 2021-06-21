import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

@Injectable({
    providedIn: 'root'
})
export class AuthService{

    path: string = 'https://localhost:5001/Authenticate/Authentication'

    constructor(private http: HttpClient) { }

    login(username, password){
        return this.http.post<any>(this.path, {username, password});
    }
}