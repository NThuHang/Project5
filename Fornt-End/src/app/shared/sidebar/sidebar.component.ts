import { Component, Injector, OnInit} from '@angular/core';
import { BaseComponent } from '../../lib/base-component';
import 'rxjs/add/operator/takeUntil';
import { User } from 'src/app/models/user';
import { BehaviorSubject, Observable } from 'rxjs-compat';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent extends BaseComponent implements OnInit {
  menus:any;
  profile: any;
  taikhoans : any;
  private userSubject: BehaviorSubject<User>;
  public TaiKhoan: Observable<User>;
  constructor(injector: Injector) {
    super(injector);
    this.userSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('TaiKhoan')));
    this.TaiKhoan = this.userSubject.asObservable();
  }
  ngOnInit(): void {
    this.thongtin();
    this.lay_thong_tin();
    this.lay_danh_muc();
  }
  thongtin(){
    this.taikhoans = JSON.parse(localStorage.getItem('TaiKhoan'));
  }
  lay_thong_tin(){
    this._api.get('/api/giangvien/get-thongtin/'+ this.taikhoans.id).takeUntil(this.unsubscribe).subscribe(res => {
      this.profile = res;
    });
  }
  lay_danh_muc(){
    this._api.get('/api/danhmuc/get-all/'+ this.taikhoans.quyen).takeUntil(this.unsubscribe).subscribe(res => {
      this.menus = res;
    });
  }
}
