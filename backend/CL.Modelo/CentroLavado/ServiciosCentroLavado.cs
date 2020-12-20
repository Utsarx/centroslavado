using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CL.Modelo
{
    [Table("ServiciosCentroLavado")]
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
