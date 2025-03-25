using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyInOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Program_ProgramId",
                schema: "ordering",
                table: "Order");

            migrationBuilder.AlterColumn<int>(
                name: "ProgramId",
                schema: "ordering",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Program_ProgramId",
                schema: "ordering",
                table: "Order",
                column: "ProgramId",
                principalSchema: "config",
                principalTable: "Program",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Program_ProgramId",
                schema: "ordering",
                table: "Order");

            migrationBuilder.AlterColumn<int>(
                name: "ProgramId",
                schema: "ordering",
                table: "Order",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Program_ProgramId",
                schema: "ordering",
                table: "Order",
                column: "ProgramId",
                principalSchema: "config",
                principalTable: "Program",
                principalColumn: "Id");
        }
    }
}
