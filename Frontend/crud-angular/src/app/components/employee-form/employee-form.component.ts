import { Component, inject } from '@angular/core';
import { FormBuilder, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { HttpService } from '../../Service/http.service';
import { IEmployee } from '../../interfaces/employee';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-employee-form',
  standalone: true,
  imports: [MatInputModule, MatButtonModule, ReactiveFormsModule, FormsModule],
  templateUrl: './employee-form.component.html',
  styleUrl: './employee-form.component.css'
})
export class EmployeeFormComponent {

  formBuilder = inject(FormBuilder);
  HttpService = inject(HttpService)
  router = inject(Router)
  route = inject(ActivatedRoute)

  employeeForm = this.formBuilder.group({
    name: ['', [Validators.required]],
    email: ['', [Validators.required, Validators.email]],
    phone: ['', []],
    age: [0, [Validators.required]],
    salary: [0, [Validators.required]],
  })

  employeeId!: number;
  isEdit: boolean = false;
  ngOnInit() {
    this.employeeId = this.route.snapshot.params['id'];
    if (this.employeeId) {
      this.isEdit = true;

      this.HttpService.getEmployeeById(this.employeeId).subscribe(res => {
        this.employeeForm.patchValue(res);
        // this.employeeForm.get('email')?.disable();
        console.log(this.employeeForm.value);
      })
    }
  }



  save() {


    const employee: any = this.employeeForm.value

    console.log(employee);

    if (this.isEdit == true) {
      this.HttpService.updateEmployee(this.employeeId, employee).subscribe(() => {
        this.router.navigateByUrl('/employee-list')
      })
    } else {
      this.HttpService.createEmployee(employee).subscribe(() => {
        this.router.navigateByUrl('/employee-list')
      })
    }
  }

}
