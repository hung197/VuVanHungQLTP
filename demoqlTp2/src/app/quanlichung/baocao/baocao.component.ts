import { Component, OnInit } from '@angular/core';
import { QuanhuyenService } from 'src/app/shared/quanhuyen.service';
import { ThanhphoService } from 'src/app/shared/thanhpho.service';
import { XaphuongService } from 'src/app/shared/xaphuong.service';

@Component({
  selector: 'app-baocao',
  templateUrl: './baocao.component.html',
  styleUrls: ['./baocao.component.css']
})
export class BaocaoComponent implements OnInit {

  constructor(private thanhphoService: ThanhphoService, private quanhuyenService: QuanhuyenService, private xaphuongService: XaphuongService) { }
  ThanhPhoList: any[] = [];
  QuanHuyenList: any[] = [];
  XaPhuongList: any[] = [];
  MaTp!: string;
  currentPage = 1;
  PageSize = 4;
  meta: any;
  MaQuanHuyen!: string;
  MaXaPhuong!: string;
  ngOnInit(): void {
    this.thanhphoService.getAllThanhPho().subscribe((res: any) => {
      this.ThanhPhoList = res;
      console.log(res);
      this.ThanhPhoList.forEach((item) => {
        console.log(this.ThanhPhoList);

        this.quanhuyenService.getQuanHuyenById(item.maTp).subscribe((result: any) => {
          console.log(result);
          item.tenQuanHuyen = result.map((x: any) => x.tenQuanHuyen);
          console.log(result);
          item.tenXaPhuong = ''
          result.forEach((item_1: any) => {
            console.log(item_1);
            this.xaphuongService.getXaphuongById(item_1.maQuanHuyen)
              .subscribe((result: any) => {
                if (
                  result != null &&
                  result != undefined &&
                  result.length > 0
                ) {
                  console.log(result.sort());
                  var name = result.map((x: any) => x.tenXaPhuong);
                  if (name != null && name.length > 0) {
                    name.forEach((ele: string) => {
                      item.tenXaPhuong += ele + ',';
                      console.log(item.tenXaPhuong);

                    })
                  }

                }
              })
          });
        });
      });
      this.quanhuyenService.getQuanHuyenList().subscribe((res: any) => {
        this.QuanHuyenList = res;
      });
    });
  }

}
