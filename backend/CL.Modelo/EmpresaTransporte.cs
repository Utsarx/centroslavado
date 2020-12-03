using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CL.Modelo
{
    /// <summary>
    /// Entidad de empresa de trasnporte
    /// </summary>
    [Table("Empresa")]
    public class EmpresaTransporte
    {

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(250), MinLength(5)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(14), MinLength(12)]
        public string RFC { get; set; }

        public ICollection<Chofer> Choferes { get; set; }

        public ICollection<Tractor> Tractores { get; set; }
    }
}
