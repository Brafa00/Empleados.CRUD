import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { Empleado } from '../../dtos/empleado';
import { EmpleadosService } from '../../services/empleados.service';
import { CrearEmpleadoComponent } from '../crear-empleado/crear-empleado.component';
import { EditarEmpleadoComponent } from '../editar-empleado/editar-empleado.component';

@Component({
  selector: 'app-listar-empleados',
  templateUrl: './listar-empleados.component.html',
  styleUrls: ['./listar-empleados.component.css']
})
export class ListarEmpleadosComponent implements OnInit {
  dataSource: Array<Empleado> = [];
  displayedColumns: string[] = ['id', 'nombre', 'apellido', 'documento', 'cargo', 'acciones'];
  
  constructor(
    private empleadoService: EmpleadosService,
    private dialog: MatDialog) { }

  ngOnInit(): void {
    this.consultarEmpleados();
  }

  consultarEmpleados(){
    this.empleadoService.listarEmpleados().subscribe({
      next: (result: Array<Empleado>) => {
        this.dataSource = result;
      },
      error: (error) => {
        console.error(`Ha ocurrido un error consultando los empleados ${JSON.stringify(error)}`);
      }  
    });
  }

  eliminarEmpleado(idEmpleado: number) {
    this.empleadoService.eliminarEmpleado(idEmpleado).subscribe({
      next:() => {
        this.consultarEmpleados();
        console.log(`El Empleado con Id ${idEmpleado} fue elminado`);
      },
      error: (error) => {
        console.error(`Ha ocurrido un error eliminando el empleado ${idEmpleado}: ${JSON.stringify(error)}`);
      }
    });
  }

  abrirModalCrearEmpleado(){
    const dialogRef = this.dialog.open(CrearEmpleadoComponent);
    dialogRef.afterClosed().subscribe(() => {
      this.consultarEmpleados();
    })
  }

  abrirModalEditarEmpleado(empleado: Empleado){
    const dialog = this.dialog.open(EditarEmpleadoComponent, {
      data: empleado
    });

    dialog.afterClosed().subscribe(() => {
      this.consultarEmpleados();
    })
  }
}
