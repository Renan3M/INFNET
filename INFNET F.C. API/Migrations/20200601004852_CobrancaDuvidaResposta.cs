using Microsoft.EntityFrameworkCore.Migrations;

namespace INFNET_F.C._API.Migrations
{
    public partial class CobrancaDuvidaResposta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cobranca",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDASSINATURA_FKID = table.Column<int>(nullable: false),
                    NumeroParcelas = table.Column<int>(nullable: false),
                    ValorParcelas = table.Column<double>(nullable: false),
                    isRecorrente = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cobranca", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cobranca_Assinatura_IDASSINATURA_FKID",
                        column: x => x.IDASSINATURA_FKID,
                        principalTable: "Assinatura",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Duvida",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDSOCIO_FKID = table.Column<int>(nullable: false),
                    Assunto = table.Column<string>(maxLength: 150, nullable: false),
                    Mensagem = table.Column<string>(maxLength: 600, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Duvida", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Duvida_Socio_IDSOCIO_FKID",
                        column: x => x.IDSOCIO_FKID,
                        principalTable: "Socio",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Resposta",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDDUVIDA_FKID = table.Column<int>(nullable: false),
                    Mensagem = table.Column<string>(maxLength: 600, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resposta", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Resposta_Duvida_IDDUVIDA_FKID",
                        column: x => x.IDDUVIDA_FKID,
                        principalTable: "Duvida",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cobranca_IDASSINATURA_FKID",
                table: "Cobranca",
                column: "IDASSINATURA_FKID");

            migrationBuilder.CreateIndex(
                name: "IX_Duvida_IDSOCIO_FKID",
                table: "Duvida",
                column: "IDSOCIO_FKID");

            migrationBuilder.CreateIndex(
                name: "IX_Resposta_IDDUVIDA_FKID",
                table: "Resposta",
                column: "IDDUVIDA_FKID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cobranca");

            migrationBuilder.DropTable(
                name: "Resposta");

            migrationBuilder.DropTable(
                name: "Duvida");
        }
    }
}
