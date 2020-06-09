using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace INFNET_F.C._API.Migrations
{
    public partial class PlanoAssinatura : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assinatura",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDSOCIO_FKID = table.Column<int>(nullable: false),
                    IDPLANO_FKID = table.Column<int>(nullable: false),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assinatura", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Assinatura_Plano_IDPLANO_FKID",
                        column: x => x.IDPLANO_FKID,
                        principalTable: "Plano",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assinatura_Socio_IDSOCIO_FKID",
                        column: x => x.IDSOCIO_FKID,
                        principalTable: "Socio",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assinatura_IDPLANO_FKID",
                table: "Assinatura",
                column: "IDPLANO_FKID");

            migrationBuilder.CreateIndex(
                name: "IX_Assinatura_IDSOCIO_FKID",
                table: "Assinatura",
                column: "IDSOCIO_FKID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assinatura");
        }
    }
}
