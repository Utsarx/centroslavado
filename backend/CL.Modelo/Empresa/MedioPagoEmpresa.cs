using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CL.Modelo
{
    [Table("MedioPagoEmpresa")]
    public class MedioPagoEmpresa
    {

        public MedioPagoEmpresa()
        {
 
            
        }
        
        
        public Guid EmpresaId { get; set; }

        public string MedioPagoId { get; set; }
        public EmpresaTransporte Empresa { get; set; }
        public MedioPago MedioPago { get; set; }

    }
}
