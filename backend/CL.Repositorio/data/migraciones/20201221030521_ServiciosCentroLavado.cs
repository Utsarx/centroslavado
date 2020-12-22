using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CL.Repositorio.data.migraciones
{
    public partial class ServiciosCentroLavado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "IX_ServiciosCentroLavado_PrecioId",
                table: "ServiciosCentroLavado",
                column: "PrecioId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiciosCentroLavado_ServicioId",
                table: "ServiciosCentroLavado",
                column: "ServicioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiciosCentroLavado");
        }
    }
}
