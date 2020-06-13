using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace INFNET_F.C._API.Migrations
{
    public partial class CobrancaPropriedades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumeroParcelas",
                table: "Cobranca");

            migrationBuilder.DropColumn(
                name: "ValorParcelas",
                table: "Cobranca");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataValidade",
                table: "Cobranca",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "ValorParcela",
                table: "Cobranca",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ValorTotalCobranca",
                table: "Cobranca",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataValidade",
                table: "Cobranca");

            migrationBuilder.DropColumn(
                name: "ValorParcela",
                table: "Cobranca");

            migrationBuilder.DropColumn(
                name: "ValorTotalCobranca",
                table: "Cobranca");

            migrationBuilder.AddColumn<int>(
                name: "NumeroParcelas",
                table: "Cobranca",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "ValorParcelas",
                table: "Cobranca",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
