using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        /// <summary>
        /// Lista de empleados que pertenecen a un centro de lavado
        /// </summary>
        public ICollection<EmpleadoCentroLavado> Emmpleados { get; set; }

        public ICollection<ServiciosCentroLavado> Servicios { get; set; }
        
    }
}
