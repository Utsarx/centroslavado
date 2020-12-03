using CL.Modelo;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CL.Repositorio
{
    public class ContextoAplicacion : DbContext
    {
        public ContextoAplicacion(DbContextOptions<ContextoAplicacion> options)
            : base(options)
        {
        }

        DbSet<EmpresaTransporte> Empresas { get; set; }
        
        DbSet<Chofer> Choferes { get; set; }

        DbSet<Tractor> Tractores { get; set;  }

        DbSet<CentroLavado> CentrosLavado { get; set;  }

        DbSet<Servicio> Servicios { get; set; }

        DbSet<Empleado> Empleados { get; set;  }
    }
}
