import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { Baocao2Component } from './baocao/baocao2/baocao2.component';
import { BaocaoComponent } from './quanlichung/baocao/baocao.component';
import { QuanhuyenComponent } from './quanlichung/quanhuyen/quanhuyen.component';
import { ThanhphoComponent } from './quanlichung/thanhpho/thanhpho.component';
import { XaphuongComponent } from './quanlichung/xaphuong/xaphuong.component';
import { SiderComponent } from './quanliContainer/sider/sider.component';

const routes: Routes = [
  { path: "thanhpho", component: ThanhphoComponent },
  { path: "quanhuyen", component: QuanhuyenComponent },
  {path: "xaphuong" , component:XaphuongComponent},
  {path: "sider", component:SiderComponent},
  {path: "baocao", component:BaocaoComponent},
  {path: "baocao2", component:Baocao2Component}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
