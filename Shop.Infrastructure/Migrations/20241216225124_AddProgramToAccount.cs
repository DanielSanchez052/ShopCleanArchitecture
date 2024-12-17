using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddProgramToAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProgramId",
                schema: "customer",
                table: "Account",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Account_ProgramId",
                schema: "customer",
                table: "Account",
                column: "ProgramId");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Program_ProgramId",
                schema: "customer",
                table: "Account",
                column: "ProgramId",
                principalSchema: "config",
                principalTable: "Program",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Program_ProgramId",
                schema: "customer",
                table: "Account");

            migrationBuilder.DropIndex(
                name: "IX_Account_ProgramId",
                schema: "customer",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "ProgramId",
                schema: "customer",
                table: "Account");
        }
    }
}
