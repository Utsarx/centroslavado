using System;
using System.Collections.Generic;
using System.Text;

namespace CL.Modelo
{
    public class ServiciosCentroLavado
    {
        public Guid CentroLavadoId { get; set; }
        public Guid ServicioId { get; set; }
        public Guid PrecioId { get; set; }
        public CentroLavado CentroLavado { get; set; }
        public Servicio Servicio { get; set; }
        public Precio PrecioDefault { get; set; }
    }
}
