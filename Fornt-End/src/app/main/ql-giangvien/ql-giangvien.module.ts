import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { GiangvienComponent } from './giangvien/giangvien.component';
import { QtCongtacComponent } from './qt-congtac/qt-congtac.component';
import { QtDaotaoComponent } from './qt-daotao/qt-daotao.component';
import { SharedModule } from 'src/app/shared/shared.module';

@NgModule({
  declarations: [GiangvienComponent],
  imports: [
    CommonModule,
    SharedModule,
    RouterModule.forChild([
      {
        path: 'giangvien',
        component: GiangvienComponent,
      },
      {
        path: 'congtac',
        component: QtCongtacComponent,
      },
      {
        path: 'daotao',
        component: QtDaotaoComponent,
      },
    ]),
  ]
})
export class QlGiangvienModule { }


