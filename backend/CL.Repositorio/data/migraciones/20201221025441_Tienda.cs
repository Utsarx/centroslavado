using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CL.Repositorio.data.migraciones
{
    public partial class Tienda : Migration
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
                name: "Servicio",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Clave = table.Column<string>(maxLength: 200, nullable: true),
                    CetegoriaId = table.Column<Guid>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 200, nullable: true),
                    CategoriasId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Servicio_Categoria_CategoriasId",
                        column: x => x.CategoriasId,
                        principalTable: "Categoria",
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
                        onDelete: ReferentialAction.Cascade);
                    // ESTE ESTA BIEN COMO CSACADE
                });

            migrationBuilder.CreateIndex(
                name: "IX_Precio_ServicioId",
                table: "Precio",
                column: "ServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicio_CategoriasId",
                table: "Servicio",
                column: "CategoriasId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Precio");

            migrationBuilder.DropTable(
                name: "Servicio");

            migrationBuilder.DropTable(
                name: "Categoria");
        }
    }
}
