using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackerDB.Migrations
{
    public partial class AddStoreDetailAndTags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Banks_BankId",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Account_AccountId",
                table: "Transaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transaction",
                table: "Transaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Account",
                table: "Account");

            migrationBuilder.RenameTable(
                name: "Transaction",
                newName: "Transactions");

            migrationBuilder.RenameTable(
                name: "Account",
                newName: "Accounts");

            migrationBuilder.RenameColumn(
                name: "TransactionDate",
                table: "Transactions",
                newName: "TransactionDateTime");

            migrationBuilder.RenameColumn(
                name: "TransactionCost",
                table: "Transactions",
                newName: "TransactionAmount");

            migrationBuilder.RenameColumn(
                name: "TransactionCategory",
                table: "Transactions",
                newName: "Tags");

            migrationBuilder.RenameIndex(
                name: "IX_Transaction_AccountId",
                table: "Transactions",
                newName: "IX_Transactions_AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Account_BankId",
                table: "Accounts",
                newName: "IX_Accounts_BankId");

            migrationBuilder.AddColumn<string>(
                name: "Tags",
                table: "Banks",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "AccountId",
                table: "Transactions",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Category1",
                table: "Transactions",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "Receipt",
                table: "Transactions",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "StoreDetailId",
                table: "Transactions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StoreTransactionID",
                table: "Transactions",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Accounts",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<string>(
                name: "Tags",
                table: "Accounts",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "StoreDetails",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    StoreAddress = table.Column<string>(nullable: true),
                    Longitude = table.Column<string>(nullable: true),
                    Latitude = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    Tags = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransactionCategory",
                columns: table => new
                {
                    Category = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Credit = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionCategory", x => x.Category);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_Category1",
                table: "Transactions",
                column: "Category1");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_StoreDetailId",
                table: "Transactions",
                column: "StoreDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Banks_BankId",
                table: "Accounts",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Accounts_AccountId",
                table: "Transactions",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_TransactionCategory_Category1",
                table: "Transactions",
                column: "Category1",
                principalTable: "TransactionCategory",
                principalColumn: "Category",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_StoreDetails_StoreDetailId",
                table: "Transactions",
                column: "StoreDetailId",
                principalTable: "StoreDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Banks_BankId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_AccountId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_TransactionCategory_Category1",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_StoreDetails_StoreDetailId",
                table: "Transactions");

            migrationBuilder.DropTable(
                name: "StoreDetails");

            migrationBuilder.DropTable(
                name: "TransactionCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_Category1",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_StoreDetailId",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "Tags",
                table: "Banks");

            migrationBuilder.DropColumn(
                name: "Category1",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Receipt",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "StoreDetailId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "StoreTransactionID",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Tags",
                table: "Accounts");

            migrationBuilder.RenameTable(
                name: "Transactions",
                newName: "Transaction");

            migrationBuilder.RenameTable(
                name: "Accounts",
                newName: "Account");

            migrationBuilder.RenameColumn(
                name: "TransactionDateTime",
                table: "Transaction",
                newName: "TransactionDate");

            migrationBuilder.RenameColumn(
                name: "TransactionAmount",
                table: "Transaction",
                newName: "TransactionCost");

            migrationBuilder.RenameColumn(
                name: "Tags",
                table: "Transaction",
                newName: "TransactionCategory");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_AccountId",
                table: "Transaction",
                newName: "IX_Transaction_AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Accounts_BankId",
                table: "Account",
                newName: "IX_Account_BankId");

            migrationBuilder.AlterColumn<long>(
                name: "AccountId",
                table: "Transaction",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "UserName",
                table: "Account",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transaction",
                table: "Transaction",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Account",
                table: "Account",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Banks_BankId",
                table: "Account",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Account_AccountId",
                table: "Transaction",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
