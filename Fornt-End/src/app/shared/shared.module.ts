import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FooterComponent } from './footer/footer.component';
import { HeaderComponent } from './header/header.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { FileNotFoundComponent } from './file-not-found/file-not-found.component';
import { UnauthorizedComponent } from './unauthorized/unauthorized.component';



@NgModule({
  declarations: [FooterComponent, HeaderComponent, SidebarComponent, FileNotFoundComponent, UnauthorizedComponent],
  imports: [
    CommonModule
  ]
})
export class SharedModule { }
