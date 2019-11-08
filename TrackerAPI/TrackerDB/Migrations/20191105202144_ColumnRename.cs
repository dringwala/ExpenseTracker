using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackerDB.Migrations
{
    public partial class ColumnRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_TransactionCategory_Category1",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "Category1",
                table: "Transactions",
                newName: "TransactionCategoryCategory");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_Category1",
                table: "Transactions",
                newName: "IX_Transactions_TransactionCategoryCategory");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_TransactionCategory_TransactionCategoryCategory",
                table: "Transactions",
                column: "TransactionCategoryCategory",
                principalTable: "TransactionCategory",
                principalColumn: "Category",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_TransactionCategory_TransactionCategoryCategory",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "TransactionCategoryCategory",
                table: "Transactions",
                newName: "Category1");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_TransactionCategoryCategory",
                table: "Transactions",
                newName: "IX_Transactions_Category1");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_TransactionCategory_Category1",
                table: "Transactions",
                column: "Category1",
                principalTable: "TransactionCategory",
                principalColumn: "Category",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
