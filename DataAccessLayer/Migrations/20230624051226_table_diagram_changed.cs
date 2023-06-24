using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class table_diagram_changed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Currents_Transactions_TransactionID",
                table: "Currents");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Transactions_TransactionID",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_Transactions_TransactionID",
                table: "Staffs");

            migrationBuilder.DropIndex(
                name: "IX_Staffs_TransactionID",
                table: "Staffs");

            migrationBuilder.DropIndex(
                name: "IX_Products_TransactionID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Currents_TransactionID",
                table: "Currents");

            migrationBuilder.DropColumn(
                name: "TransactionID",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "TransactionID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TransactionID",
                table: "Currents");

            migrationBuilder.AddColumn<int>(
                name: "CurrentID",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductID",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StaffID",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CurrentID",
                table: "Transactions",
                column: "CurrentID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ProductID",
                table: "Transactions",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_StaffID",
                table: "Transactions",
                column: "StaffID");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Currents_CurrentID",
                table: "Transactions",
                column: "CurrentID",
                principalTable: "Currents",
                principalColumn: "CurrentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Products_ProductID",
                table: "Transactions",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Staffs_StaffID",
                table: "Transactions",
                column: "StaffID",
                principalTable: "Staffs",
                principalColumn: "StaffID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Currents_CurrentID",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Products_ProductID",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Staffs_StaffID",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_CurrentID",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_ProductID",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_StaffID",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "CurrentID",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "StaffID",
                table: "Transactions");

            migrationBuilder.AddColumn<int>(
                name: "TransactionID",
                table: "Staffs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TransactionID",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TransactionID",
                table: "Currents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_TransactionID",
                table: "Staffs",
                column: "TransactionID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_TransactionID",
                table: "Products",
                column: "TransactionID");

            migrationBuilder.CreateIndex(
                name: "IX_Currents_TransactionID",
                table: "Currents",
                column: "TransactionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Currents_Transactions_TransactionID",
                table: "Currents",
                column: "TransactionID",
                principalTable: "Transactions",
                principalColumn: "TransactionID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Transactions_TransactionID",
                table: "Products",
                column: "TransactionID",
                principalTable: "Transactions",
                principalColumn: "TransactionID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_Transactions_TransactionID",
                table: "Staffs",
                column: "TransactionID",
                principalTable: "Transactions",
                principalColumn: "TransactionID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
