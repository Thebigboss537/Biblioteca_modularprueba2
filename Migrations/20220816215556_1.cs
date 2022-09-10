using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca_modular.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autores",
                columns: table => new
                {
                    Id_autor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.Id_autor);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id_categoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id_categoria);
                });

            migrationBuilder.CreateTable(
                name: "Editoriales",
                columns: table => new
                {
                    Id_editorial = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editoriales", x => x.Id_editorial);
                });

            migrationBuilder.CreateTable(
                name: "Programas_academicos",
                columns: table => new
                {
                    Id_programa_academico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programas_academicos", x => x.Id_programa_academico);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id_rol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id_rol);
                });

            migrationBuilder.CreateTable(
                name: "Sedes",
                columns: table => new
                {
                    Id_sede = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sedes", x => x.Id_sede);
                });

            migrationBuilder.CreateTable(
                name: "Tipo_materiales",
                columns: table => new
                {
                    Id_tipo_material = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo_materiales", x => x.Id_tipo_material);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id_usuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cedula = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Id_programa_academico = table.Column<int>(type: "int", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Semestre = table.Column<int>(type: "int", nullable: false),
                    Correo_electronico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    id_rol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id_usuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Programas_academicos_Id_programa_academico",
                        column: x => x.Id_programa_academico,
                        principalTable: "Programas_academicos",
                        principalColumn: "Id_programa_academico",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles_id_rol",
                        column: x => x.id_rol,
                        principalTable: "Roles",
                        principalColumn: "Id_rol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Materiales",
                columns: table => new
                {
                    Id_material = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id_tipo_material = table.Column<int>(type: "int", nullable: false),
                    Id_editorial = table.Column<int>(type: "int", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Año = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Formato = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Idioma = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
                    Id_sede = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Archivo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materiales", x => x.Id_material);
                    table.ForeignKey(
                        name: "FK_Materiales_Editoriales_Id_editorial",
                        column: x => x.Id_editorial,
                        principalTable: "Editoriales",
                        principalColumn: "Id_editorial");
                    table.ForeignKey(
                        name: "FK_Materiales_Sedes_Id_sede",
                        column: x => x.Id_sede,
                        principalTable: "Sedes",
                        principalColumn: "Id_sede",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Materiales_Tipo_materiales_Id_tipo_material",
                        column: x => x.Id_tipo_material,
                        principalTable: "Tipo_materiales",
                        principalColumn: "Id_tipo_material",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Material_Autores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_material = table.Column<int>(type: "int", nullable: false),
                    Id_autor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_Autores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_Autores_Autores_Id_autor",
                        column: x => x.Id_autor,
                        principalTable: "Autores",
                        principalColumn: "Id_autor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Material_Autores_Materiales_Id_material",
                        column: x => x.Id_material,
                        principalTable: "Materiales",
                        principalColumn: "Id_material",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Material_Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_material = table.Column<int>(type: "int", nullable: false),
                    Id_categoria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_Categorias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_Categorias_Categorias_Id_categoria",
                        column: x => x.Id_categoria,
                        principalTable: "Categorias",
                        principalColumn: "Id_categoria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Material_Categorias_Materiales_Id_material",
                        column: x => x.Id_material,
                        principalTable: "Materiales",
                        principalColumn: "Id_material",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prestamos",
                columns: table => new
                {
                    Id_prestamo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_ususario = table.Column<int>(type: "int", nullable: false),
                    Id_material = table.Column<int>(type: "int", nullable: false),
                    Fecha_prestamo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fecha_limite = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamos", x => x.Id_prestamo);
                    table.ForeignKey(
                        name: "FK_Prestamos_Materiales_Id_material",
                        column: x => x.Id_material,
                        principalTable: "Materiales",
                        principalColumn: "Id_material",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prestamos_Usuarios_Id_ususario",
                        column: x => x.Id_ususario,
                        principalTable: "Usuarios",
                        principalColumn: "Id_usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    Id_reserva = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_ususario = table.Column<int>(type: "int", nullable: false),
                    Id_material = table.Column<int>(type: "int", nullable: false),
                    Fecha_reserva = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.Id_reserva);
                    table.ForeignKey(
                        name: "FK_Reservas_Materiales_Id_material",
                        column: x => x.Id_material,
                        principalTable: "Materiales",
                        principalColumn: "Id_material",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservas_Usuarios_Id_ususario",
                        column: x => x.Id_ususario,
                        principalTable: "Usuarios",
                        principalColumn: "Id_usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Devoluciones",
                columns: table => new
                {
                    Id_devolucion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_prestamo = table.Column<int>(type: "int", nullable: false),
                    Fecha_devolucion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devoluciones", x => x.Id_devolucion);
                    table.ForeignKey(
                        name: "FK_Devoluciones_Prestamos_Id_prestamo",
                        column: x => x.Id_prestamo,
                        principalTable: "Prestamos",
                        principalColumn: "Id_prestamo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Devoluciones_Id_prestamo",
                table: "Devoluciones",
                column: "Id_prestamo");

            migrationBuilder.CreateIndex(
                name: "IX_Material_Autores_Id_autor",
                table: "Material_Autores",
                column: "Id_autor");

            migrationBuilder.CreateIndex(
                name: "IX_Material_Autores_Id_material",
                table: "Material_Autores",
                column: "Id_material");

            migrationBuilder.CreateIndex(
                name: "IX_Material_Categorias_Id_categoria",
                table: "Material_Categorias",
                column: "Id_categoria");

            migrationBuilder.CreateIndex(
                name: "IX_Material_Categorias_Id_material",
                table: "Material_Categorias",
                column: "Id_material");

            migrationBuilder.CreateIndex(
                name: "IX_Materiales_Id_editorial",
                table: "Materiales",
                column: "Id_editorial");

            migrationBuilder.CreateIndex(
                name: "IX_Materiales_Id_sede",
                table: "Materiales",
                column: "Id_sede");

            migrationBuilder.CreateIndex(
                name: "IX_Materiales_Id_tipo_material",
                table: "Materiales",
                column: "Id_tipo_material");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_Id_material",
                table: "Prestamos",
                column: "Id_material");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_Id_ususario",
                table: "Prestamos",
                column: "Id_ususario");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_Id_material",
                table: "Reservas",
                column: "Id_material");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_Id_ususario",
                table: "Reservas",
                column: "Id_ususario");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Id_programa_academico",
                table: "Usuarios",
                column: "Id_programa_academico");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_id_rol",
                table: "Usuarios",
                column: "id_rol");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Devoluciones");

            migrationBuilder.DropTable(
                name: "Material_Autores");

            migrationBuilder.DropTable(
                name: "Material_Categorias");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Prestamos");

            migrationBuilder.DropTable(
                name: "Autores");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Materiales");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Editoriales");

            migrationBuilder.DropTable(
                name: "Sedes");

            migrationBuilder.DropTable(
                name: "Tipo_materiales");

            migrationBuilder.DropTable(
                name: "Programas_academicos");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
