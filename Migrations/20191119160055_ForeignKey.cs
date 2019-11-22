using Microsoft.EntityFrameworkCore.Migrations;

namespace LanchoneteCore.Migrations
{
    public partial class ForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Produto_ProdutoID",
                table: "Pedido");

            migrationBuilder.RenameColumn(
                name: "ProdutoID",
                table: "Pedido",
                newName: "ProdutoId");

            migrationBuilder.RenameIndex(
                name: "IX_Pedido_ProdutoID",
                table: "Pedido",
                newName: "IX_Pedido_ProdutoId");

            migrationBuilder.AlterColumn<int>(
                name: "ProdutoId",
                table: "Pedido",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Produto_ProdutoId",
                table: "Pedido",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "ProdutoID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Produto_ProdutoId",
                table: "Pedido");

            migrationBuilder.RenameColumn(
                name: "ProdutoId",
                table: "Pedido",
                newName: "ProdutoID");

            migrationBuilder.RenameIndex(
                name: "IX_Pedido_ProdutoId",
                table: "Pedido",
                newName: "IX_Pedido_ProdutoID");

            migrationBuilder.AlterColumn<int>(
                name: "ProdutoID",
                table: "Pedido",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Produto_ProdutoID",
                table: "Pedido",
                column: "ProdutoID",
                principalTable: "Produto",
                principalColumn: "ProdutoID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
