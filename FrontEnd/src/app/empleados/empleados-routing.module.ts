import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CrearEmpleadoComponent } from './components/crear-empleado/crear-empleado.component';
import { ListarEmpleadosComponent } from './components/listar-empleados/listar-empleados.component';

const routes: Routes = [
  {
    path:'crear-empleado',
    component: CrearEmpleadoComponent 
  },
  {
    path:'',
    component: ListarEmpleadosComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EmpleadosRoutingModule { }
