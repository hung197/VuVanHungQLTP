import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class QuanhuyenService {
  readonly Url ="http://localhost:62636/api"
  constructor(private http: HttpClient) { }
  getQuanHuyenList(){
    return this.http.get<any>(this.Url+'/QuanHuyen');
  }
  postQuanHuyen(val: any) {
    return this.http.post(this.Url + '/QuanHuyen', val);
  }
  deleteQuanHuyen(id: any) {
    return this.http.delete(this.Url + '/QuanHuyen/' + id);
  }
  putQuanHuyen(val: any) {
    return this.http.put(this.Url + '/QuanHuyen/' + val.MaQuanHuyen,val);
  }
  getQuanHuyenById(id:any){
    return this.http.get(this.Url +'/QuanHuyen/GetQuanHuyen/'+id)
  }
  getQuanHuyenPhantrang(currentPage,PageSize){
    return this.http.get(this.Url + '/QuanHuyen/phantrang?currentPage=' + currentPage + '&PageSize=' + PageSize);
  }
}
