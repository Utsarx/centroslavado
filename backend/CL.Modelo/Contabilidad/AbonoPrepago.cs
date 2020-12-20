using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CL.Modelo
{
    /// <summary>
    /// Controla los abonos al prepago de una empresa de trasnporte
    /// </summary>
    
    [Table("AbonoPrepago")]
    public class AbonoPrepago
    {
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Identificador de la empresa para el prepago
        /// </summary>
        [Required]
        public Guid EmpesaId { get; set; }
        
        /// <summary>
        /// Fecha de creación del prepago
        /// </summary>
        [Required]
        public DateTime Fecha { get; set; }
        
        /// <summary>
        /// El monto debe ser mayor a 0 
        /// </summary>
        [Required]
        public decimal Monto { get; set; }

        [Required]
        [DefaultValue(Moneda.PesoMexicano)]
        public Moneda Moneda { get; set; }
        
        /// <summary>
        /// Empesa a la que se asocia el prepago
        /// </summary>
        public EmpresaTransporte Empresa { get; set; }
    }
}
