using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [Required]
        public string Descripcion { get; set; }

        [MaxLength(200), MinLength(5)]
        public double Monto { get; set; }

        [Required]
        [DefaultValue(Moneda.PesoMexicano)]
        public Moneda Moneda { get; set; }

        /// <summary>
        /// Determina si el precio es el aplicable por default
        /// </summary>
        [Required]
        [DefaultValue(true)]
        public bool EsDefault { get; set; }
        
        public Guid ServicioId { get; set; }
        public Servicio Servicio { get; set; }
        
        public ICollection<ServiciosCentroLavado> PrecioCentroLavado { get; set; }
    }
}
