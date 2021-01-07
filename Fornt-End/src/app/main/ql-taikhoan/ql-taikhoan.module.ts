import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from 'src/app/shared/shared.module';
import { RouterModule } from '@angular/router';
import { TaikhoanComponent } from './taikhoan/taikhoan.component';

@NgModule({
  declarations: [TaikhoanComponent],
  imports: [
    CommonModule,
    SharedModule,
    RouterModule.forChild([
      {
        path: 'taikhoan',
        component: TaikhoanComponent,
      },
    ]),
  ]
})
export class QltaikhoanModule { }


