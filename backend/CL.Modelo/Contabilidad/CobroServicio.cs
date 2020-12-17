using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CL.Modelo.Contabilidad
{
    public class CobroServicio
    {
        /// <summary>
        /// Esta llave primaria es de tipo entero y por default es un autoincrementable
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Fecha de la operación
        /// </summary>
        [Required]
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Identificador del centro de lavado donde se realizó el cobro
        /// </summary>
        [Required]
        public Guid CentroLavadoId { get; set; }

        /// <summary>
        /// Identificador de la empresa receptora del cobro
        /// </summary>
        [Required]
        public Guid EmpresaTransporteId { get; set; }

        /// <summary>
        /// Identificador del medio de pago
        /// </summary>
        [MaxLength(10), MinLength(1)]
        [Required]
        public string MedioPagoId { get; set; }

        /// <summary>
        /// Monto pagado
        /// </summary>
        [Required]
        public decimal Monto { get; set; }

        /// <summary>
        /// Moneda del cobro
        /// </summary>
        public Moneda Moneda { get; set; }

        /// <summary>
        /// Identificador del servicio por el cual se cobra
        /// </summary>
        public Guid ServicioId { get; set; }

        /// <summary>
        /// Identificador del chofer que recibe el servicio
        /// </summary>
        public Guid ChoferId { get; set; }

        /// <summary>
        /// Identificador del tractor al cual se aplico el servicio
        /// Estos campos aceptan NULOS por eso el símbolo ?
        /// </summary>
        public Guid? TractorId  { get; set; }

        /// <summary>
        /// Identificador de la caja a la que se le aplica el servicio
        /// Estos campos aceptan NULOS por eso el símbolo ?
        /// </summary>
        public Guid? CajaId { get; set; }

    }
}
