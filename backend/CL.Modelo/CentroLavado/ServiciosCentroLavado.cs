using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CL.Modelo
{
    public class ServiciosCentroLavado
    {
        [Key]
        [Column(Order = 1)]
        public Guid CentroLavadoId { get; set; }
        
        [Key]
        [Column(Order = 3)]
        public Guid ServicioId { get; set; }
        
        [Key]
        [Column(Order = 2)]
        public Guid PrecioId { get; set; }

        public CentroLavado CentroLavado { get; set; }
        public Servicio Servicio { get; set; }
        public Precio PrecioDefault { get; set; }
    }
}
