using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CL.Repositorio.data.migraciones
{
    public partial class CoboroServicis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbonoPrepago_EmpresaId",
                table: "AbonoPrepago",
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbonoPrepago");

            migrationBuilder.DropTable(
                name: "CobroServicio");

            migrationBuilder.DropTable(
                name: "MedioPagoEmpresa");
        }
    }
}
