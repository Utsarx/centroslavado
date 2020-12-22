﻿// <auto-generated />
using System;
using CL.Repositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CL.Repositorio.data.migraciones
{
    [DbContext(typeof(ContextoAplicacion))]
    [Migration("20201221024449_CentroLavado")]
    partial class CentroLavado
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CL.Modelo.CentroLavado", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("CentroLavado");
                });

            modelBuilder.Entity("CL.Modelo.Empleado", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Hash")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("NombreUsuario")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Salt")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UltimoAcceso")
                        .HasColumnType("datetime2");

                    b.Property<bool>("UsuarioSistema")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Empleado");
                });

            modelBuilder.Entity("CL.Modelo.EmpleadoCentroLavado", b =>
                {
                    b.Property<Guid>("CentroLavadoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EmpleadoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CentroLavadoId", "EmpleadoId");

                    b.HasIndex("EmpleadoId");

                    b.ToTable("EmpleadosCentroLavado");
                });

            modelBuilder.Entity("CL.Modelo.EmpleadoCentroLavado", b =>
                {
                    b.HasOne("CL.Modelo.CentroLavado", "CentroLavado")
                        .WithMany("Emmpleados")
                        .HasForeignKey("CentroLavadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CL.Modelo.Empleado", "Empleado")
                        .WithMany("CentrosLavado")
                        .HasForeignKey("EmpleadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
