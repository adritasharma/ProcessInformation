import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http"
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(public _http: HttpClient) { }

  get(url: string): Observable<any> {
    return this._http.get(url)
  }

  post(url: string, resource): Observable<any> {
    return this._http.post(url, resource)
  }

  fetch(url: string, resource) {
    return this._http.post(url, resource)
  }

  update(url: string, resource) {
    return this._http.put(url, resource)
  }

  delete(url: string) {
    return this._http.delete(url)
  }

  getFile(url: string): Observable<any> {
    return this._http.get(url, { responseType: 'blob' })
  }

}
