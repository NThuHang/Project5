import { Component, Injector, OnInit} from '@angular/core';
import { BaseComponent } from '../../lib/base-component';
import 'rxjs/add/operator/takeUntil';
import { AuthenticationService } from 'src/app/lib/authentication.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent extends BaseComponent implements OnInit {
  taikhoans:any;
  constructor(injector: Injector , private authenticationService: AuthenticationService )
  {
    super(injector);
  }
  ngOnInit(): void {
    this._api.get('/api/giangvien/get-thongtin/').takeUntil(this.unsubscribe).subscribe(res => {
      this.taikhoans = res;
      console.log(this.taikhoans);
    });
  }
  logout() {
    this.authenticationService.logout();
  }

}
