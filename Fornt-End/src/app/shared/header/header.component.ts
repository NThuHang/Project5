import { Component, Injector, OnInit} from '@angular/core';
import { BaseComponent } from '../../lib/base-component';
import 'rxjs/add/operator/takeUntil';
import { AuthenticationService } from 'src/app/lib/authentication.service';
import { User } from 'src/app/models/user';
import { BehaviorSubject, Observable } from 'rxjs-compat';
@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent extends BaseComponent implements OnInit {
  taikhoans : any;
  gv: any;
  private userSubject: BehaviorSubject<User>;
  public TaiKhoan: Observable<User>;
  constructor(injector: Injector , private authenticationService: AuthenticationService )
  {
    super(injector);
    this.userSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('TaiKhoan')));
    this.TaiKhoan = this.userSubject.asObservable();
  }
  ngOnInit(): void {
    this.thongtin();
    this.lay_thong_tin();
  }
  thongtin(){
    this.taikhoans = JSON.parse(localStorage.getItem('TaiKhoan'));
  }

  lay_thong_tin(){
    this._api.get('/api/giangvien/get-thongtin/'+ this.taikhoans.id).takeUntil(this.unsubscribe).subscribe(res => {
      this.gv = res;
    });
  }
  logout() {
    this.authenticationService.logout();
  }

}
