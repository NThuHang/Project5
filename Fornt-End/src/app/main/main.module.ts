import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from '../shared/header/header.component';
import { SidebarComponent } from '../shared/sidebar/sidebar.component';
import { FooterComponent } from '../shared/footer/footer.component';
import { MainComponent } from './main.component';
import { RouterModule, Routes } from '@angular/router';
import { SharedModule } from '../shared/shared.module';
import {HomeComponent} from './home/home.component';
import { RoleGuard } from '../lib/auth.guard';
import { Role } from '../models/role';
import { UnauthorizedComponent } from '../shared/unauthorized/unauthorized.component';
import { FileNotFoundComponent } from '../shared/file-not-found/file-not-found.component';

export const mainRoutes: Routes = [
  {
    path: '',
    component: MainComponent,
    children: [
      {
        path: 'trangchu',
        component: HomeComponent,
      },
      {
        path: 'not-found',
        component: FileNotFoundComponent,
      },
      {
        path: 'unauthorized',
        component: UnauthorizedComponent,
      },
      {
        path: 'qlgiangvien',
        loadChildren: () =>
          import('./ql-giangvien/ql-giangvien.module').then((m) => m.QlGiangvienModule),
          // canActivate: [RoleGuard],
          // data: { Quyen: [Role.Admin] },
      },
      {
        path: 'qlbaochi',
        loadChildren: () =>
          import('./ql-baochi/ql-baochi.module').then((m) => m.QlBaochiModule),
          // canActivate: [RoleGuard],
          // data: { Quyen: [Role.Admin] },
      },
    ],
  },
];

@NgModule({
  declarations: [
    HeaderComponent,
    SidebarComponent,
    FooterComponent,
    MainComponent
  ],
  imports: [
    SharedModule,
    CommonModule,
    RouterModule.forChild(mainRoutes)],
})
export class MainModule { }
