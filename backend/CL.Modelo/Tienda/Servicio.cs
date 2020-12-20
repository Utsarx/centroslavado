using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CL.Modelo
{
    [Table("Servicio")]
   public class Servicio
    {
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Clave del servicio
        /// </summary>
        [MaxLength(200), MinLength(5)]
        public string Clave { get; set; }


        /// <summary>
        /// NOmbre del servicio
        /// </summary>
        [MaxLength(200), MinLength(5)]
        public string Nombre { get; set; }


        /// <summary>
        /// Precios asociados al servicio
        /// </summary>
        public ICollection<Precio> Precios { get; set; }
        
        /// <summary>
        /// Centros de lavados que utilizan el servicio
        /// </summary>
        public ICollection<ServiciosCentroLavado> CentrosLavado { get; set; }


        // Categoría 
        public Categoria Categorias { get; set;  }
    }
}
