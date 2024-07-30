import { Component, inject } from '@angular/core';
import { IEmployee } from '../../interfaces/employee';
import { HttpService } from '../../Service/http.service';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { Router, RouterLink } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-employee-list',
  standalone: true,
  imports: [MatTableModule, MatButtonModule, RouterLink],
  templateUrl: './employee-list.component.html',
  styleUrl: './employee-list.component.css'
})
export class EmployeeListComponent {

  employeeList: IEmployee[] = []

  router = inject(Router)
  HttpService = inject(HttpService)
  displayedColumns: string[] = ['id', 'name', 'email', 'age', 'phone', 'salary', 'action'];
  toaster = inject(ToastrService)



  ngOnInit() {
    this.HttpService.getAllEmployee().subscribe(res => {
      this.employeeList = res;
    })
  }


  edit(id: number) {
    this.router.navigateByUrl("/employee/" + id);
  }

  delete(id: number) {
    this.HttpService.deleteEmployee(id).subscribe((res: any) => {
      if (res.code == 0) {
        this.HttpService.getAllEmployee().subscribe(res => {
          this.employeeList = res;
          this.toaster.success('Delete !!')
        })
      }
    })
  }
}
