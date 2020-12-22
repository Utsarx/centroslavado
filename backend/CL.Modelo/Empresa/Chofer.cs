using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CL.Modelo
{
    [Table("Chofer")]
    public class Chofer
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(250), MinLength(5)]
        public string Nombre { get; set; }

        public Guid EmpresaId { get; set; }


        public EmpresaTransporte Empresa { get; set; }
    }
}
