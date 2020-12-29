using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CL.Repositorio.data.migraciones
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CentroLavado",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentroLavado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 200, nullable: true),
                    UsuarioSistema = table.Column<bool>(nullable: false),
                    NombreUsuario = table.Column<string>(maxLength: 100, nullable: true),
                    Hash = table.Column<string>(maxLength: 500, nullable: true),
                    Salt = table.Column<string>(maxLength: 50, nullable: true),
                    Activo = table.Column<bool>(nullable: false),
                    UltimoAcceso = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 250, nullable: false),
                    RFC = table.Column<string>(maxLength: 14, nullable: false),
                    SaldoPrepago = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servicio",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Clave = table.Column<string>(maxLength: 200, nullable: true),
                    CategoriaId = table.Column<Guid>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Servicio_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmpleadosCentroLavado",
                columns: table => new
                {
                    EmpleadoId = table.Column<Guid>(nullable: false),
                    CentroLavadoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpleadosCentroLavado", x => new { x.CentroLavadoId, x.EmpleadoId });
                    table.ForeignKey(
                        name: "FK_EmpleadosCentroLavado_CentroLavado_CentroLavadoId",
                        column: x => x.CentroLavadoId,
                        principalTable: "CentroLavado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmpleadosCentroLavado_Empleado_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AbonoPrepago",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EmpesaId = table.Column<Guid>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Monto = table.Column<decimal>(nullable: false),
                    Moneda = table.Column<int>(nullable: false),
                    EmpresaId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbonoPrepago", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbonoPrepago_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Caja",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NoEconomico = table.Column<string>(maxLength: 100, nullable: true),
                    EmpresaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caja", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Caja_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Chofer",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 250, nullable: true),
                    EmpresaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chofer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chofer_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MedioPagoEmpresa",
                columns: table => new
                {
                    EmpresaId = table.Column<Guid>(nullable: false),
                    MedioPago = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedioPagoEmpresa", x => new { x.EmpresaId, x.MedioPago });
                    table.ForeignKey(
                        name: "FK_MedioPagoEmpresa_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tractor",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Noeconomico = table.Column<string>(maxLength: 100, nullable: true),
                    EmpresaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tractor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tractor_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Precio",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descripcion = table.Column<string>(maxLength: 200, nullable: false),
                    Monto = table.Column<double>(maxLength: 200, nullable: false),
                    Moneda = table.Column<int>(nullable: false),
                    EsDefault = table.Column<bool>(nullable: false),
                    ServicioId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Precio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Precio_Servicio_ServicioId",
                        column: x => x.ServicioId,
                        principalTable: "Servicio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CobroServicio",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(nullable: false),
                    CentroLavadoId = table.Column<Guid>(nullable: false),
                    EmpresaTransporteId = table.Column<Guid>(nullable: false),
                    MedioPago = table.Column<int>(nullable: false),
                    Monto = table.Column<decimal>(nullable: false),
                    Moneda = table.Column<int>(nullable: false),
                    CategoriaId = table.Column<Guid>(nullable: false),
                    ServicioId = table.Column<Guid>(nullable: false),
                    ChoferId = table.Column<Guid>(nullable: true),
                    TractorId = table.Column<Guid>(nullable: true),
                    CajaId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CobroServicio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CobroServicio_Caja_CajaId",
                        column: x => x.CajaId,
                        principalTable: "Caja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CobroServicio_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CobroServicio_CentroLavado_CentroLavadoId",
                        column: x => x.CentroLavadoId,
                        principalTable: "CentroLavado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CobroServicio_Chofer_ChoferId",
                        column: x => x.ChoferId,
                        principalTable: "Chofer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CobroServicio_Empresa_EmpresaTransporteId",
                        column: x => x.EmpresaTransporteId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CobroServicio_Servicio_ServicioId",
                        column: x => x.ServicioId,
                        principalTable: "Servicio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CobroServicio_Tractor_TractorId",
                        column: x => x.TractorId,
                        principalTable: "Tractor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiciosCentroLavado",
                columns: table => new
                {
                    CentroLavadoId = table.Column<Guid>(nullable: false),
                    ServicioId = table.Column<Guid>(nullable: false),
                    PrecioId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiciosCentroLavado", x => new { x.CentroLavadoId, x.ServicioId, x.PrecioId });
                    table.ForeignKey(
                        name: "FK_ServiciosCentroLavado_CentroLavado_CentroLavadoId",
                        column: x => x.CentroLavadoId,
                        principalTable: "CentroLavado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiciosCentroLavado_Precio_PrecioId",
                        column: x => x.PrecioId,
                        principalTable: "Precio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiciosCentroLavado_Servicio_ServicioId",
                        column: x => x.ServicioId,
                        principalTable: "Servicio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbonoPrepago_EmpresaId",
                table: "AbonoPrepago",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Caja_EmpresaId",
                table: "Caja",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Chofer_EmpresaId",
                table: "Chofer",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_CobroServicio_CajaId",
                table: "CobroServicio",
                column: "CajaId");

            migrationBuilder.CreateIndex(
                name: "IX_CobroServicio_CategoriaId",
                table: "CobroServicio",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_CobroServicio_CentroLavadoId",
                table: "CobroServicio",
                column: "CentroLavadoId");

            migrationBuilder.CreateIndex(
                name: "IX_CobroServicio_ChoferId",
                table: "CobroServicio",
                column: "ChoferId");

            migrationBuilder.CreateIndex(
                name: "IX_CobroServicio_EmpresaTransporteId",
                table: "CobroServicio",
                column: "EmpresaTransporteId");

            migrationBuilder.CreateIndex(
                name: "IX_CobroServicio_ServicioId",
                table: "CobroServicio",
                column: "ServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_CobroServicio_TractorId",
                table: "CobroServicio",
                column: "TractorId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpleadosCentroLavado_EmpleadoId",
                table: "EmpleadosCentroLavado",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Precio_ServicioId",
                table: "Precio",
                column: "ServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicio_CategoriaId",
                table: "Servicio",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiciosCentroLavado_PrecioId",
                table: "ServiciosCentroLavado",
                column: "PrecioId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiciosCentroLavado_ServicioId",
                table: "ServiciosCentroLavado",
                column: "ServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_Tractor_EmpresaId",
                table: "Tractor",
                column: "EmpresaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbonoPrepago");

            migrationBuilder.DropTable(
                name: "CobroServicio");

            migrationBuilder.DropTable(
                name: "EmpleadosCentroLavado");

            migrationBuilder.DropTable(
                name: "MedioPagoEmpresa");

            migrationBuilder.DropTable(
                name: "ServiciosCentroLavado");

            migrationBuilder.DropTable(
                name: "Caja");

            migrationBuilder.DropTable(
                name: "Chofer");

            migrationBuilder.DropTable(
                name: "Tractor");

            migrationBuilder.DropTable(
                name: "Empleado");

            migrationBuilder.DropTable(
                name: "CentroLavado");

            migrationBuilder.DropTable(
                name: "Precio");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "Servicio");

            migrationBuilder.DropTable(
                name: "Categoria");
        }
    }
}
