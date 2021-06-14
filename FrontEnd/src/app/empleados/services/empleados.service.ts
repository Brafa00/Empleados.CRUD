import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Empleado } from '../dtos/empleado';

@Injectable({
  providedIn: 'root'
})
export class EmpleadosService {
  empleadosServicios = environment.empleadosServicios;

  constructor(private httpClient: HttpClient) { }

  registrarEmpleado(empleado: any): Observable<any> {
    return this.httpClient.post(`${this.empleadosServicios}/api/Empleado/AddEmpleado`, empleado);
  }

  listarEmpleados(): Observable<Array<Empleado>>{
    return this.httpClient.get<Array<Empleado>>(`${this.empleadosServicios}/api/Empleado/GetAllEmpleados`);
  }

  editarEmpleado(empleado: any): Observable<any> {
    return this.httpClient.put(`${this.empleadosServicios}/api/Empleado/UpdateEmpleado`, empleado);
  }

  eliminarEmpleado(idEmpleado: number): Observable<any>{
    return this.httpClient.delete(`${this.empleadosServicios}/api/Empleado/DeleteEmpleado/${idEmpleado}`)
  }
}
