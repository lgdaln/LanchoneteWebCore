using Microsoft.EntityFrameworkCore.Migrations;

namespace LanchoneteCore.Migrations
{
    public partial class OtherEntities4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atendente_Pedido_PedidosPedidoID",
                table: "Atendente");

            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Pedido_PedidosPedidoID",
                table: "Cliente");

            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Pedido_PedidoID",
                table: "Produto");

            migrationBuilder.DropIndex(
                name: "IX_Produto_PedidoID",
                table: "Produto");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_PedidosPedidoID",
                table: "Cliente");

            migrationBuilder.DropIndex(
                name: "IX_Atendente_PedidosPedidoID",
                table: "Atendente");

            migrationBuilder.DropColumn(
                name: "PedidoID",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "PedidosPedidoID",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "PedidosPedidoID",
                table: "Atendente");

            migrationBuilder.AddColumn<int>(
                name: "AtendenteID",
                table: "Pedido",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClienteID",
                table: "Pedido",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProdutoID",
                table: "Pedido",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_AtendenteID",
                table: "Pedido",
                column: "AtendenteID");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_ClienteID",
                table: "Pedido",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_ProdutoID",
                table: "Pedido",
                column: "ProdutoID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Produto_ProdutoID",
                table: "Pedido",
                column: "ProdutoID",
                principalTable: "Produto",
                principalColumn: "ProdutoID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Atendente_AtendenteID",
                table: "Pedido");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Cliente_ClienteID",
                table: "Pedido");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Produto_ProdutoID",
                table: "Pedido");

            migrationBuilder.DropIndex(
                name: "IX_Pedido_AtendenteID",
                table: "Pedido");

            migrationBuilder.DropIndex(
                name: "IX_Pedido_ClienteID",
                table: "Pedido");

            migrationBuilder.DropIndex(
                name: "IX_Pedido_ProdutoID",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "AtendenteID",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "ClienteID",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "ProdutoID",
                table: "Pedido");

            migrationBuilder.AddColumn<int>(
                name: "PedidoID",
                table: "Produto",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PedidosPedidoID",
                table: "Cliente",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PedidosPedidoID",
                table: "Atendente",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produto_PedidoID",
                table: "Produto",
                column: "PedidoID");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_PedidosPedidoID",
                table: "Cliente",
                column: "PedidosPedidoID");

            migrationBuilder.CreateIndex(
                name: "IX_Atendente_PedidosPedidoID",
                table: "Atendente",
                column: "PedidosPedidoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Atendente_Pedido_PedidosPedidoID",
                table: "Atendente",
                column: "PedidosPedidoID",
                principalTable: "Pedido",
                principalColumn: "PedidoID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Pedido_PedidosPedidoID",
                table: "Cliente",
                column: "PedidosPedidoID",
                principalTable: "Pedido",
                principalColumn: "PedidoID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Pedido_PedidoID",
                table: "Produto",
                column: "PedidoID",
                principalTable: "Pedido",
                principalColumn: "PedidoID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
