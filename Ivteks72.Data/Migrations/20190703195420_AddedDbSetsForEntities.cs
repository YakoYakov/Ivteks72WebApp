using Microsoft.EntityFrameworkCore.Migrations;

namespace Ivteks72.Data.Migrations
{
    public partial class AddedDbSetsForEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Company_CompanyId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_AspNetUsers_BIlledToId",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Clothing_ClothingId",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Order_OrderId",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Clothing_ClothingId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_AspNetUsers_IssuerId",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invoice",
                table: "Invoice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Company",
                table: "Company");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clothing",
                table: "Clothing");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "Invoice",
                newName: "Invoices");

            migrationBuilder.RenameTable(
                name: "Company",
                newName: "Companies");

            migrationBuilder.RenameTable(
                name: "Clothing",
                newName: "Clothings");

            migrationBuilder.RenameIndex(
                name: "IX_Order_IssuerId",
                table: "Orders",
                newName: "IX_Orders_IssuerId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_ClothingId",
                table: "Orders",
                newName: "IX_Orders_ClothingId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoice_OrderId",
                table: "Invoices",
                newName: "IX_Invoices_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoice_ClothingId",
                table: "Invoices",
                newName: "IX_Invoices_ClothingId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoice_BIlledToId",
                table: "Invoices",
                newName: "IX_Invoices_BIlledToId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invoices",
                table: "Invoices",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clothings",
                table: "Clothings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Companies_CompanyId",
                table: "AspNetUsers",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_AspNetUsers_BIlledToId",
                table: "Invoices",
                column: "BIlledToId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Clothings_ClothingId",
                table: "Invoices",
                column: "ClothingId",
                principalTable: "Clothings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Orders_OrderId",
                table: "Invoices",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Clothings_ClothingId",
                table: "Orders",
                column: "ClothingId",
                principalTable: "Clothings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_IssuerId",
                table: "Orders",
                column: "IssuerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Companies_CompanyId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_AspNetUsers_BIlledToId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Clothings_ClothingId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Orders_OrderId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Clothings_ClothingId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_IssuerId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invoices",
                table: "Invoices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clothings",
                table: "Clothings");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.RenameTable(
                name: "Invoices",
                newName: "Invoice");

            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "Company");

            migrationBuilder.RenameTable(
                name: "Clothings",
                newName: "Clothing");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_IssuerId",
                table: "Order",
                newName: "IX_Order_IssuerId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_ClothingId",
                table: "Order",
                newName: "IX_Order_ClothingId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_OrderId",
                table: "Invoice",
                newName: "IX_Invoice_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_ClothingId",
                table: "Invoice",
                newName: "IX_Invoice_ClothingId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_BIlledToId",
                table: "Invoice",
                newName: "IX_Invoice_BIlledToId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invoice",
                table: "Invoice",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Company",
                table: "Company",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clothing",
                table: "Clothing",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Company_CompanyId",
                table: "AspNetUsers",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_AspNetUsers_BIlledToId",
                table: "Invoice",
                column: "BIlledToId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Clothing_ClothingId",
                table: "Invoice",
                column: "ClothingId",
                principalTable: "Clothing",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Order_OrderId",
                table: "Invoice",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Clothing_ClothingId",
                table: "Order",
                column: "ClothingId",
                principalTable: "Clothing",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_AspNetUsers_IssuerId",
                table: "Order",
                column: "IssuerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
