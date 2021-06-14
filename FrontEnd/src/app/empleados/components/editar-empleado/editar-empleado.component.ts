import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Cargo } from '../../dtos/cargo';
import { Empleado } from '../../dtos/empleado';
import { CargoService } from '../../services/cargo.service';
import { EmpleadosService } from '../../services/empleados.service';

@Component({
  selector: 'app-editar-empleado',
  templateUrl: './editar-empleado.component.html',
  styleUrls: ['./editar-empleado.component.css']
})
export class EditarEmpleadoComponent implements OnInit {
  empleadosFormGroup: FormGroup;
  cargos: Array<Cargo> = [];

  constructor(
    private dialogRef: MatDialogRef<EditarEmpleadoComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Empleado,
    private formBuilder: FormBuilder,
    private empleadoService: EmpleadosService,
    private cargoService: CargoService) {
    this.empleadosFormGroup = this.formBuilder.group({
        id:[this.data?.id, Validators.required],
        nombre: [this.data?.nombre, [Validators.required]],
        apellido: [this.data?.apellido, [Validators.required]],
        documento: [this.data?.documento, [Validators.required]],
        idCargo: [this.data?.idCargo, [Validators.required]]
      });

      console.log(this.empleadosFormGroup.value);
      console.log(data);
   }

  ngOnInit(): void {
    this.consultarCargos();
  }

  private consultarCargos() {
    this.cargoService.GetAllCargos().subscribe({
      next:(result) => {
        this.cargos = result;
      },
      error:(error) => {
        console.error(`Ha ocurrido un error consultando los cargos ${JSON.stringify(error)}`);
      }
    })
  }

  editarEmpleado(){
    if(this.empleadosFormGroup.invalid){
      return;
    }

    let idcargo = this.empleadosFormGroup.get('idCargo')?.value;
    this.empleadosFormGroup.get('idCargo')?.setValue(parseInt(idcargo));
    this.empleadosFormGroup.get('idCargo')?.updateValueAndValidity();

    this.empleadoService.editarEmpleado(this.empleadosFormGroup.value).subscribe({
      next:() => {
        console.log(`Empleado actualizado con exito`);
        this.dialogRef.close();
      },
      error: (error) => {
        console.error(`ocurrio un error tratando de actualizar el usuario: ${JSON.stringify(error)}`);
      }
    })
  }

  cerrarModal(){
    this.dialogRef.close();
  }

}
