import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class XaphuongService {
  readonly Url = "http://localhost:62636/api"
  constructor(private http: HttpClient) { }
  getXaPhuongList(): Observable<any> {
    return this.http.get<any>(this.Url + '/XaPhuong');
  }
  postXaPhuong(val: any) {
    return this.http.post(this.Url + '/XaPhuong', val);
  }
  deleteXaPhuong(id:any){
    return this.http.delete(this.Url+'/XaPhuong/'+id)
  }
  putXaPhuong(val: any) {
    return this.http.put(this.Url + '/XaPhuong/' + val.MaXaPhuong, val);
  }
  getXaphuongById(id:any){
    return this.http.get(this.Url+'/XaPhuong/GetXaPhuong/'+id)
  }
  getXaPhuongphantrang(currentPage,PageSize){
    return this.http.get(this.Url + '/XaPhuong/phantrang?currentPage=' + currentPage + '&PageSize=' + PageSize);
  }
}
