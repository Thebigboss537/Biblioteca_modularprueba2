using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca_modular.Migrations
{
    public partial class _5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prestamos_Clientes_Id_cliente",
                table: "Prestamos");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Usuarios_Id_cliente",
                table: "Reservas");

            migrationBuilder.RenameColumn(
                name: "Id_cliente",
                table: "Reservas",
                newName: "Id_usuario");

            migrationBuilder.RenameIndex(
                name: "IX_Reservas_Id_cliente",
                table: "Reservas",
                newName: "IX_Reservas_Id_usuario");

            migrationBuilder.RenameColumn(
                name: "Id_cliente",
                table: "Prestamos",
                newName: "Id_usuario");

            migrationBuilder.RenameIndex(
                name: "IX_Prestamos_Id_cliente",
                table: "Prestamos",
                newName: "IX_Prestamos_Id_usuario");

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

            migrationBuilder.RenameColumn(
                name: "Id_usuario",
                table: "Reservas",
                newName: "Id_cliente");

            migrationBuilder.RenameIndex(
                name: "IX_Reservas_Id_usuario",
                table: "Reservas",
                newName: "IX_Reservas_Id_cliente");

            migrationBuilder.RenameColumn(
                name: "Id_usuario",
                table: "Prestamos",
                newName: "Id_cliente");

            migrationBuilder.RenameIndex(
                name: "IX_Prestamos_Id_usuario",
                table: "Prestamos",
                newName: "IX_Prestamos_Id_cliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamos_Clientes_Id_cliente",
                table: "Prestamos",
                column: "Id_cliente",
                principalTable: "Clientes",
                principalColumn: "Id_cliente",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Usuarios_Id_cliente",
                table: "Reservas",
                column: "Id_cliente",
                principalTable: "Usuarios",
                principalColumn: "Id_usuario",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
