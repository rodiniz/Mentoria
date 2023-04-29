import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Customer } from '../model/customer.model';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import { IEntity } from '../model/ientity';
@Injectable({
  providedIn: 'root'
})
export abstract class BaseCrudService<T extends IEntity> {
  controllerName='';
  httpClient=inject(HttpClient);
  url = '';


  constructor(_controllerName: string) {
    this.controllerName= _controllerName;
    this.url = environment.baseUrl +this.controllerName;
  }

  list(): Observable<T[]> {
    return this.httpClient.get<T[]>(this.url);
  }
  get(id:number): Observable<T[]> {

    return this.httpClient.get<T[]>(`${this.url}/${id}`);
  }
  update(model: T): Observable<T> {
    return this.httpClient.put<T>(`${this.url}/${model.id}`, model);
  }

  create(model: Customer):  Observable<Customer> {
    return this.httpClient.post<any>(this.url,model);
  }

  delete(id: number): Observable<void> {
    return this.httpClient.delete<void>(`${this.url}/${id}`);
  }
}
