using System;
using System.Collections.Generic;
using System.Text;

namespace CL.Modelo
{
    public class ConfiguracionVentaeCentroLavado
    {
        public CentroLavado Centro { get; set; }
        public List<Empleado> Empleados { get; set; }
        public List<Categoria> Categorias { get; set; }
        public ICollection<ServiciosCentroLavado> Precios { get; set; }
    }
}
