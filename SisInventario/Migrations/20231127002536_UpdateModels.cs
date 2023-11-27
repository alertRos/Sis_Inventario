using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SisInventario.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Negocio_Cliente",
                table: "Negocio");

            migrationBuilder.DropIndex(
                name: "IX_Negocio_idRepresentante",
                table: "Negocio");

            migrationBuilder.DropColumn(
                name: "idRepresentante",
                table: "Negocio");

            migrationBuilder.RenameColumn(
                name: "usuario",
                table: "Usuario",
                newName: "Nombre");

            migrationBuilder.AddColumn<int>(
                name: "FK_ROLEID",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdNegocio",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdRole",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdNegocio",
                table: "Productos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    roleName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Role__3213E83F9A1B0D5F", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_FK_ROLEID",
                table: "Usuario",
                column: "FK_ROLEID");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdNegocio",
                table: "Usuario",
                column: "IdNegocio");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_IdNegocio",
                table: "Productos",
                column: "IdNegocio");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Negocio",
                table: "Productos",
                column: "IdNegocio",
                principalTable: "Negocio",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Negocio_Usuario",
                table: "Usuario",
                column: "IdNegocio",
                principalTable: "Negocio",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Roles_FK_ROLEID",
                table: "Usuario",
                column: "FK_ROLEID",
                principalTable: "Roles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Negocio",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Negocio_Usuario",
                table: "Usuario");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Roles_FK_ROLEID",
                table: "Usuario");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_FK_ROLEID",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_IdNegocio",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Productos_IdNegocio",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "FK_ROLEID",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "IdNegocio",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "IdRole",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "IdNegocio",
                table: "Productos");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Usuario",
                newName: "usuario");

            migrationBuilder.AddColumn<int>(
                name: "idRepresentante",
                table: "Negocio",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Negocio_idRepresentante",
                table: "Negocio",
                column: "idRepresentante");

            migrationBuilder.AddForeignKey(
                name: "FK_Negocio_Cliente",
                table: "Negocio",
                column: "idRepresentante",
                principalTable: "Cliente",
                principalColumn: "id");
        }
    }
}
