import { Component, Injector, OnInit, ViewChild } from '@angular/core';
import { FileUpload } from 'primeng/fileupload';
import { FormBuilder, Validators} from '@angular/forms';
import { BaseComponent } from '../../../lib/base-component';
import 'rxjs/add/operator/takeUntil';
declare var $: any;

@Component({
  selector: 'app-ngoaingu',
  templateUrl: './ngoaingu.component.html',
  styleUrls: ['./ngoaingu.component.css']
})
export class NgoainguComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
