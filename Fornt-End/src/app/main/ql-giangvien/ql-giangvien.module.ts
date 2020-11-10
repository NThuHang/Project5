import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GiangvienComponent } from './giangvien/giangvien.component';
import { QtDaotaoComponent } from './qt-daotao/qt-daotao.component';
import { QtCongtacComponent } from './qt-congtac/qt-congtac.component';
import { NgoainguComponent } from './ngoaingu/ngoaingu.component';
import { TinhocComponent } from './tinhoc/tinhoc.component';



@NgModule({
  declarations: [GiangvienComponent, QtDaotaoComponent, QtCongtacComponent, NgoainguComponent, TinhocComponent],
  imports: [
    CommonModule
  ]
})
export class QlGiangvienModule { }
