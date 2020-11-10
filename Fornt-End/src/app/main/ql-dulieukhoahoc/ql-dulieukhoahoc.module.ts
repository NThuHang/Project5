import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DetaiKhoahocComponent } from './detai-khoahoc/detai-khoahoc.component';
import { HoithaoKhoahocComponent } from './hoithao-khoahoc/hoithao-khoahoc.component';
import { SachComponent } from './sach/sach.component';
import { BaibaoComponent } from './baibao/baibao.component';
import { HuongdanSinhvienNckhComponent } from './huongdan-sinhvien-nckh/huongdan-sinhvien-nckh.component';
import { SohuuTritueComponent } from './sohuu-tritue/sohuu-tritue.component';



@NgModule({
  declarations: [DetaiKhoahocComponent, HoithaoKhoahocComponent, SachComponent, BaibaoComponent, HuongdanSinhvienNckhComponent, SohuuTritueComponent],
  imports: [
    CommonModule
  ]
})
export class QlDulieukhoahocModule { }
