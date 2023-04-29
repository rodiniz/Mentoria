import { Component, OnInit, inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Customer } from '../model/customer.model';
import { CustomerService } from '../services/customer.service';

@Component({
  selector: 'app-edit-customer',
  templateUrl: './edit-customer.component.html',
  styleUrls: ['./edit-customer.component.css']
})
export class EditCustomerComponent implements OnInit {
  form!: FormGroup;
  formBuilder= inject(FormBuilder);
  customerEdited!: Customer;
  customerService= inject(CustomerService);
  ngOnInit(): void {
    this.form = this.formBuilder.nonNullable.group({
      id:[this.customerEdited?.id],
      firstName: [this.customerEdited?.firstName, [Validators.maxLength(50), Validators.required]],
      surName: [this.customerEdited?.surName, [Validators.maxLength(50), Validators.required]],
      email: [this.customerEdited?.email, [Validators.maxLength(50), Validators.required, Validators.pattern('[A-Za-z0-9._%-]+@[A-Za-z0-9._%-]+\\.[a-z]{2,5}')]],
      password: [this.customerEdited?.password, [Validators.maxLength(50), Validators.required]]
    });
  }

  save():void{
    if(this.customerEdited.id !==null){
        this.customerService.update(this.customerEdited).subscribe(res=>
          console.log(1)
          );
    }
    else{
      this.customerService.create(this.customerEdited).subscribe(res=>
        console.log(1)
        );
    }
  }

}
