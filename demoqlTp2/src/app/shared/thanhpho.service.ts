import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ThanhphoService {
  readonly Url = "http://localhost:62636/api"
  constructor(private http: HttpClient) { }
  getThanhPhoList(currentPage, PageSize) {
    return this.http.get<any>(this.Url + '/ThanhPho?currentPage=' + currentPage + '&PageSize=' + PageSize);
  }
  postThanhPho(val: any) {

    return this.http.post(this.Url + '/ThanhPho', val)
  }
  putThanhPho(val: any) {

    return this.http.put(this.Url + '/ThanhPho/' + val.maTp, val)
  }
  deleteThanhPho(id: any) {
    return this.http.delete(this.Url + '/ThanhPho/' + id)
  }
  getMaThanhPho() {
    return this.http.get(this.Url + '/ThanhPho/listId');
  }
  getAll3Table(): Observable<any> {
    return this.http.get<any>(this.Url + '/values');
  }
  getAllThanhPho(): Observable<any> {
    return this.http.get<any>(this.Url + '/ThanhPho/getAll');
  }
}
