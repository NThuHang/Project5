import { Component, Injector, OnInit, ViewChild } from '@angular/core';
import { FileUpload } from 'primeng/fileupload';
import { FormBuilder, Validators} from '@angular/forms';
import { BaseComponent } from '../../../lib/base-component';
import 'rxjs/add/operator/takeUntil';
declare var $: any;

@Component({
  selector: 'app-qt-daotao',
  templateUrl: './qt-daotao.component.html',
  styleUrls: ['./qt-daotao.component.css']
})
export class QtDaotaoComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
