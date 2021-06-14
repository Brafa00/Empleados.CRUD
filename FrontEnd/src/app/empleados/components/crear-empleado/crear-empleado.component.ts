import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { Cargo } from '../../dtos/cargo';
import { CargoService } from '../../services/cargo.service';
import { EmpleadosService } from '../../services/empleados.service';

@Component({
  selector: 'app-crear-empleado',
  templateUrl: './crear-empleado.component.html',
  styleUrls: ['./crear-empleado.component.css']
})
export class CrearEmpleadoComponent implements OnInit {
  empleadosFormGroup: FormGroup;
  cargos : Array<Cargo> = [];

  constructor(
    private dialogRef: MatDialogRef<CrearEmpleadoComponent>,
    private formBuilder: FormBuilder,
    private empleadosServicio: EmpleadosService,
    private cargoService: CargoService) {
    this.empleadosFormGroup = this.formBuilder.group({
      nombre: [null, [Validators.required]],
      apellido: [null, [Validators.required]],
      documento: [null, [Validators.required]],
      idCargo: [null, [Validators.required]]
    })
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

  registrarEmpleado(){
    if(this.empleadosFormGroup.invalid){
      return;
    }

    let idcargo = this.empleadosFormGroup.get('idCargo')?.value;
    this.empleadosFormGroup.get('idCargo')?.setValue(parseInt(idcargo));
    this.empleadosFormGroup.get('idCargo')?.updateValueAndValidity();

    console.log(this.empleadosFormGroup.value);

    this.empleadosServicio.registrarEmpleado(this.empleadosFormGroup.value).subscribe({
      next: () => {
        console.log('Empleado Registrado');
        this.dialogRef.close();
      },
      error:(error) => {
        console.error(`Ha ocurrido un error registrando el empleado ${error}`);
      }
    });
  }

  cerrarModal(){
    this.dialogRef.close();
  }
}
