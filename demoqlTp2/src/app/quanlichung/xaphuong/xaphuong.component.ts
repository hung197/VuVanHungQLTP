import { Component, OnInit } from '@angular/core';
import { QuanhuyenService } from 'src/app/shared/quanhuyen.service';
import { XaphuongService } from 'src/app/shared/xaphuong.service';

@Component({
  selector: 'app-xaphuong',
  templateUrl: './xaphuong.component.html',
  styleUrls: ['./xaphuong.component.css']
})
export class XaphuongComponent implements OnInit {
  xaPhuongList: any = [];
  quanHuyenList: any[] = [];
  MaQuanHuyen!: any;
  MaXaPhuong!: any;
  TenXaPhuong!: any;
  TenQuanHuyen!: string;
  metadata: any;
  currentPage = 1;
  PageSize = 4;

  isVisible = false;
  isVisible2 = false;
  QuanHuyenList: any[] = [];
  constructor(private xaphuongService: XaphuongService, private quanhuyenService: QuanhuyenService) { }
  refreshXaPhuongList() {
    this.xaphuongService.getXaPhuongphantrang(this.currentPage, this.PageSize).subscribe((res: any) => {
      this.metadata=res;
      this.xaPhuongList = res.xaphuongs;
    });
  }
  ngOnInit(): void {
    this.refreshXaPhuongList();
    this.quanhuyenService.getQuanHuyenList().subscribe((data: any) => {
      this.quanHuyenList = data;
    });
  }
  showAdd() {
    this.isVisible2 = true;
    this.MaXaPhuong = '0';
    this.TenXaPhuong = '';
    this.MaQuanHuyen = null;
  }
  handleCancel(): void {
    console.log('Button cancel clicked');
    this.isVisible = false;
    this.isVisible2 = false;

  }
  addClick() {
    let val = {
      TenXaPhuong: this.TenXaPhuong,
      MaQuanHuyen: this.MaQuanHuyen,
      MaXaPhuong: this.MaXaPhuong
    };
    if (val.TenXaPhuong == '' || val.MaQuanHuyen == null) {
      console.log(val);

      alert('Mời bạn nhập thông tin');
    } else {
      this.xaphuongService.postXaPhuong(val).subscribe((res: any) => {
        alert('Thêm mới thành công');
        this.refreshXaPhuongList();
      });
      this.isVisible2 = false;

    }

  }
  onKeyPress(event: KeyboardEvent) {
    if (event.code === 'Enter') {
      this.addClick();
    }
  }
  showModal(data: any): void {
    this.isVisible = true;
    this.MaXaPhuong = data.maXaPhuong;
    this.TenXaPhuong = data.tenXaPhuong;
    this.MaQuanHuyen = data.maQuanHuyen;
    this.TenQuanHuyen = data.quanHuyen.tenQuanHuyen
  }
  deleteClick(id: any) {
    if (confirm('Bạn có chắc chắn muốn xóa Xã Phường ra khỏi danh sách')) {
      this.xaphuongService.deleteXaPhuong(id).subscribe((res: any) => {
        alert('Xóa thành công');
        this.refreshXaPhuongList();
      });
    }
  }
  updateXaPhuong() {
    let val = {
      TenXaPhuong: this.TenXaPhuong,
      MaXaPhuong: this.MaXaPhuong,
      MaQuanHuyen: this.MaQuanHuyen
    };
    if (val.TenXaPhuong == '' || val.MaQuanHuyen == null) {
      alert('Mời bạn nhập thông tin');
    } else {
      this.xaphuongService.putXaPhuong(val).subscribe((res: any) => {
        alert('Sửa thành công');
        this.refreshXaPhuongList();
      });
      this.handleCancel();
    }

  }
  onKeyUpdate(event: KeyboardEvent) {
    if (event.code === 'Enter') this.updateXaPhuong();
  }
  abc(event:any){
    this.currentPage = event;
    this.refreshXaPhuongList();
  }
}

