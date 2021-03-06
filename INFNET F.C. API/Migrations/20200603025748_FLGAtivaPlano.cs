﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace INFNET_F.C._API.Migrations
{
    public partial class FLGAtivaPlano : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "FLG_ATIVA",
                table: "Assinatura",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FLG_ATIVA",
                table: "Assinatura");
        }
    }
}
