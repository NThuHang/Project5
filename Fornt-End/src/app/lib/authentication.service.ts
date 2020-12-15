import { environment } from './../../environments/environment';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { User } from '../models/user';

@Injectable({ providedIn: 'root' })
export class AuthenticationService {
    private userSubject: BehaviorSubject<User>;
    public TaiKhoan: Observable<User>;

    constructor(
        private router: Router,
        private http: HttpClient
    ) {
        this.userSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('TaiKhoan')));
        this.TaiKhoan = this.userSubject.asObservable();
    }

    public get userValue(): User {
        return this.userSubject.value;

    }

    login(username: string, password: string) {
        return this.http.post<any>(`${environment.apiUrl}/api/taikhoan/xacthuctk`, { username, password })
            .pipe(map(TaiKhoan => {
                //debugger;
                // store user details and jwt token in local storage to keep user logged in between page refreshes
                localStorage.setItem('TaiKhoan', JSON.stringify(TaiKhoan));
                this.userSubject.next(TaiKhoan);
                return TaiKhoan;
            }));
    }

    logout() {
        // remove user from local storage to log user out
        localStorage.removeItem('TaiKhoan');
        this.userSubject.next(null);
        this.router.navigate(['/login']);
    }

    remove() {
        // remove user from local storage to log user out
        localStorage.removeItem('TaiKhoan');
        this.userSubject.next(null);
    }
}
