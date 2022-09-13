using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca_modular.Migrations
{
    public partial class _6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prestamos_Usuarios_Id_usuario",
                table: "Prestamos");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Usuarios_Id_usuario",
                table: "Reservas");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Roles_Id_rol",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Usuarios",
                newName: "Semestre");

            migrationBuilder.RenameColumn(
                name: "Id_rol",
                table: "Usuarios",
                newName: "Id_programa_academico");

            migrationBuilder.RenameIndex(
                name: "IX_Usuarios_Id_rol",
                table: "Usuarios",
                newName: "IX_Usuarios_Id_programa_academico");

            migrationBuilder.AddColumn<string>(
                name: "Apellido",
                table: "Usuarios",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Cedula",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Correo_electronico",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Id_usuario_autenticacion",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Usuarios",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Usuarios_autenticacion",
                columns: table => new
                {
                    Id_usuario_autenticacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<int>(type: "int", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Id_rol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios_autenticacion", x => x.Id_usuario_autenticacion);
                    table.ForeignKey(
                        name: "FK_Usuarios_autenticacion_Roles_Id_rol",
                        column: x => x.Id_rol,
                        principalTable: "Roles",
                        principalColumn: "Id_rol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Id_usuario_autenticacion",
                table: "Usuarios",
                column: "Id_usuario_autenticacion");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_autenticacion_Id_rol",
                table: "Usuarios_autenticacion",
                column: "Id_rol");

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamos_Usuarios_autenticacion_Id_usuario",
                table: "Prestamos",
                column: "Id_usuario",
                principalTable: "Usuarios_autenticacion",
                principalColumn: "Id_usuario_autenticacion",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Usuarios_autenticacion_Id_usuario",
                table: "Reservas",
                column: "Id_usuario",
                principalTable: "Usuarios_autenticacion",
                principalColumn: "Id_usuario_autenticacion",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Programas_academicos_Id_programa_academico",
                table: "Usuarios",
                column: "Id_programa_academico",
                principalTable: "Programas_academicos",
                principalColumn: "Id_programa_academico",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Usuarios_autenticacion_Id_usuario_autenticacion",
                table: "Usuarios",
                column: "Id_usuario_autenticacion",
                principalTable: "Usuarios_autenticacion",
                principalColumn: "Id_usuario_autenticacion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prestamos_Usuarios_autenticacion_Id_usuario",
                table: "Prestamos");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Usuarios_autenticacion_Id_usuario",
                table: "Reservas");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Programas_academicos_Id_programa_academico",
                table: "Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Usuarios_autenticacion_Id_usuario_autenticacion",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "Usuarios_autenticacion");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_Id_usuario_autenticacion",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Apellido",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Cedula",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Correo_electronico",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Id_usuario_autenticacion",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "Semestre",
                table: "Usuarios",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "Id_programa_academico",
                table: "Usuarios",
                newName: "Id_rol");

            migrationBuilder.RenameIndex(
                name: "IX_Usuarios_Id_programa_academico",
                table: "Usuarios",
                newName: "IX_Usuarios_Id_rol");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "Usuarios",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "Usuarios",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id_cliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_programa_academico = table.Column<int>(type: "int", nullable: false),
                    Id_usuario = table.Column<int>(type: "int", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Cedula = table.Column<int>(type: "int", nullable: false),
                    Correo_electronico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Semestre = table.Column<int>(type: "int", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id_cliente);
                    table.ForeignKey(
                        name: "FK_Clientes_Programas_academicos_Id_programa_academico",
                        column: x => x.Id_programa_academico,
                        principalTable: "Programas_academicos",
                        principalColumn: "Id_programa_academico",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clientes_Usuarios_Id_usuario",
                        column: x => x.Id_usuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id_usuario");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_Id_programa_academico",
                table: "Clientes",
                column: "Id_programa_academico");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_Id_usuario",
                table: "Clientes",
                column: "Id_usuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamos_Usuarios_Id_usuario",
                table: "Prestamos",
                column: "Id_usuario",
                principalTable: "Usuarios",
                principalColumn: "Id_usuario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Usuarios_Id_usuario",
                table: "Reservas",
                column: "Id_usuario",
                principalTable: "Usuarios",
                principalColumn: "Id_usuario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Roles_Id_rol",
                table: "Usuarios",
                column: "Id_rol",
                principalTable: "Roles",
                principalColumn: "Id_rol",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
