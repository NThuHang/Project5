import { Component, Injector, OnInit, ViewChild } from '@angular/core';
import { FileUpload } from 'primeng/fileupload';
import { FormBuilder,FormControl, Validators} from '@angular/forms';
import { BaseComponent } from '../../../lib/base-component';
import 'rxjs/add/operator/takeUntil';
declare var $: any;

@Component({
  selector: 'app-giangvien',
  templateUrl: './giangvien.component.html',
  styleUrls: ['./giangvien.component.css']
})
export class GiangvienComponent extends BaseComponent implements OnInit {
  public giangviens: any ;
  public giangvien: any;
  public totalRecords:any;
  public pageSize = 3;
  public page = 1;
  public uploadedFiles: any[] = [];
  public formsearch: any;
  public formdata: any;
  public formload: any;
  public doneSetupForm: any;
  public showUpdateModal:any;
  public showCTModal:any;
  public isCreate:any;
  public congtac:any;
  public daotao:any;
  submitted = false;
  pages: any;
  @ViewChild(FileUpload, { static: false }) file_image: FileUpload;
  constructor(private fb: FormBuilder, injector: Injector) {
    super(injector);
  }
  ngOnInit(): void {
    this.formsearch = this.fb.group({
      'hoten': [''],
    });
    this.search();
  }

  updateValue(value: any){
    this.pages = value;
    this.search();
  }

  loadPage(page) {
    if(this.pages != null){
      this.pageSize = this.pages;
    }
    else{
      this.pageSize = 5;
    }
    this._api.post('/api/giangvien/search',{page: page, pageSize: this.pageSize}).takeUntil(this.unsubscribe).subscribe(res => {
      this.giangviens = res.data;
      this.totalRecords =  res.totalItems;
      this.pageSize = res.pageSize;
      });
  }

  search() {
    this.page = 1;
    if(this.pages != null){
      this.pageSize = this.pages;
    }
    else{
      this.pageSize = 5;
    }
    this._api.post('/api/giangvien/search',{page: this.page, pageSize: this.pageSize , hoten: this.formsearch.get('hoten').value}).takeUntil(this.unsubscribe).subscribe(res => {
      this.giangviens = res.data;
      this.totalRecords =  res.totalItems;
      this.pageSize = res.pageSize;
      });
  }

  get f() { return this.formdata.controls; }

  onSubmit(value) {
    this.submitted = true;
    if (this.formdata.invalid) {
      return;
    }
    if(this.isCreate) {
      this.getEncodeFromImage(this.file_image).subscribe((data: any): void => {
        let data_image = data == '' ? null : data;
        let tmp = {
          HinhAnh:data_image,
          HoTen:value.hoTen,
          DiaChi:value.diaChi,
          GioiTinh:value.gioiTinh,
          Email:value.email,
          NgaySinh:value.ngaySinh,
          Sdt:value.sdt,
          QueQuan:value.queQuan,
          };
        this._api.post('/api/giangvien/create-gv',tmp).takeUntil(this.unsubscribe).subscribe(res => {
          alert('Thêm thành công');
          this.search();
          this.closeModal();

          });
      });
    } else {
      this.getEncodeFromImage(this.file_image).subscribe((data: any): void => {
        let data_image = data == '' ? null : data;
        let tmp;
        if(data==''){
          tmp = {
            HinhAnh:this.giangvien.hinhAnh,
            HoTen:value.hoTen,
            DiaChi:value.diaChi,
            GioiTinh:value.gioiTinh,
            Email:value.email,
            NgaySinh:value.ngaySinh,
            Sdt:value.sdt,
            QueQuan:value.queQuan,
            ID_GV:this.giangvien.iD_GV,
          };
        }
        else{
          tmp = {
            HinhAnh:data_image,
            HoTen:value.hoTen,
            DiaChi:value.diaChi,
            GioiTinh:value.gioiTinh,
            Email:value.email,
            NgaySinh:value.ngaySinh,
            Sdt:value.sdt,
            QueQuan:value.queQuan,
            ID_GV:this.giangvien.iD_GV,
          };
        }
        this._api.post('/api/giangvien/update-gv',tmp).takeUntil(this.unsubscribe).subscribe(res => {
          alert('Cập nhật thành công!');
          this.search();
          this.closeModal();
          });
      });
    }

  }

  onDelete(row) {
    this._api.post('/api/GiangVien/delete-gv',{gv_id:row.iD_GV}).takeUntil(this.unsubscribe).subscribe(res => {
      alert('Xóa thành công');
      this.search();
      });
  }

  public chitiet(row) {
    this.showCTModal=true;
    setTimeout(() => {
      $('#profileModal').modal('toggle');
      this._api.get('/api/giangvien/get-by-id/'+ row.iD_GV).subscribe(res=> {
        this.giangvien = res;
        });
      this._api.get('/api/qt_congtac/get-gv/'+ row.iD_GV).subscribe(res=>{
        this.congtac = res;
      });
      this._api.get('/api/qt_daotao/get-gv/'+ row.iD_GV).subscribe(res=>{
        this.daotao = res;
      });
    });
  }

  Reset() {
    this.giangvien = null;
    this.formdata = this.fb.group({
      'hoTen': ['', Validators.required],
      'hinhAnh': ['', Validators.required],
      'ngaySinh': [this.today, Validators.required],
      'gioiTinh': [this.genders[0].value, Validators.required],
      'queQuan': [''],
      'diaChi': ['', Validators.required],
      'sdt': ['', Validators.required],
      'email': ['', Validators.required],
    } );
  }

  createModal() {
    this.doneSetupForm = false;
    this.showUpdateModal = true;
    this.isCreate = true;
    this.giangvien = null;
    setTimeout(() => {
      $('#createUserModal').modal('toggle');
      this.formdata = this.fb.group({
        'hoTen': ['', Validators.required],
        'hinhAnh': [''],
        'ngaySinh': ['', Validators.required],
        'gioiTinh': ['', Validators.required],
        'queQuan': [''],
        'diaChi': ['', Validators.required],
        'sdt': ['', Validators.required,Validators.pattern(/[0-9]*/)],
        'email': ['', [Validators.required,Validators.email]],
      });
      this.formdata.get('ngaySinh').setValue(this.today);
      this.formdata.get('gioiTinh').setValue(this.genders[0].value);
      this.doneSetupForm = true;
    });
  }

  public openUpdateModal(row) {
    this.doneSetupForm = false;
    this.showUpdateModal = true;
    this.isCreate = false;
    setTimeout(() => {
      $('#createUserModal').modal('toggle');
      this._api.get('/api/giangvien/get-by-id/'+ row.iD_GV).takeUntil(this.unsubscribe).subscribe((res:any) => {
        this.giangvien = res;
        let ngaySinh = new Date(this.giangvien.ngaySinh);
          this.formdata = this.fb.group({
            'hoTen': [this.giangvien.hoTen, Validators.required],
            'hinhAnh': [this.giangvien.hinhAnh],
            'ngaySinh': [ngaySinh, Validators.required],
            'gioiTinh': [this.giangvien.gioiTinh, Validators.required],
            'queQuan': [this.giangvien.queQuan],
            'diaChi': [this.giangvien.diaChi, Validators.required],
            'sdt': [this.giangvien.sdt, Validators.required],
            'email': [this.giangvien.email, [Validators.required,Validators.email]],
          });
          this.doneSetupForm = true;
        });
    }, 700);
  }

  closeModal() {
    $('#createUserModal').closest('.modal').modal('hide');
    $('#profileModal').closest('.modal').modal('hide');
  }
}
