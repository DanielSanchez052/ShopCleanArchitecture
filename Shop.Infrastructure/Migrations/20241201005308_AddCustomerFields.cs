using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomerFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RawValue",
                schema: "customer",
                table: "Address",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "customer",
                table: "Account",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                schema: "customer",
                table: "Account",
                type: "nvarchar(155)",
                maxLength: 155,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "customer",
                table: "Account",
                type: "nvarchar(155)",
                maxLength: 155,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                schema: "customer",
                table: "Account",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RawValue",
                schema: "customer",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "Email",
                schema: "customer",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "LastName",
                schema: "customer",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "customer",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                schema: "customer",
                table: "Account");
        }
    }
}
