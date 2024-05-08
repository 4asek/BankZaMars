using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class Chicha : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Customer_CustomerId",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Account_AccountId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Cards_CardId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_AccountId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "CardId",
                table: "Transactions",
                newName: "CardID");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_CardId",
                table: "Transactions",
                newName: "IX_Transactions_CardID");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Account",
                newName: "CustomerID");

            migrationBuilder.RenameIndex(
                name: "IX_Account_CustomerId",
                table: "Account",
                newName: "IX_Account_CustomerID");

            migrationBuilder.AddColumn<Guid>(
                name: "AccID",
                table: "Transactions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Account",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Account",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Account",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Account",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Customer_CustomerID",
                table: "Account",
                column: "CustomerID",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Cards_CardID",
                table: "Transactions",
                column: "CardID",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Customer_CustomerID",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Cards_CardID",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "AccID",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Account");

            migrationBuilder.RenameColumn(
                name: "CardID",
                table: "Transactions",
                newName: "CardId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_CardID",
                table: "Transactions",
                newName: "IX_Transactions_CardId");

            migrationBuilder.RenameColumn(
                name: "CustomerID",
                table: "Account",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Account_CustomerID",
                table: "Account",
                newName: "IX_Account_CustomerId");

            migrationBuilder.AddColumn<Guid>(
                name: "AccountId",
                table: "Transactions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AccountId",
                table: "Transactions",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Customer_CustomerId",
                table: "Account",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Account_AccountId",
                table: "Transactions",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Cards_CardId",
                table: "Transactions",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
