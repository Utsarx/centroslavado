using System;
using System.Collections.Generic;
using System.Text;

namespace CL.Modelo
{
    /// <summary>
    /// Define que empleados se encuentran asociados aun centro de lavado
    /// </summary>
    public class EmpleadoCentroLavado
    {
        public Guid EmpleadoId { get; set; }
        public Guid CentroLavadoId { get; set; }
        public Empleado Empleado { get; set; }
        public CentroLavado CentroLavado { get; set; }
    }
}
