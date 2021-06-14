import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Cargo } from '../dtos/cargo';

@Injectable({
  providedIn: 'root'
})
export class CargoService {
  empleadosServicios = environment.empleadosServicios;

  constructor(private httpClient: HttpClient) { }

  GetAllCargos(): Observable<Array<Cargo>>{
    return this.httpClient.get<Array<Cargo>>(`${this.empleadosServicios}/api/Cargo/GetAllCargos`);
  }
}
