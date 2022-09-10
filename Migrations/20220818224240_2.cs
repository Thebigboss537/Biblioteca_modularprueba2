using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca_modular.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Programas_academicos_Id_programa_academico",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_Id_programa_academico",
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
                name: "Estado",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Id_programa_academico",
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

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id_cliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cedula = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Id_programa_academico = table.Column<int>(type: "int", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Semestre = table.Column<int>(type: "int", nullable: false),
                    Correo_electronico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    Id_usuario = table.Column<int>(type: "int", nullable: true)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Usuarios",
                newName: "Semestre");

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
                name: "Estado",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_programa_academico",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Id_programa_academico",
                table: "Usuarios",
                column: "Id_programa_academico");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Programas_academicos_Id_programa_academico",
                table: "Usuarios",
                column: "Id_programa_academico",
                principalTable: "Programas_academicos",
                principalColumn: "Id_programa_academico",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
