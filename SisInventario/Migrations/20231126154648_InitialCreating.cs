using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SisInventario.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoria = table.Column<string>(type: "varchar(70)", unicode: false, maxLength: 70, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Categori__3213E83F23713857", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Marca",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    marca = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    telefono = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marca", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    proveedor = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    direccion = table.Column<string>(type: "text", nullable: true),
                    telefono = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Proveedo__3213E83F98014B45", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usuario = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuario__3213E83FC82D7D5E", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    precio = table.Column<decimal>(type: "money", nullable: false),
                    descripcion = table.Column<string>(type: "text", nullable: false),
                    idCategoria = table.Column<int>(type: "int", nullable: false),
                    idMarca = table.Column<int>(type: "int", nullable: false),
                    fechaCaducidad = table.Column<DateTime>(type: "date", nullable: true),
                    areaUbicacion = table.Column<string>(type: "text", nullable: false),
                    stock = table.Column<int>(type: "int", nullable: false),
                    idProveedor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Producto__3213E83F97B632DC", x => x.id);
                    table.ForeignKey(
                        name: "FK_Productos_Categoria",
                        column: x => x.idCategoria,
                        principalTable: "Categoria",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Productos_Marca",
                        column: x => x.idMarca,
                        principalTable: "Marca",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Productos_Proveedor",
                        column: x => x.idProveedor,
                        principalTable: "Proveedor",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(70)", unicode: false, maxLength: 70, nullable: false),
                    apellido = table.Column<string>(type: "varchar(70)", unicode: false, maxLength: 70, nullable: false),
                    cedula = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: false),
                    telefono = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    idUsuario = table.Column<int>(type: "int", nullable: false),
                    idNegocio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Cliente__3213E83F94E602B6", x => x.id);
                    table.ForeignKey(
                        name: "FK_Cliente_Usuario",
                        column: x => x.idUsuario,
                        principalTable: "Usuario",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Negocio",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    negocio = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    telefono = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    direccion = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    idRepresentante = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Negocio__3213E83F961B4818", x => x.id);
                    table.ForeignKey(
                        name: "FK_Negocio_Cliente",
                        column: x => x.idRepresentante,
                        principalTable: "Cliente",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_idNegocio",
                table: "Cliente",
                column: "idNegocio");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_idUsuario",
                table: "Cliente",
                column: "idUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Negocio_idRepresentante",
                table: "Negocio",
                column: "idRepresentante");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_idCategoria",
                table: "Productos",
                column: "idCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_idMarca",
                table: "Productos",
                column: "idMarca");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_idProveedor",
                table: "Productos",
                column: "idProveedor");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Negocio",
                table: "Cliente",
                column: "idNegocio",
                principalTable: "Negocio",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Negocio",
                table: "Cliente");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Marca");

            migrationBuilder.DropTable(
                name: "Proveedor");

            migrationBuilder.DropTable(
                name: "Negocio");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
