import { Component, Injector, OnInit, ViewChild } from '@angular/core';
import { FileUpload } from 'primeng/fileupload';
import { FormBuilder, Validators} from '@angular/forms';
import { BaseComponent } from '../../../lib/base-component';
import 'rxjs/add/operator/takeUntil';
declare var $: any;

@Component({
  selector: 'app-tinhoc',
  templateUrl: './tinhoc.component.html',
  styleUrls: ['./tinhoc.component.css']
})
export class TinhocComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
