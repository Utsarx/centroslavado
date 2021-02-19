using CL.Modelo;
using CL.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CL.API.Servicios
{
    public class ServicioConfiguracionPuntoVenta
    {
        private readonly ContextoAplicacion db;
        public ServicioConfiguracionPuntoVenta(ContextoAplicacion db)
        {
            this.db = db;
        }

        public List<ConfiguracionVentaeCentroLavado> MisCentros(Guid id)
        {
            List<ConfiguracionVentaeCentroLavado> l = new List<ConfiguracionVentaeCentroLavado>();

            foreach(var ec in  db.EmpleadosCentroLavado.Where(
                e => e.EmpleadoId == id).ToList())
            {
                var centro = db.CentrosLavado.Find(ec.CentroLavadoId);
                ConfiguracionVentaeCentroLavado cfg = new ConfiguracionVentaeCentroLavado();
                cfg.Centro = new CentroLavado()
                {
                    Nombre = centro.Nombre,
                    Id = centro.Id,
                    Emmpleados = null,
                    Servicios = null
                };

                
                // PRocesamos todo lo demas de ConfiguracionVentaeCentroLavado

                // ...

                // Y al final añadimos la confiiugracio a la lista

                l.Add(cfg);
            }

            return l;
        }

    }
}
