using Microsoft.EntityFrameworkCore.Migrations;

namespace Ivteks72.Data.Migrations
{
    public partial class FixedErrorsWithClothingDiagramsRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clothings_ClothingDiagram_ClothingDiagramId",
                table: "Clothings");

            migrationBuilder.DropTable(
                name: "ClothingDiagram");

            migrationBuilder.DropIndex(
                name: "IX_Clothings_ClothingDiagramId",
                table: "Clothings");

            migrationBuilder.RenameColumn(
                name: "ClothingDiagramId",
                table: "Clothings",
                newName: "ClothingDiagramURL");

            migrationBuilder.AlterColumn<string>(
                name: "ClothingDiagramURL",
                table: "Clothings",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ClothingDiagramURL",
                table: "Clothings",
                newName: "ClothingDiagramId");

            migrationBuilder.AlterColumn<string>(
                name: "ClothingDiagramId",
                table: "Clothings",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

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
    }
}
