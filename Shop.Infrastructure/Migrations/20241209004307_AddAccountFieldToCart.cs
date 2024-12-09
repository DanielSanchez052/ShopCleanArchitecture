using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAccountFieldToCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccountGuid",
                schema: "Cart",
                table: "Cart",
                type: "nvarchar(36)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_AccountGuid",
                schema: "Cart",
                table: "Cart",
                column: "AccountGuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Account_AccountGuid",
                schema: "Cart",
                table: "Cart",
                column: "AccountGuid",
                principalSchema: "customer",
                principalTable: "Account",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Account_AccountGuid",
                schema: "Cart",
                table: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_Cart_AccountGuid",
                schema: "Cart",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "AccountGuid",
                schema: "Cart",
                table: "Cart");
        }
    }
}
