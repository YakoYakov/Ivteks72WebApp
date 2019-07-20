using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ivteks72.Data.Migrations
{
    public partial class AddedNewTableForLinksToClothingDiagramsChangeClothingDiagramsAndCuttingPatternsToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClothingPatternsAndCuttingDiagram",
                table: "Clothings");

            migrationBuilder.AddColumn<string>(
                name: "ClothingDiagramId",
                table: "Clothings",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ClothingDiagram",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DiagramAndCuttingPatternLinkToPictures = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClothingDiagram", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clothings_ClothingDiagramId",
                table: "Clothings",
                column: "ClothingDiagramId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clothings_ClothingDiagram_ClothingDiagramId",
                table: "Clothings",
                column: "ClothingDiagramId",
                principalTable: "ClothingDiagram",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clothings_ClothingDiagram_ClothingDiagramId",
                table: "Clothings");

            migrationBuilder.DropTable(
                name: "ClothingDiagram");

            migrationBuilder.DropIndex(
                name: "IX_Clothings_ClothingDiagramId",
                table: "Clothings");

            migrationBuilder.DropColumn(
                name: "ClothingDiagramId",
                table: "Clothings");

            migrationBuilder.AddColumn<byte[]>(
                name: "ClothingPatternsAndCuttingDiagram",
                table: "Clothings",
                nullable: true);
        }
    }
}
