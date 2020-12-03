using System;
using System.Collections.Generic;
using System.Text;

namespace CL.Modelo
{
    public class Categoria
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public ICollection<Servicio> Servicios { get; set; }
    }
}
