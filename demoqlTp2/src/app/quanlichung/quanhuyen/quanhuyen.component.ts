import { Component, OnInit } from '@angular/core';
import { QuanhuyenService } from 'src/app/shared/quanhuyen.service';
import { ThanhphoService } from 'src/app/shared/thanhpho.service';

@Component({
  selector: 'app-quanhuyen',
  templateUrl: './quanhuyen.component.html',
  styleUrls: ['./quanhuyen.component.css']
})
export class QuanhuyenComponent implements OnInit {
  MaThanhPhoList: any = [];
  quanhuyenList: any = [];
  MaQuanHuyen!: string;
  TenQuanHuyen!: string;
  MaTp!: string;
  TenThanhPho!: string;
  thanhPhoList: any[] = [];
  isVisible = false;
  isVisible2 = false;
  meta: any;
  currentPage = 1;
  PageSize = 4;
  showModal(data: any): void {
    this.isVisible = true;
    this.MaQuanHuyen = data.maQuanHuyen;
    this.TenQuanHuyen = data.tenQuanHuyen;
    this.MaTp = data.thanhPho.maTp;
    this.TenThanhPho = data.thanhPho.tenTp;
  }
  constructor(private quanhuyenService: QuanhuyenService, private thanhphoService: ThanhphoService) { }
  refreshQuanHuyen() {
    this.quanhuyenService.getQuanHuyenPhantrang(this.currentPage,this.PageSize).subscribe((res: any) => {
      this.meta = res;
      this.quanhuyenList = res.quanhuyens;
      console.log(res);
    });
  }
  ngOnInit(): void {
    this.refreshQuanHuyen();
    this.thanhphoService.getAllThanhPho().subscribe((data: any) => {
      this.thanhPhoList = data;
      
      this.getMaThanhPho();
    });
  }
  getMaThanhPho() {
    this.thanhphoService.getMaThanhPho().subscribe((result: any) => {
      this.MaThanhPhoList = result;

    });
  }
  showAdd() {
    this.MaTp = null;
    this.MaQuanHuyen = '';
    this.MaQuanHuyen = '0';
    this.isVisible2 = true;
  }
  handleCancel(): void {
    console.log('Button cancel clicked');
    this.isVisible = false;
    this.isVisible2 = false;
  }

  submitadd() {
    let val = {
      TenQuanHuyen: this.TenQuanHuyen,
      MaTp: this.MaTp,
      MaQuanHuyen: this.MaQuanHuyen
    };
    if (val.TenQuanHuyen == '' || val.MaTp == null) {
      alert('Mời bạn nhập đầy đủ thông tin');
    } else {
      console.log(val.MaTp);
      this.quanhuyenService.postQuanHuyen(val).subscribe((res: any) => {
        alert('Thêm mới thành công');
        this.refreshQuanHuyen();
        console.log(res);

      });
      this.isVisible2 = false;
    }
  }
  onKeyPress(event: KeyboardEvent) {
    if (event.code === 'Enter') {
      this.submitadd();
    }
  }
  deleteClick(id: any) {
    if (confirm('Bạn có chắc chắn muốn xóa quận huyện ra khỏi danh sách')) {
      this.quanhuyenService.deleteQuanHuyen(id).subscribe((res: any) => {
        alert('Xóa thành công');
        this.refreshQuanHuyen();
      });
    }

  }
  updateQuanHuyen() {
    let val = {
      MaQuanHuyen: this.MaQuanHuyen,
      TenQuanHuyen: this.TenQuanHuyen,
      MaTp: this.MaTp
    };
    if (val.TenQuanHuyen == '' || val.MaTp == null) {
      alert('Mời bạn nhập thông tin');
    } else {
      this.quanhuyenService.putQuanHuyen(val).subscribe((res: any) => {
        alert('Sửa thành công');
        this.refreshQuanHuyen();
      });
      this.handleCancel();
    }
  }
  onKeyUpdate(event: KeyboardEvent) {
    if (event.code === 'Enter') this.updateQuanHuyen();
  }
  abc(event:any){
    this.currentPage = event;
    this.refreshQuanHuyen();
  }
}
