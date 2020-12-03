using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CL.Modelo
{
    [Table("Tractor")]
    public class Tractor
    {
        [Key]
        public Guid ID { get; set; }

        /// <summary>
        /// Este es el número económico o placas del tractor 
        /// </summary>
       
        [MaxLength(100), MinLength(1)]
        public string Noeconomico { get; set; }

       public Guid EmpresaId { get; set; }


        public EmpresaTransporte Empresa { get; set; }
    }
}
