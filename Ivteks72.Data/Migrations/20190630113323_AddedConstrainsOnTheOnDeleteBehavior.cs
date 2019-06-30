using Microsoft.EntityFrameworkCore.Migrations;

namespace Ivteks72.Data.Migrations
{
    public partial class AddedConstrainsOnTheOnDeleteBehavior : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Clothing_ClothingId",
                table: "Order");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Clothing_ClothingId",
                table: "Order",
                column: "ClothingId",
                principalTable: "Clothing",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Clothing_ClothingId",
                table: "Order");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Clothing_ClothingId",
                table: "Order",
                column: "ClothingId",
                principalTable: "Clothing",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
