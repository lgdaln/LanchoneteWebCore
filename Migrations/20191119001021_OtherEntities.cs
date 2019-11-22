using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LanchoneteCore.Migrations
{
    public partial class OtherEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PedidoID",
                table: "Produto",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    PedidoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<DateTime>(nullable: false),
                    Hora = table.Column<TimeSpan>(nullable: false),
                    Statusp = table.Column<bool>(nullable: false),
                    ValorAtual = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.PedidoID);
                });

            migrationBuilder.CreateTable(
                name: "Atendente",
                columns: table => new
                {
                    AtendenteID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<int>(nullable: false),
                    Telefone = table.Column<int>(nullable: false),
                    Email = table.Column<int>(nullable: false),
                    PedidosPedidoID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atendente", x => x.AtendenteID);
                    table.ForeignKey(
                        name: "FK_Atendente_Pedido_PedidosPedidoID",
                        column: x => x.PedidosPedidoID,
                        principalTable: "Pedido",
                        principalColumn: "PedidoID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CPF = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PedidosPedidoID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteID);
                    table.ForeignKey(
                        name: "FK_Cliente_Pedido_PedidosPedidoID",
                        column: x => x.PedidosPedidoID,
                        principalTable: "Pedido",
                        principalColumn: "PedidoID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produto_PedidoID",
                table: "Produto",
                column: "PedidoID");

            migrationBuilder.CreateIndex(
                name: "IX_Atendente_PedidosPedidoID",
                table: "Atendente",
                column: "PedidosPedidoID");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_PedidosPedidoID",
                table: "Cliente",
                column: "PedidosPedidoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Pedido_PedidoID",
                table: "Produto",
                column: "PedidoID",
                principalTable: "Pedido",
                principalColumn: "PedidoID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Pedido_PedidoID",
                table: "Produto");

            migrationBuilder.DropTable(
                name: "Atendente");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropIndex(
                name: "IX_Produto_PedidoID",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "PedidoID",
                table: "Produto");
        }
    }
}
