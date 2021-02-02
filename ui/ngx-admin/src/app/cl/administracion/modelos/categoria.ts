import { Servicio } from "./servicio";

export interface Categoria {
    id: string,
    nombre: string,
    servicios?: Servicio[],
}