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
        
        DbSet<CentroLavado> CentrosLavado { get; set; }
        DbSet<Empleado> Empleados { get; set; }

        #endregion

        #region EmpresasTrasnporte
        DbSet<EmpresaTransporte> Empresas { get; set; }

        DbSet<Chofer> Choferes { get; set; }

        DbSet<Tractor> Tractores { get; set; }

        #endregion



        // DbSet<Servicio> Servicios { get; set; }


    }
}
