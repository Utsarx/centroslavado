using System;
using System.Collections.Generic;
using System.Text;

namespace CL.Modelo
{
    /// <summary>
    /// Entidad de empresa de trasnporte
    /// </summary>
    public class EmpresaTransporte
    {

        public Guid Id { get; set; }

        public string Nombre { get; set; }

        public ICollection<Chofer> Choferes { get; set; }

        public ICollection<Tractor> Tractores { get; set; }
    }
}
