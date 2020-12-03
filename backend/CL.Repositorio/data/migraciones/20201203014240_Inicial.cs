using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CL.Repositorio.data.migraciones
{
    public partial class Inicial : Migration
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
                name: "Empresa",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 250, nullable: false),
                    RFC = table.Column<string>(maxLength: 14, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 200, nullable: true),
                    CentroLavadoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empleado_CentroLavado_CentroLavadoId",
                        column: x => x.CentroLavadoId,
                        principalTable: "CentroLavado",
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

            migrationBuilder.CreateIndex(
                name: "IX_Chofer_EmpresaId",
                table: "Chofer",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_CentroLavadoId",
                table: "Empleado",
                column: "CentroLavadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tractor_EmpresaId",
                table: "Tractor",
                column: "EmpresaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chofer");

            migrationBuilder.DropTable(
                name: "Empleado");

            migrationBuilder.DropTable(
                name: "Tractor");

            migrationBuilder.DropTable(
                name: "CentroLavado");

            migrationBuilder.DropTable(
                name: "Empresa");
        }
    }
}
