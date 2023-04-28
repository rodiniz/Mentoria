import { Observable } from 'rxjs';
import { CustomerService } from './services/customer.service';
import { Component, OnInit, inject } from '@angular/core';
import { Customer } from './model/customer.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  customerService= inject(CustomerService);
  customers$!:Observable<Customer[]>;
  ngOnInit(): void {
    this.customers$= this.customerService.list();
  }
}
