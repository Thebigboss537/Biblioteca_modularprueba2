using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca_modular.Migrations
{
    public partial class _8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Programas_academicos_Id_programa_academico",
                table: "Usuarios");

            migrationBuilder.AlterColumn<int>(
                name: "Semestre",
                table: "Usuarios",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Id_programa_academico",
                table: "Usuarios",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Programas_academicos_Id_programa_academico",
                table: "Usuarios",
                column: "Id_programa_academico",
                principalTable: "Programas_academicos",
                principalColumn: "Id_programa_academico");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Programas_academicos_Id_programa_academico",
                table: "Usuarios");

            migrationBuilder.AlterColumn<int>(
                name: "Semestre",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id_programa_academico",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
