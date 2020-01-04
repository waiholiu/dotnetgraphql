using Microsoft.EntityFrameworkCore.Migrations;

namespace app.Migrations
{
    public partial class salesinvoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesInvoice_Books_BookId",
                table: "SalesInvoice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalesInvoice",
                table: "SalesInvoice");

            migrationBuilder.RenameTable(
                name: "SalesInvoice",
                newName: "SalesInvoices");

            migrationBuilder.RenameIndex(
                name: "IX_SalesInvoice_BookId",
                table: "SalesInvoices",
                newName: "IX_SalesInvoices_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalesInvoices",
                table: "SalesInvoices",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesInvoices_Books_BookId",
                table: "SalesInvoices",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesInvoices_Books_BookId",
                table: "SalesInvoices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalesInvoices",
                table: "SalesInvoices");

            migrationBuilder.RenameTable(
                name: "SalesInvoices",
                newName: "SalesInvoice");

            migrationBuilder.RenameIndex(
                name: "IX_SalesInvoices_BookId",
                table: "SalesInvoice",
                newName: "IX_SalesInvoice_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalesInvoice",
                table: "SalesInvoice",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesInvoice_Books_BookId",
                table: "SalesInvoice",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
