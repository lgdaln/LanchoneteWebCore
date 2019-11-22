using Microsoft.EntityFrameworkCore.Migrations;

namespace LanchoneteCore.Migrations
{
    public partial class Ids : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Atendente_AtendenteID",
                table: "Pedido");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Cliente_ClienteID",
                table: "Pedido");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteID",
                table: "Pedido",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AtendenteID",
                table: "Pedido",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Atendente_AtendenteID",
                table: "Pedido",
                column: "AtendenteID",
                principalTable: "Atendente",
                principalColumn: "AtendenteID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Cliente_ClienteID",
                table: "Pedido",
                column: "ClienteID",
                principalTable: "Cliente",
                principalColumn: "ClienteID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Atendente_AtendenteID",
                table: "Pedido");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Cliente_ClienteID",
                table: "Pedido");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteID",
                table: "Pedido",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "AtendenteID",
                table: "Pedido",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Atendente_AtendenteID",
                table: "Pedido",
                column: "AtendenteID",
                principalTable: "Atendente",
                principalColumn: "AtendenteID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Cliente_ClienteID",
                table: "Pedido",
                column: "ClienteID",
                principalTable: "Cliente",
                principalColumn: "ClienteID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
