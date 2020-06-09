using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace INFNET_F.C._API.Migrations
{
    public partial class AssinaturaRelacionamentoPartidaCampeonatoEstadioTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campeonato",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campeonato", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Estadio",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estadio", x => x.ID);
                });

           
          
            migrationBuilder.CreateTable(
                name: "TimeFutebol",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME = table.Column<string>(maxLength: 150, nullable: false),
                    ESCUDO = table.Column<string>(maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeFutebol", x => x.ID);
                });

           


            migrationBuilder.CreateTable(
                name: "Partida",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DT_CADASTRO = table.Column<DateTime>(nullable: false),
                    DESCR_PARTIDA = table.Column<string>(maxLength: 400, nullable: false),
                    DT_PARTIDA = table.Column<DateTime>(nullable: false),
                    IDMANDANTE_FK = table.Column<int>(nullable: false),
                    IDVISITANTE_FK = table.Column<int>(nullable: false),
                    IDCAMPEONATO_FK = table.Column<int>(nullable: false),
                    IDESTADIO_FK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partida", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Partida_Campeonato_IDCAMPEONATO_FK",
                        column: x => x.IDCAMPEONATO_FK,
                        principalTable: "Campeonato",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Partida_Estadio_IDESTADIO_FK",
                        column: x => x.IDESTADIO_FK,
                        principalTable: "Estadio",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Partida_TimeFutebol_IDMANDANTE_FK",
                        column: x => x.IDMANDANTE_FK,
                        principalTable: "TimeFutebol",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Partida_TimeFutebol_IDVISITANTE_FK",
                        column: x => x.IDVISITANTE_FK,
                        principalTable: "TimeFutebol",
                        principalColumn: "ID");
                });

           
          

            migrationBuilder.CreateTable(
                name: "AssinaturaPartida",
                columns: table => new
                {
                    AssinaturaId = table.Column<int>(nullable: false),
                    PartidaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssinaturaPartida", x => new { x.AssinaturaId, x.PartidaId });
                    table.ForeignKey(
                        name: "FK_AssinaturaPartida_Assinatura_AssinaturaId",
                        column: x => x.AssinaturaId,
                        principalTable: "Assinatura",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssinaturaPartida_Partida_PartidaId",
                        column: x => x.PartidaId,
                        principalTable: "Partida",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

          

         

            migrationBuilder.CreateIndex(
                name: "IX_AssinaturaPartida_PartidaId",
                table: "AssinaturaPartida",
                column: "PartidaId");

            

          

            migrationBuilder.CreateIndex(
                name: "IX_Partida_IDCAMPEONATO_FK",
                table: "Partida",
                column: "IDCAMPEONATO_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Partida_IDESTADIO_FK",
                table: "Partida",
                column: "IDESTADIO_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Partida_IDMANDANTE_FK",
                table: "Partida",
                column: "IDMANDANTE_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Partida_IDVISITANTE_FK",
                table: "Partida",
                column: "IDVISITANTE_FK");

       
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssinaturaPartida");

         
            migrationBuilder.DropTable(
                name: "Partida");


            migrationBuilder.DropTable(
                name: "Campeonato");

            migrationBuilder.DropTable(
                name: "Estadio");

            migrationBuilder.DropTable(
                name: "TimeFutebol");

 
        }
    }
}
