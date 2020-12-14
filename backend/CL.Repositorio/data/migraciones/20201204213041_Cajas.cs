using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CL.Repositorio.data.migraciones
{
    public partial class Cajas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Caja",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Noeconomico = table.Column<string>(maxLength: 100, nullable: true),
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

            migrationBuilder.CreateIndex(
                name: "IX_Caja_EmpresaId",
                table: "Caja",
                column: "EmpresaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Caja");
        }
    }
}
