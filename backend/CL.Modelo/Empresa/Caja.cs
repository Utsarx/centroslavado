using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CL.Modelo
     
{
    [Table("Caja")]
    public class Caja
    {
        [Key]
        public  Guid Id { get; set; }

        [MaxLength(100), MinLength(1)]
        public string NoEconomico { get; set; }

        public Guid EmpresaId { get; set; }

        public EmpresaTransporte Empresa { get; set; }
    }
}
