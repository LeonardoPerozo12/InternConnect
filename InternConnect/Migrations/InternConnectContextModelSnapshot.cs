﻿// <auto-generated />
using System;
using InternConnect.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InternConnect.Migrations
{
    [DbContext(typeof(InternConnectContext))]
    partial class InternConnectContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("InternConnect.Models.Aplicacion", b =>
                {
                    b.Property<int>("IDAplicacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IDAplicacion"));

                    b.Property<string>("EstadoAplicacion")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("FechaAplicacion")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IDEstudiante")
                        .HasColumnType("int");

                    b.Property<int>("IDPasantia")
                        .HasColumnType("int");

                    b.HasKey("IDAplicacion");

                    b.HasAlternateKey("IDEstudiante", "IDPasantia");

                    b.ToTable("Aplicaciones");
                });

            modelBuilder.Entity("InternConnect.Models.Beneficios", b =>
                {
                    b.Property<int>("IDBeneficios")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IDBeneficios"));

                    b.Property<string>("Descripcion")
                        .HasColumnType("longtext");

                    b.Property<string>("TipoBeneficios")
                        .HasColumnType("longtext");

                    b.HasKey("IDBeneficios");

                    b.ToTable("Beneficios");
                });

            modelBuilder.Entity("InternConnect.Models.BeneficiosPasantia", b =>
                {
                    b.Property<int>("IDBeneficios")
                        .HasColumnType("int");

                    b.Property<int>("IDPasantia")
                        .HasColumnType("int");

                    b.HasKey("IDBeneficios", "IDPasantia");

                    b.ToTable("BeneficiosPasantias");
                });

            modelBuilder.Entity("InternConnect.Models.Carrera", b =>
                {
                    b.Property<int>("IDCarrera")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IDCarrera"));

                    b.Property<string>("Nombre")
                        .HasColumnType("longtext");

                    b.HasKey("IDCarrera");

                    b.ToTable("Carreras");
                });

            modelBuilder.Entity("InternConnect.Models.Empresa", b =>
                {
                    b.Property<int>("IDEmpresa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IDEmpresa"));

                    b.Property<string>("Contacto")
                        .HasColumnType("longtext");

                    b.Property<string>("ContraseñaHash")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CorreoRRHH")
                        .HasColumnType("longtext");

                    b.Property<string>("Descripcion")
                        .HasColumnType("longtext");

                    b.Property<string>("Direccion")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("FechaIngreso")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IDRol")
                        .HasColumnType("int");

                    b.Property<string>("LogoEmpresa")
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre")
                        .HasColumnType("longtext");

                    b.Property<string>("RNC")
                        .HasColumnType("longtext");

                    b.Property<bool>("Verificacion")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("IDEmpresa");

                    b.HasIndex("IDRol");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("InternConnect.Models.Estudiante", b =>
                {
                    b.Property<int>("IDEstudiante")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IDEstudiante"));

                    b.Property<string>("ContraseñaHash")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Correo")
                        .HasColumnType("longtext");

                    b.Property<string>("Direccion")
                        .HasColumnType("longtext");

                    b.Property<string>("Documento")
                        .HasColumnType("longtext");

                    b.Property<int?>("IDCarrera")
                        .HasColumnType("int");

                    b.Property<int>("IDRol")
                        .HasColumnType("int");

                    b.Property<int?>("IDUniversidad")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("longtext");

                    b.Property<string>("Telefono")
                        .HasColumnType("longtext");

                    b.Property<int?>("TipoDocumento")
                        .HasColumnType("int");

                    b.HasKey("IDEstudiante");

                    b.HasIndex("IDRol");

                    b.ToTable("Estudiantes");
                });

            modelBuilder.Entity("InternConnect.Models.Pasantia", b =>
                {
                    b.Property<int>("IDPasantia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IDPasantia"));

                    b.Property<string>("Area")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("DineroRemuneracion")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("Duracion")
                        .HasColumnType("int");

                    b.Property<bool>("EsRemuneracion")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("FechaIngreso")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IDBeneficios")
                        .HasColumnType("int");

                    b.Property<int>("IDEmpresa")
                        .HasColumnType("int");

                    b.Property<string>("ModalidadPasa")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Requisitos")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Rol")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("IDPasantia");

                    b.ToTable("Pasantias");
                });

            modelBuilder.Entity("InternConnect.Models.Rol", b =>
                {
                    b.Property<int>("IDRol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IDRol"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("IDRol");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            IDRol = 1,
                            Nombre = "Estudiante"
                        },
                        new
                        {
                            IDRol = 2,
                            Nombre = "Empresa"
                        });
                });

            modelBuilder.Entity("InternConnect.Models.TipoDocumento", b =>
                {
                    b.Property<int>("TipoDocumentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("TipoDocumentoId"));

                    b.Property<string>("NombreTipoDocumento")
                        .HasColumnType("longtext");

                    b.HasKey("TipoDocumentoId");

                    b.ToTable("TipoDocumentos");
                });

            modelBuilder.Entity("InternConnect.Models.Universidad", b =>
                {
                    b.Property<int>("IDUniversidad")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("IDUniversidad"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("IDUniversidad");

                    b.ToTable("Universidades");
                });

            modelBuilder.Entity("InternConnect.Models.Empresa", b =>
                {
                    b.HasOne("InternConnect.Models.Rol", "Rol")
                        .WithMany()
                        .HasForeignKey("IDRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("InternConnect.Models.Estudiante", b =>
                {
                    b.HasOne("InternConnect.Models.Rol", "Rol")
                        .WithMany()
                        .HasForeignKey("IDRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");
                });
#pragma warning restore 612, 618
        }
    }
}
