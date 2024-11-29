using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddReferenceFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AditionalData",
                schema: "catalog",
                table: "ProgramProductReference",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "catalog",
                table: "ProgramProductReference",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "catalog",
                table: "ProgramProductReference",
                type: "nvarchar(155)",
                maxLength: 155,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AditionalData",
                schema: "catalog",
                table: "ProgramProductReference");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "catalog",
                table: "ProgramProductReference");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "catalog",
                table: "ProgramProductReference");
        }
    }
}
