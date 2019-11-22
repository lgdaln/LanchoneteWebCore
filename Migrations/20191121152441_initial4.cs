using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LanchoneteCore.Migrations
{
    public partial class initial4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Hora",
                table: "Pedido",
                nullable: true,
                oldClrType: typeof(TimeSpan));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Hora",
                table: "Pedido",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
