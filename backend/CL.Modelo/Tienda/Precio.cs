using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CL.Modelo
{
    [Table("Precio")]
    public class Precio
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(200), MinLength(5)]
        public string Descripcion { get; set; }

        [MaxLength(200), MinLength(5)]
        public double Monto { get; set; }

        [MaxLength(50), MinLength(3)]
        public Moneda Moneda { get; set; }
        
        public Guid ServicioId { get; set; }
        public Servicio Servicio { get; set; }
        public ICollection<ServiciosCentroLavado> CentrosLavado { get; set; }
    }
}
