using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CL.Modelo
{
    [Table("Empleado")]
   public class Empleado
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(200), MinLength(5)]
        public string Nombre { get; set; }


        public Guid CentroLavadoId { get; set; }


        public CentroLavado CentroLavado { get; set; }
    }
}
