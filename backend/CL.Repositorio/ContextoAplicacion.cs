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

        #region CentrosLavado

        public DbSet<CentroLavado> CentrosLavado { get; set; }
        public DbSet<Empleado> Empleados { get; set; }

        #endregion

        #region EmpresasTrasnporte
        public DbSet<EmpresaTransporte> Empresas { get; set; }

        public DbSet<Chofer> Choferes { get; set; }

        public DbSet<Tractor> Tractores { get; set; }

        #endregion



        // DbSet<Servicio> Servicios { get; set; }


    }
}
