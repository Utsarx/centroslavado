using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CL.Modelo
{
    [Table ("Categoria")]
    public class Categoria
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100), MinLength(3)]
        public string Nombre { get; set; }
        public ICollection<Servicio> Servicios { get; set; }
    }
}
