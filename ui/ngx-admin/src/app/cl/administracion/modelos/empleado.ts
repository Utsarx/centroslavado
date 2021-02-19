export interface Empleado {
    id: string,
    nombre: string,
    usuarioSistema: boolean, 
    nombreUsuario: string, 
    hash: string, 
    salt: string, 
   // Activo: boolean,
    centroLavadoId: string,
}