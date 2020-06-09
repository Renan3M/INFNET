using Microsoft.EntityFrameworkCore.Migrations;

namespace INFNET_F.C._API.Migrations
{
    public partial class AdicionandoFKKeyId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assinatura_Plano_IDPLANO_FKID",
                table: "Assinatura");

            migrationBuilder.DropForeignKey(
                name: "FK_Assinatura_Socio_IDSOCIO_FKID",
                table: "Assinatura");

            migrationBuilder.DropForeignKey(
                name: "FK_Cobranca_Assinatura_IDASSINATURA_FKID",
                table: "Cobranca");

            migrationBuilder.DropForeignKey(
                name: "FK_Duvida_Socio_IDSOCIO_FKID",
                table: "Duvida");

            migrationBuilder.DropForeignKey(
                name: "FK_Resposta_Duvida_IDDUVIDA_FKID",
                table: "Resposta");

            migrationBuilder.DropIndex(
                name: "IX_Resposta_IDDUVIDA_FKID",
                table: "Resposta");

            migrationBuilder.DropIndex(
                name: "IX_Duvida_IDSOCIO_FKID",
                table: "Duvida");

            migrationBuilder.DropIndex(
                name: "IX_Cobranca_IDASSINATURA_FKID",
                table: "Cobranca");

            migrationBuilder.DropIndex(
                name: "IX_Assinatura_IDPLANO_FKID",
                table: "Assinatura");

            migrationBuilder.DropIndex(
                name: "IX_Assinatura_IDSOCIO_FKID",
                table: "Assinatura");

            migrationBuilder.DropColumn(
                name: "IDDUVIDA_FKID",
                table: "Resposta");

            migrationBuilder.DropColumn(
                name: "IDSOCIO_FKID",
                table: "Duvida");

            migrationBuilder.DropColumn(
                name: "IDASSINATURA_FKID",
                table: "Cobranca");

            migrationBuilder.DropColumn(
                name: "IDPLANO_FKID",
                table: "Assinatura");

            migrationBuilder.DropColumn(
                name: "IDSOCIO_FKID",
                table: "Assinatura");

            migrationBuilder.AddColumn<int>(
                name: "IDDUVIDA_FK",
                table: "Resposta",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IDSOCIO_FK",
                table: "Duvida",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IDASSINATURA_FK",
                table: "Cobranca",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IDPLANO_FK",
                table: "Assinatura",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IDSOCIO_FK",
                table: "Assinatura",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Resposta_IDDUVIDA_FK",
                table: "Resposta",
                column: "IDDUVIDA_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Duvida_IDSOCIO_FK",
                table: "Duvida",
                column: "IDSOCIO_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Cobranca_IDASSINATURA_FK",
                table: "Cobranca",
                column: "IDASSINATURA_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Assinatura_IDPLANO_FK",
                table: "Assinatura",
                column: "IDPLANO_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Assinatura_IDSOCIO_FK",
                table: "Assinatura",
                column: "IDSOCIO_FK");

            migrationBuilder.AddForeignKey(
                name: "FK_Assinatura_Plano_IDPLANO_FK",
                table: "Assinatura",
                column: "IDPLANO_FK",
                principalTable: "Plano",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assinatura_Socio_IDSOCIO_FK",
                table: "Assinatura",
                column: "IDSOCIO_FK",
                principalTable: "Socio",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cobranca_Assinatura_IDASSINATURA_FK",
                table: "Cobranca",
                column: "IDASSINATURA_FK",
                principalTable: "Assinatura",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Duvida_Socio_IDSOCIO_FK",
                table: "Duvida",
                column: "IDSOCIO_FK",
                principalTable: "Socio",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Resposta_Duvida_IDDUVIDA_FK",
                table: "Resposta",
                column: "IDDUVIDA_FK",
                principalTable: "Duvida",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assinatura_Plano_IDPLANO_FK",
                table: "Assinatura");

            migrationBuilder.DropForeignKey(
                name: "FK_Assinatura_Socio_IDSOCIO_FK",
                table: "Assinatura");

            migrationBuilder.DropForeignKey(
                name: "FK_Cobranca_Assinatura_IDASSINATURA_FK",
                table: "Cobranca");

            migrationBuilder.DropForeignKey(
                name: "FK_Duvida_Socio_IDSOCIO_FK",
                table: "Duvida");

            migrationBuilder.DropForeignKey(
                name: "FK_Resposta_Duvida_IDDUVIDA_FK",
                table: "Resposta");

            migrationBuilder.DropIndex(
                name: "IX_Resposta_IDDUVIDA_FK",
                table: "Resposta");

            migrationBuilder.DropIndex(
                name: "IX_Duvida_IDSOCIO_FK",
                table: "Duvida");

            migrationBuilder.DropIndex(
                name: "IX_Cobranca_IDASSINATURA_FK",
                table: "Cobranca");

            migrationBuilder.DropIndex(
                name: "IX_Assinatura_IDPLANO_FK",
                table: "Assinatura");

            migrationBuilder.DropIndex(
                name: "IX_Assinatura_IDSOCIO_FK",
                table: "Assinatura");

            migrationBuilder.DropColumn(
                name: "IDDUVIDA_FK",
                table: "Resposta");

            migrationBuilder.DropColumn(
                name: "IDSOCIO_FK",
                table: "Duvida");

            migrationBuilder.DropColumn(
                name: "IDASSINATURA_FK",
                table: "Cobranca");

            migrationBuilder.DropColumn(
                name: "IDPLANO_FK",
                table: "Assinatura");

            migrationBuilder.DropColumn(
                name: "IDSOCIO_FK",
                table: "Assinatura");

            migrationBuilder.AddColumn<int>(
                name: "IDDUVIDA_FKID",
                table: "Resposta",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IDSOCIO_FKID",
                table: "Duvida",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IDASSINATURA_FKID",
                table: "Cobranca",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IDPLANO_FKID",
                table: "Assinatura",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IDSOCIO_FKID",
                table: "Assinatura",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Resposta_IDDUVIDA_FKID",
                table: "Resposta",
                column: "IDDUVIDA_FKID");

            migrationBuilder.CreateIndex(
                name: "IX_Duvida_IDSOCIO_FKID",
                table: "Duvida",
                column: "IDSOCIO_FKID");

            migrationBuilder.CreateIndex(
                name: "IX_Cobranca_IDASSINATURA_FKID",
                table: "Cobranca",
                column: "IDASSINATURA_FKID");

            migrationBuilder.CreateIndex(
                name: "IX_Assinatura_IDPLANO_FKID",
                table: "Assinatura",
                column: "IDPLANO_FKID");

            migrationBuilder.CreateIndex(
                name: "IX_Assinatura_IDSOCIO_FKID",
                table: "Assinatura",
                column: "IDSOCIO_FKID");

            migrationBuilder.AddForeignKey(
                name: "FK_Assinatura_Plano_IDPLANO_FKID",
                table: "Assinatura",
                column: "IDPLANO_FKID",
                principalTable: "Plano",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assinatura_Socio_IDSOCIO_FKID",
                table: "Assinatura",
                column: "IDSOCIO_FKID",
                principalTable: "Socio",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cobranca_Assinatura_IDASSINATURA_FKID",
                table: "Cobranca",
                column: "IDASSINATURA_FKID",
                principalTable: "Assinatura",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Duvida_Socio_IDSOCIO_FKID",
                table: "Duvida",
                column: "IDSOCIO_FKID",
                principalTable: "Socio",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Resposta_Duvida_IDDUVIDA_FKID",
                table: "Resposta",
                column: "IDDUVIDA_FKID",
                principalTable: "Duvida",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
