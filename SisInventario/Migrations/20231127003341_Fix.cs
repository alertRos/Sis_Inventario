using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SisInventario.Migrations
{
    /// <inheritdoc />
    public partial class Fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Roles_FK_ROLEID",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_FK_ROLEID",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "FK_ROLEID",
                table: "Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdRole",
                table: "Usuario",
                column: "IdRole");

            migrationBuilder.AddForeignKey(
                name: "FK_Role_Usuario",
                table: "Usuario",
                column: "IdRole",
                principalTable: "Roles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Role_Usuario",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_IdRole",
                table: "Usuario");

            migrationBuilder.AddColumn<int>(
                name: "FK_ROLEID",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_FK_ROLEID",
                table: "Usuario",
                column: "FK_ROLEID");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Roles_FK_ROLEID",
                table: "Usuario",
                column: "FK_ROLEID",
                principalTable: "Roles",
                principalColumn: "Id");
        }
    }
}
