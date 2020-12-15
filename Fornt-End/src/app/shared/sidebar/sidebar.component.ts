import { Component, Injector, OnInit} from '@angular/core';
import { BaseComponent } from '../../lib/base-component';
import 'rxjs/add/operator/takeUntil';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent extends BaseComponent implements OnInit {
  menus:any;
  profile: any;

  constructor(injector: Injector) {
    super(injector);
  }
  ngOnInit(): void {
    this._api.get('/api/danhmuc/get-all').takeUntil(this.unsubscribe).subscribe(res => {
      this.menus = res;
    });
  }
  lay_thong_tin(){
    this._api.get('/api/taikhoan/getthongtin/').takeUntil(this.unsubscribe).subscribe(res => {
      this.profile = res;
    });
  }

}
