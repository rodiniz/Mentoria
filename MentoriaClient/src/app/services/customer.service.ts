import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Customer } from '../model/customer.model';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  httpClient=inject(HttpClient);
  baseURL='https://localhost:7188/api/';

  list(): Observable<Customer[]> {
    const url = this.baseURL +'Customer';
    return this.httpClient.get<Customer[]>(url);
  }
  get(id:number): Observable<Customer[]> {
    const url = this.baseURL +`Customer/${id}`;
    return this.httpClient.get<Customer[]>(url);
  }
  update(model: Customer): Observable<Customer> {
    const url = this.baseURL  +`Customer/${model.id}`;
    return this.httpClient.put<Customer>(url, model);
  }

  create(model: Customer):  Observable<Customer> {
    const url = this.baseURL +'Customer';
    return this.httpClient.post<any>(url,model);
  }

  delete(id: number): Observable<void> {
    const url = this.baseURL +`Customer/${id}`;
    return this.httpClient.delete<void>(url);
  }
}
