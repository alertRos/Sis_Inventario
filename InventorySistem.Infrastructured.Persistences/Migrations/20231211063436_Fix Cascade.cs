using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventorySystem.Infrastructured.Persistences.Migrations
{
    /// <inheritdoc />
    public partial class FixCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Categoria",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Marca",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Negocio",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Proveedor",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Representante_Negocio",
                table: "Representante");

            migrationBuilder.DropForeignKey(
                name: "FK_Representante_Usuario",
                table: "Representante");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Categoria",
                table: "Productos",
                column: "idCategoria",
                principalTable: "Categoria",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Marca",
                table: "Productos",
                column: "idMarca",
                principalTable: "Marca",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Negocio",
                table: "Productos",
                column: "IdNegocio",
                principalTable: "Negocio",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Proveedor",
                table: "Productos",
                column: "idProveedor",
                principalTable: "Proveedor",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Representante_Negocio",
                table: "Representante",
                column: "idNegocio",
                principalTable: "Negocio",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Representante_Usuario",
                table: "Representante",
                column: "idUsuario",
                principalTable: "Usuario",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Categoria",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Marca",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Negocio",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Proveedor",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Representante_Negocio",
                table: "Representante");

            migrationBuilder.DropForeignKey(
                name: "FK_Representante_Usuario",
                table: "Representante");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Categoria",
                table: "Productos",
                column: "idCategoria",
                principalTable: "Categoria",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Marca",
                table: "Productos",
                column: "idMarca",
                principalTable: "Marca",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Negocio",
                table: "Productos",
                column: "IdNegocio",
                principalTable: "Negocio",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Proveedor",
                table: "Productos",
                column: "idProveedor",
                principalTable: "Proveedor",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Representante_Negocio",
                table: "Representante",
                column: "idNegocio",
                principalTable: "Negocio",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Representante_Usuario",
                table: "Representante",
                column: "idUsuario",
                principalTable: "Usuario",
                principalColumn: "id");
        }
    }
}
