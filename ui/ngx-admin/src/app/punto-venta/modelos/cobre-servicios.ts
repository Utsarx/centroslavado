export interface CobroServicio {
    Id: string,
    CentroLavadoId : string,
    EmpresaTransporteId: string,
    MedioPago: number,
    Monto: number,
    Moneda: number,
    PrecioId: string,
    CategoriaId: string,
    ServicioId: string,
    ChoferId?: string,
    TractorId?: string,
    CajaId?: string
}

export interface ElementoCobro {
    CentroLavadoId : string,
    CategoriaId: string,
    ServicioId: string,
    PrecioId: string,
    Monto: number,
}