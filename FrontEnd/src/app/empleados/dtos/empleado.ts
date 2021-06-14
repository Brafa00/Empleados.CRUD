import { Cargo } from "./cargo";

export interface Empleado {
    id: number;
    nombre: string;
    apellido: string;
    documento: string;
    idCargo: number;
    cargo: Cargo
  }
