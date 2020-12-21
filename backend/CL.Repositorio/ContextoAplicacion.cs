using CL.Modelo;
using CL.Modelo.Contabilidad;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedioPagoEmpresa>()
                   .HasKey(m => new { m.EmpresaId, m.MedioPago });

            modelBuilder.Entity<EmpleadoCentroLavado>()
                .HasKey(ecl => new { ecl.CentroLavadoId, ecl.EmpleadoId });


            modelBuilder.Entity<ServiciosCentroLavado>()
            .HasKey(serv => new { serv.CentroLavadoId, serv.ServicioId, serv.PrecioId });


        }


        #region Contabilidad

        public DbSet<AbonoPrepago> AbonosPrepago { get; set; }

        public DbSet<CobroServicio> CobroServicios { get; set; }
        #endregion

        #region CentrosLavado

        public DbSet<CentroLavado> CentrosLavado { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<EmpleadoCentroLavado> EmpleadosCentroLavado { get; set; }
        public DbSet<ServiciosCentroLavado> ServiciosCentroLavados { get; set; }

        #endregion

        #region EmpresasTrasnporte
        public DbSet<EmpresaTransporte> Empresas { get; set; }

        public DbSet<Chofer> Choferes { get; set; }

        public DbSet<Tractor> Tractores { get; set; }

        public DbSet<Caja> Cajas { get; set; }

        public DbSet<MedioPagoEmpresa> MedioPagoEmpresas { get; set; }
        #endregion


        #region Tienda 

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Servicio> Servicios { get; set; }

        public DbSet<Precio> Precios { get; set; }




        #endregion
    }
}
