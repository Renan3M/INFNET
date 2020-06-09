using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace INFNET_F.C._API.Migrations
{
    public partial class boolVldFlg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "FLG_Ativo",
                table: "Socio",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME_MENU = table.Column<string>(maxLength: 100, nullable: false),
                    ICONEMENU = table.Column<string>(maxLength: 100, nullable: true),
                    ROTA_MENU = table.Column<string>(maxLength: 100, nullable: false),
                    ORDEM = table.Column<int>(nullable: false),
                    ATIVO = table.Column<bool>(nullable: false),
                    DT_CADASTRO = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropColumn(
                name: "FLG_Ativo",
                table: "Socio");
        }
    }
}
