using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CL.Repositorio.data.migraciones
{
    public partial class CentroLavado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_EmpleadosCentroLavado_EmpleadoId",
                table: "EmpleadosCentroLavado",
                column: "EmpleadoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpleadosCentroLavado");

            migrationBuilder.DropTable(
                name: "CentroLavado");

            migrationBuilder.DropTable(
                name: "Empleado");
        }
    }
}
