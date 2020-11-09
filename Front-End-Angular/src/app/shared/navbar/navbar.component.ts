import { Component, Injector, OnInit} from '@angular/core';
import { BaseComponent } from '../../lib/base-component';
import 'rxjs/add/operator/takeUntil';
import { AuthenticationService } from 'src/app/lib/authentication.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent extends BaseComponent implements OnInit {
  menus:any;
  constructor(injector: Injector , private authenticationService: AuthenticationService )
  {
    super(injector);
  }
  ngOnInit(): void {
    this._api.get('/api/danhmuc/get-all').takeUntil(this.unsubscribe).subscribe(res => {
      this.menus = res;
      console.log(this.menus);
    });
  }
  logout() {
    this.authenticationService.logout();
  }

}
