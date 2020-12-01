using System;
using System.Collections.Generic;
using System.Text;

namespace CL.Modelo
{
    public class CentroLavado
    {
        public Guid ID { get; set; }

        public string Nombre { get; set; }

        public ICollection<Empleado>Empleados{ get; set; }

        public ICollection<Servicio> Servicios { get; set;  }
    }
}
