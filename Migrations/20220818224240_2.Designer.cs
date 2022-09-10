﻿// <auto-generated />
using System;
using Biblioteca_modular.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Biblioteca_modular.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220818224240_2")]
    partial class _2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Biblioteca_modular.Models.Autor", b =>
                {
                    b.Property<int>("Id_autor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_autor"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id_autor");

                    b.ToTable("Autores");
                });

            modelBuilder.Entity("Biblioteca_modular.Models.Categoria", b =>
                {
                    b.Property<int>("Id_categoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_categoria"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.HasKey("Id_categoria");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("Biblioteca_modular.Models.Cliente", b =>
                {
                    b.Property<int>("Id_cliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_cliente"), 1L, 1);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("Cedula")
                        .HasColumnType("int");

                    b.Property<string>("Correo_electronico")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<int>("Id_programa_academico")
                        .HasColumnType("int");

                    b.Property<int?>("Id_usuario")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("Semestre")
                        .HasColumnType("int");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_cliente");

                    b.HasIndex("Id_programa_academico");

                    b.HasIndex("Id_usuario");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Biblioteca_modular.Models.Devolucion", b =>
                {
                    b.Property<int>("Id_devolucion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_devolucion"), 1L, 1);

                    b.Property<DateTime>("Fecha_devolucion")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id_prestamo")
                        .HasColumnType("int");

                    b.Property<string>("Observacion")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id_devolucion");

                    b.HasIndex("Id_prestamo");

                    b.ToTable("Devoluciones");
                });

            modelBuilder.Entity("Biblioteca_modular.Models.Editorial", b =>
                {
                    b.Property<int>("Id_editorial")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_editorial"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id_editorial");

                    b.ToTable("Editoriales");
                });

            modelBuilder.Entity("Biblioteca_modular.Models.Material", b =>
                {
                    b.Property<int>("Id_material")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_material"), 1L, 1);

                    b.Property<string>("Archivo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Año")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Formato")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("ISBN")
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<int?>("Id_editorial")
                        .HasColumnType("int");

                    b.Property<int>("Id_sede")
                        .HasColumnType("int");

                    b.Property<int>("Id_tipo_material")
                        .HasColumnType("int");

                    b.Property<string>("Idioma")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Observacion")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_material");

                    b.HasIndex("Id_editorial");

                    b.HasIndex("Id_sede");

                    b.HasIndex("Id_tipo_material");

                    b.ToTable("Materiales");
                });

            modelBuilder.Entity("Biblioteca_modular.Models.Material_autor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Id_autor")
                        .HasColumnType("int");

                    b.Property<int>("Id_material")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Id_autor");

                    b.HasIndex("Id_material");

                    b.ToTable("Material_Autores");
                });

            modelBuilder.Entity("Biblioteca_modular.Models.Material_categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Id_categoria")
                        .HasColumnType("int");

                    b.Property<int>("Id_material")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Id_categoria");

                    b.HasIndex("Id_material");

                    b.ToTable("Material_Categorias");
                });

            modelBuilder.Entity("Biblioteca_modular.Models.Prestamo", b =>
                {
                    b.Property<int>("Id_prestamo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_prestamo"), 1L, 1);

                    b.Property<DateTime>("Fecha_limite")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Fecha_prestamo")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id_material")
                        .HasColumnType("int");

                    b.Property<int>("Id_ususario")
                        .HasColumnType("int");

                    b.HasKey("Id_prestamo");

                    b.HasIndex("Id_material");

                    b.HasIndex("Id_ususario");

                    b.ToTable("Prestamos");
                });

            modelBuilder.Entity("Biblioteca_modular.Models.Programa_academico", b =>
                {
                    b.Property<int>("Id_programa_academico")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_programa_academico"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id_programa_academico");

                    b.ToTable("Programas_academicos");
                });

            modelBuilder.Entity("Biblioteca_modular.Models.Reserva", b =>
                {
                    b.Property<int>("Id_reserva")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_reserva"), 1L, 1);

                    b.Property<DateTime>("Fecha_reserva")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id_material")
                        .HasColumnType("int");

                    b.Property<int>("Id_ususario")
                        .HasColumnType("int");

                    b.HasKey("Id_reserva");

                    b.HasIndex("Id_material");

                    b.HasIndex("Id_ususario");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("Biblioteca_modular.Models.Rol", b =>
                {
                    b.Property<int>("Id_rol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_rol"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id_rol");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Biblioteca_modular.Models.Sede", b =>
                {
                    b.Property<int>("Id_sede")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_sede"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id_sede");

                    b.ToTable("Sedes");
                });

            modelBuilder.Entity("Biblioteca_modular.Models.Tipo_material", b =>
                {
                    b.Property<int>("Id_tipo_material")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_tipo_material"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id_tipo_material");

                    b.ToTable("Tipo_materiales");
                });

            modelBuilder.Entity("Biblioteca_modular.Models.Usuario", b =>
                {
                    b.Property<int>("Id_usuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_usuario"), 1L, 1);

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("Username")
                        .HasColumnType("int");

                    b.Property<int>("id_rol")
                        .HasColumnType("int");

                    b.HasKey("Id_usuario");

                    b.HasIndex("id_rol");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Biblioteca_modular.Models.Cliente", b =>
                {
                    b.HasOne("Biblioteca_modular.Models.Programa_academico", "Programa_academico")
                        .WithMany()
                        .HasForeignKey("Id_programa_academico")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Biblioteca_modular.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("Id_usuario");

                    b.Navigation("Programa_academico");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Biblioteca_modular.Models.Devolucion", b =>
                {
                    b.HasOne("Biblioteca_modular.Models.Prestamo", "Prestamo")
                        .WithMany()
                        .HasForeignKey("Id_prestamo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Prestamo");
                });

            modelBuilder.Entity("Biblioteca_modular.Models.Material", b =>
                {
                    b.HasOne("Biblioteca_modular.Models.Editorial", "Editorial")
                        .WithMany()
                        .HasForeignKey("Id_editorial");

                    b.HasOne("Biblioteca_modular.Models.Sede", "Sede")
                        .WithMany()
                        .HasForeignKey("Id_sede")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Biblioteca_modular.Models.Tipo_material", "Tipo_material")
                        .WithMany()
                        .HasForeignKey("Id_tipo_material")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Editorial");

                    b.Navigation("Sede");

                    b.Navigation("Tipo_material");
                });

            modelBuilder.Entity("Biblioteca_modular.Models.Material_autor", b =>
                {
                    b.HasOne("Biblioteca_modular.Models.Autor", "Autor")
                        .WithMany()
                        .HasForeignKey("Id_autor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Biblioteca_modular.Models.Material", "Material")
                        .WithMany()
                        .HasForeignKey("Id_material")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Autor");

                    b.Navigation("Material");
                });

            modelBuilder.Entity("Biblioteca_modular.Models.Material_categoria", b =>
                {
                    b.HasOne("Biblioteca_modular.Models.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("Id_categoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Biblioteca_modular.Models.Material", "Material")
                        .WithMany()
                        .HasForeignKey("Id_material")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Material");
                });

            modelBuilder.Entity("Biblioteca_modular.Models.Prestamo", b =>
                {
                    b.HasOne("Biblioteca_modular.Models.Material", "Material")
                        .WithMany()
                        .HasForeignKey("Id_material")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Biblioteca_modular.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("Id_ususario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Material");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Biblioteca_modular.Models.Reserva", b =>
                {
                    b.HasOne("Biblioteca_modular.Models.Material", "Material")
                        .WithMany()
                        .HasForeignKey("Id_material")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Biblioteca_modular.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("Id_ususario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Material");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Biblioteca_modular.Models.Usuario", b =>
                {
                    b.HasOne("Biblioteca_modular.Models.Rol", "Rol")
                        .WithMany()
                        .HasForeignKey("id_rol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");
                });
#pragma warning restore 612, 618
        }
    }
}