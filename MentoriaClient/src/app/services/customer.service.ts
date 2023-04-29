import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Customer } from '../model/customer.model';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import { BaseCrudService } from './baseCrudService';
@Injectable({
  providedIn: 'root'
})
export class CustomerService extends BaseCrudService<Customer> {

  constructor() {
    super('Customer');
  }

}
