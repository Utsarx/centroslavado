import { Caja } from './caja';
import { Chofer } from './chofer';
import { Tractor } from './tractor';
export interface EmpresaTransporte {
    id: string,
    nombre: string,
    rfc: string,
    saldoPrepago: number
    tractores?: Tractor[],
    choferes?: Chofer[],
    cajas?: Caja[]
}