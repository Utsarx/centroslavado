import { Empleado } from "./empleado";

export interface CentroLavado {
    id: string,
    nombre: string,
    empleados?: Empleado[],
   
}