using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

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

        public double Monto { get; set; }

        [Required]
        [DefaultValue(Moneda.PesoMexicano)]
        public Moneda Moneda { get; set; }

        /// <summary>
        /// Determina si el precio es el aplicable por default
        /// </summary>
        [Required]
        [DefaultValue(false)]
        public bool EsDefault { get; set; }
        
        public Guid ServicioId { get; set; }

        [JsonIgnore]
        public Servicio Servicio { get; set; }

        [JsonIgnore]
        public ICollection<ServiciosCentroLavado> PrecioCentroLavado { get; set; }
    }
}
