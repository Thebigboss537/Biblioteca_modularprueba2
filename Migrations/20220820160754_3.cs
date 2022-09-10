using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca_modular.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Roles_id_rol",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Clientes");

            migrationBuilder.RenameColumn(
                name: "id_rol",
                table: "Usuarios",
                newName: "Id_rol");

            migrationBuilder.RenameIndex(
                name: "IX_Usuarios_id_rol",
                table: "Usuarios",
                newName: "IX_Usuarios_Id_rol");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Roles_Id_rol",
                table: "Usuarios",
                column: "Id_rol",
                principalTable: "Roles",
                principalColumn: "Id_rol",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Roles_Id_rol",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "Id_rol",
                table: "Usuarios",
                newName: "id_rol");

            migrationBuilder.RenameIndex(
                name: "IX_Usuarios_Id_rol",
                table: "Usuarios",
                newName: "IX_Usuarios_id_rol");

            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Roles_id_rol",
                table: "Usuarios",
                column: "id_rol",
                principalTable: "Roles",
                principalColumn: "Id_rol",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
