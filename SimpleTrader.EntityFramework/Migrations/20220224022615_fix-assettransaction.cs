using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleTrader.EntityFramework.Migrations
{
    public partial class fixassettransaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetTransactions_Accounts_AccoubtId",
                table: "AssetTransactions");

            migrationBuilder.DropIndex(
                name: "IX_AssetTransactions_AccoubtId",
                table: "AssetTransactions");

            migrationBuilder.DropColumn(
                name: "AccoubtId",
                table: "AssetTransactions");

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "AssetTransactions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssetTransactions_AccountId",
                table: "AssetTransactions",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetTransactions_Accounts_AccountId",
                table: "AssetTransactions",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetTransactions_Accounts_AccountId",
                table: "AssetTransactions");

            migrationBuilder.DropIndex(
                name: "IX_AssetTransactions_AccountId",
                table: "AssetTransactions");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "AssetTransactions");

            migrationBuilder.AddColumn<int>(
                name: "AccoubtId",
                table: "AssetTransactions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssetTransactions_AccoubtId",
                table: "AssetTransactions",
                column: "AccoubtId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetTransactions_Accounts_AccoubtId",
                table: "AssetTransactions",
                column: "AccoubtId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
