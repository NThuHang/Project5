import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from '../shared/header/header.component';
import { FooterComponent } from '../shared/footer/footer.component';
import { SidebarComponent} from '../shared/sidebar/sidebar.component';
import { MainComponent } from './main.component';
import { RouterModule, Routes } from '@angular/router';
import { SharedModule } from '../shared/shared.module';
export const mainRoutes: Routes = [
  {
    path: '',
    component: MainComponent,
    children: [
      {
        path: 'giangvien',
        component: SidebarComponent,
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
    RouterModule.forChild(mainRoutes)
  ]
})
export class MainModule { }
