import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { from, Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class LoginService {
  Url: string;
  token: string;
  header: any;
  constructor(private http: HttpClient) {
    this.Url = 'http://localhost:44337/Home';
    alert(this.Url);
    const headerSettings: { [name: string]: string | string[]; } = {};
    this.header = new HttpHeaders(headerSettings);
  }
  Login(model: any) {
    debugger;
    var a = this.Url + 'Login';
    return this.http.post<any>(this.Url + 'Login', model, { headers: this.header });
  }

}
