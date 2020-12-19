import { Component, OnInit } from '@angular/core';
import { ThanhphoService } from 'src/app/shared/thanhpho.service';

@Component({
  selector: 'app-baocao2',
  templateUrl: './baocao2.component.html',
  styleUrls: ['./baocao2.component.css']
})
export class Baocao2Component implements OnInit {

  constructor(private thanhphoService: ThanhphoService) { }
  ThanhPhoList: any[] = [];
 
  ngOnInit(): void {
    this.thanhphoService.getAll3Table().subscribe((res:any) =>{
      this.ThanhPhoList = res;
      this.ThanhPhoList.forEach(res => {
        res.tenXaPhuong='';
        res.tenQuanHuyen = res.quanHuyens.map(x=>x.tenQuanHuyen).join(',');
        res.quanHuyens.forEach(result => {
          res.tenXaPhuong += result.xaPhuongs.map(x=>x.tenXaPhuong).join(',');
        });
      });
    });

  }

}
