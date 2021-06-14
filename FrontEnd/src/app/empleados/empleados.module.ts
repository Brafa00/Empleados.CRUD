import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EmpleadosRoutingModule } from './empleados-routing.module';
import { CrearEmpleadoComponent } from './components/crear-empleado/crear-empleado.component';
import { MaterialModule } from '../material/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ListarEmpleadosComponent } from './components/listar-empleados/listar-empleados.component';
import { EditarEmpleadoComponent } from './components/editar-empleado/editar-empleado.component';


@NgModule({
  declarations: [
    CrearEmpleadoComponent,
    ListarEmpleadosComponent,
    EditarEmpleadoComponent
  ],
  imports: [
    CommonModule,
    EmpleadosRoutingModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class EmpleadosModule { }
