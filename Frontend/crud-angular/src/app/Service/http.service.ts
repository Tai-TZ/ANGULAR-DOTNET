import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { IEmployee } from '../interfaces/employee';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  apiUrl = "https://localhost:7019/api/Employee"
  http = inject(HttpClient)

  constructor() { }


  getAllEmployee() {
    return this.http.get<IEmployee[]>(`${this.apiUrl}/GetListEmployeeList`)
  }

  getEmployeeById(id: number) {
    return this.http.get<IEmployee>(`${this.apiUrl}/${id}`)
  }


  createEmployee(employee: IEmployee) {
    return this.http.post(`${this.apiUrl}/AddEmployee`, employee);
  }


  updateEmployee(id: number, employee: IEmployee) {
    return this.http.put(`${this.apiUrl}/${id}`, employee)
  }

  deleteEmployee(id: number) {
    return this.http.delete(`${this.apiUrl}/${id}`)
  }

}
