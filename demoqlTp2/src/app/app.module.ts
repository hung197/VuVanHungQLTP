import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ThanhphoComponent } from './quanlichung/thanhpho/thanhpho.component';
import { QuanhuyenComponent } from './quanlichung/quanhuyen/quanhuyen.component';
import { XaphuongComponent } from './quanlichung/xaphuong/xaphuong.component';
import { NzLayoutModule } from 'ng-zorro-antd/layout';
import { HeaderComponent } from './quanliContainer/header/header.component';
import { SiderComponent } from './quanliContainer/sider/sider.component';
import { NzMenuModule } from 'ng-zorro-antd/menu';
import { NzTableModule } from 'ng-zorro-antd/table';
import { HttpClientModule } from '@angular/common/http';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzDatePickerModule } from 'ng-zorro-antd/date-picker';
import { NzModalModule } from 'ng-zorro-antd/modal';
import { FormsModule } from '@angular/forms';
import { IconDefinition } from '@ant-design/icons-angular';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { AccountBookFill, AlertFill, AlertOutline } from '@ant-design/icons-angular/icons';
import { NzSelectModule } from 'ng-zorro-antd/select';
import { BaocaoComponent } from './quanlichung/baocao/baocao.component';
const icons: IconDefinition[] = [ AccountBookFill, AlertOutline, AlertFill ];
import { NzFormModule } from 'ng-zorro-antd/form';
import { registerLocaleData } from '@angular/common';
import en from '@angular/common/locales/en';
registerLocaleData(en);

/** config ng-zorro-antd i18n **/
import { NZ_I18N, en_US } from 'ng-zorro-antd/i18n';
import { Baocao2Component } from './baocao/baocao2/baocao2.component';

@NgModule({
  declarations: [
    AppComponent,
    ThanhphoComponent,
    QuanhuyenComponent,
    XaphuongComponent,
    HeaderComponent,
    SiderComponent,
    BaocaoComponent,
    Baocao2Component,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NzLayoutModule,
    NzMenuModule,
    BrowserAnimationsModule,
    NzTableModule,
    HttpClientModule,
    NzButtonModule,
    NzDatePickerModule,
    NzModalModule,
    FormsModule,
    NzIconModule,
    NzIconModule.forRoot(icons),
    NzSelectModule,
    NzFormModule
  ],
  providers: [
    { provide: NZ_I18N, useValue: en_US }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
