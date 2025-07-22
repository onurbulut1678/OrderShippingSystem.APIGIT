using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderShippingSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderId1",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_OrderId1",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "OrderId1",
                table: "OrderItems");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CargoCompanyId",
                table: "Orders",
                column: "CargoCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_CargoCompanies_CargoCompanyId",
                table: "Orders",
                column: "CargoCompanyId",
                principalTable: "CargoCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_CargoCompanies_CargoCompanyId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CargoCompanyId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "OrderId1",
                table: "OrderItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId1",
                table: "OrderItems",
                column: "OrderId1");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderId1",
                table: "OrderItems",
                column: "OrderId1",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
