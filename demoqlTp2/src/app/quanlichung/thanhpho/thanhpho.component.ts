import { Component, OnInit } from '@angular/core';
import { ThanhphoService } from 'src/app/shared/thanhpho.service';

@Component({
  selector: 'app-thanhpho',
  templateUrl: './thanhpho.component.html',
  styleUrls: ['./thanhpho.component.css']
})
export class ThanhphoComponent implements OnInit {
  thanhphoList: any = [];
  isVisible2 = false;
  maTp!: string;
  tenTp!: string;
  meta: any;
  currentPage = 1;
  PageSize = 4;
  isVisible = false;
  constructor(private thanhphoService: ThanhphoService) { }
  refreshThanhPhoList() {
    this.thanhphoService.getThanhPhoList(this.currentPage, this.PageSize).
      subscribe((result) => {
        this.meta = result;
        this.thanhphoList = result.thanhphos;
        console.log(result);

      });
  }
  ngOnInit(): void {
    this.refreshThanhPhoList();
  }
  AddForm() {
    this.isVisible2 = true;
    this.maTp = '0';
    this.tenTp = '';
  }
  handleCancel() {
    console.log('Nhấn để hủy!');
    this.isVisible = false;
    this.isVisible2 = false;

  }
  addClick() {
    let val = {
      tenTp: this.tenTp,
      maTp: this.maTp
    }
    if (val.maTp == '') {
      alert('Mời bạn nhập thông tin thành phố');
    } else {
      this.thanhphoService.postThanhPho(val).subscribe((res) => {
        alert('Thêm mới thành công');
        this.refreshThanhPhoList();
      });
      this.isVisible2 = false;
    }
  }

  handleOk(event: KeyboardEvent) {


    if (event.code === 'Enter') {
      this.addClick();
      this.isVisible = false;

    }
  }
  updateThanhPho() {
    let val = {
      tenTp: this.tenTp,
      maTp: this.maTp,
    };
    if (val.maTp == '') {
      alert('Nhập thông tin thành phố');
    } else {
      console.log('Oke?');
      this.thanhphoService.putThanhPho(val).subscribe((res: any) => {
        alert('Sửa thành công');
        this.refreshThanhPhoList();
      });
    }
    this.handleCancel();
  }
  onKeyUpdate(event: KeyboardEvent) {

    if (event.code === 'Enter') this.updateThanhPho();
  }
  showModal(data: any): void {
    this.isVisible = true;
    this.tenTp = data.tenTp;
    this.maTp = data.maTp;
  }
  DeleteClick(id: any) {
    if (confirm('Bạn có chắc chắn muốn xóa thành phố?')) {
      this.thanhphoService.deleteThanhPho(id).
        subscribe(
          (res: any) => {
            alert('Xóa thành công!');
            this.refreshThanhPhoList();
          }
        );
    }
  }
  abc(event: any) {
    console.log(event);
    this.currentPage = event;
    this.refreshThanhPhoList();
  }
}
