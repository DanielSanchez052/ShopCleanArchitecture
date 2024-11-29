using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MakeReferenceFieldRequired : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "catalog",
                table: "ProgramProductReference",
                type: "nvarchar(155)",
                maxLength: 155,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(155)",
                oldMaxLength: 155,
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "catalog",
                table: "ProgramProductReference",
                type: "nvarchar(155)",
                maxLength: 155,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(155)",
                oldMaxLength: 155);
        }
    }
}
