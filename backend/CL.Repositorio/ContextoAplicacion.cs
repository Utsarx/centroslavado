using CL.Modelo;
using CL.Modelo.Empresa;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CL.Repositorio
{
    public class ContextoAplicacion : DbContext
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedioPagoEmpresa>()
                .HasKey(mp => new { mp.EmpresaId, mp.MedioPagoId } );
        }

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

        public DbSet<Caja> Cajas { get; set; }

        public DbSet<MedioPagoEmpresa> medioPagoEmpresas { get; set; }
        #endregion


        #region Tienda 
        public DbSet<MedioPago> MedioPagos { get; set; }

        #endregion
    }
}
