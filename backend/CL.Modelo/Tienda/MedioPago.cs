using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CL.Modelo
{
    [Table("MedioPago")]
    public class MedioPago
    {
        // Este Id es de tipo string 
        [Required]
        [MaxLength(10), MinLength(1)]
        public string Id { get; set; }

        [Required]
        [MaxLength(250), MinLength(1)]
        public string Nombre { get; set; }

        public ICollection<MedioPagoEmpresa> MediosEmpresa { get; set; }
    }
}
