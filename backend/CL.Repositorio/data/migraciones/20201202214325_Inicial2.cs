using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CL.Repositorio.data.migraciones
{
    public partial class Inicial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CentroLavado",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentroLavado", x => x.ID);
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
                    ID = table.Column<Guid>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 200, nullable: true),
                    CentroLavadoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Empleado_CentroLavado_CentroLavadoId",
                        column: x => x.CentroLavadoId,
                        principalTable: "CentroLavado",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Servicio",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Clave = table.Column<string>(maxLength: 200, nullable: true),
                    Nombre = table.Column<string>(maxLength: 200, nullable: true),
                    Precio = table.Column<double>(maxLength: 200, nullable: false),
                    CentroLavadoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicio", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Servicio_CentroLavado_CentroLavadoId",
                        column: x => x.CentroLavadoId,
                        principalTable: "CentroLavado",
                        principalColumn: "ID",
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
                    ID = table.Column<Guid>(nullable: false),
                    Noeconomico = table.Column<string>(maxLength: 100, nullable: true),
                    EmpresaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tractor", x => x.ID);
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
                name: "IX_Servicio_CentroLavadoId",
                table: "Servicio",
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
                name: "Servicio");

            migrationBuilder.DropTable(
                name: "Tractor");

            migrationBuilder.DropTable(
                name: "CentroLavado");

            migrationBuilder.DropTable(
                name: "Empresa");
        }
    }
}
