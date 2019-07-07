using Microsoft.EntityFrameworkCore.Migrations;

namespace Ivteks72.Data.Migrations
{
    public partial class AddedQuantityCollumnInClothingEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Clothings",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Clothings");
        }
    }
}
