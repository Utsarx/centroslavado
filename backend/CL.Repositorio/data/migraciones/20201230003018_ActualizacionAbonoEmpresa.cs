using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CL.Repositorio.data.migraciones
{
    public partial class ActualizacionAbonoEmpresa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbonoPrepago_Empresa_EmpresaId",
                table: "AbonoPrepago");

            migrationBuilder.DropColumn(
                name: "EmpesaId",
                table: "AbonoPrepago");

            migrationBuilder.AlterColumn<string>(
                name: "RFC",
                table: "Empresa",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(14)",
                oldMaxLength: 14);

            migrationBuilder.AlterColumn<Guid>(
                name: "EmpresaId",
                table: "AbonoPrepago",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AbonoPrepago_Empresa_EmpresaId",
                table: "AbonoPrepago",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbonoPrepago_Empresa_EmpresaId",
                table: "AbonoPrepago");

            migrationBuilder.AlterColumn<string>(
                name: "RFC",
                table: "Empresa",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "EmpresaId",
                table: "AbonoPrepago",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "EmpesaId",
                table: "AbonoPrepago",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_AbonoPrepago_Empresa_EmpresaId",
                table: "AbonoPrepago",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
