export interface ConfiguracionVentaeCentroLavado {
    centro: CentroLavado;
    empleados: Empleado[];
    categorias: Categoria[];
    precios: ServiciosCentroLavado[];
}


export interface CentroLavado {
    id: string;
    nombre: string;
}


export interface Empleado {
    id: string;
    nombre: string;
    activo: boolean;
}

export interface Categoria {
    id: string;
    nombre: string;
    servicios: Servicio[]
}

export interface ServiciosCentroLavado {
    centroLavadoId: string;
    servicioId: string;
    precioId: string;
}


export interface Servicio {
    id: string;
    clave: string;
    categoriaId: string;
    precios: Precio[];
}


export interface Precio {
    id: string;
    descripcion: string;
    monto: number;
    esDefault: boolean;
    servicioId: string;
    moneda: number;
    categoriaId?: string;
}