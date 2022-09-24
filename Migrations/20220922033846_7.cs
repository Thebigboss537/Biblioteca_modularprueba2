using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca_modular.Migrations
{
    public partial class _7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prestamos_Usuarios_autenticacion_Id_usuario",
                table: "Prestamos");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Usuarios_autenticacion_Id_usuario",
                table: "Reservas");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prestamos_Usuarios_Id_usuario",
                table: "Prestamos");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Usuarios_Id_usuario",
                table: "Reservas");

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
        }
    }
}
