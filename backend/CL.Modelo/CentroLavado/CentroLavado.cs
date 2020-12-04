using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CL.Modelo
{
    [Table("CentroLavado")]
    public class CentroLavado
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(200), MinLength(5)]
        public string Nombre { get; set; }

       // public ICollection<Empleado>Empleados{ get; set; }

       // public ICollection<Servicio> Servicios { get; set;  }
    }
}
