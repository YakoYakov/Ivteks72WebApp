using Microsoft.EntityFrameworkCore.Migrations;

namespace Ivteks72.Data.Migrations
{
    public partial class AddedRowNamedNumberToTheInvoiceTableThatAutoincrements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateSequence<int>(
                name: "Invoice_seq",
                schema: "dbo");

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Invoices",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR dbo.Invoice_seq");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSequence(
                name: "Invoice_seq",
                schema: "dbo");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Invoices");
        }
    }
}
