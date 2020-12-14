using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CL.Modelo
{
    public class MedioPagoEmpresa
    {
        [Key]
        public string MedioPagoId  { get; set; }
        [Key]
        public Guid EmpresaId { get; set; }

        public EmpresaTransporte Empresa { get; set; }
        public MedioPago MedioPago { get; set; }

    }
}
