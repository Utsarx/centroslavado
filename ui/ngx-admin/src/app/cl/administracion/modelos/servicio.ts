import { Precio } from "./precio";

export interface Servicio {
    id: string,
    nombre: string,
    clave: string, 
    precios?: Precio[],
    categoriaId: string,
}