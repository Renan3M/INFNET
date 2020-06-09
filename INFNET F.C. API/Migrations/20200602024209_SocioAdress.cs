using Microsoft.EntityFrameworkCore.Migrations;

namespace INFNET_F.C._API.Migrations
{
    public partial class SocioAdress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Senha",
                table: "Socio");

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Socio",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Pais",
                table: "Socio",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Rua",
                table: "Socio",
                maxLength: 250,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Socio");

            migrationBuilder.DropColumn(
                name: "Pais",
                table: "Socio");

            migrationBuilder.DropColumn(
                name: "Rua",
                table: "Socio");

            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "Socio",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
