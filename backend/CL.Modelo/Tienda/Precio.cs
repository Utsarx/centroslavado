using System;
using System.Collections.Generic;
using System.Text;

namespace CL.Modelo
{
    public class Precio
    {
        public Guid Id { get; set; }
        public string Descripcion { get; set; }
        public double Monto { get; set; }
        public Moneda Moneda { get; set; }
        public Guid ServicioId { get; set; }
        public Servicio Servicio { get; set; }
        public ICollection<ServiciosCentroLavado> CentrosLavado { get; set; }
    }
}
