using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddProgramToOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DeliveryProviderId",
                schema: "catalog",
                table: "ProgramProduct",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProgramId",
                schema: "ordering",
                table: "Order",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_ProgramId",
                schema: "ordering",
                table: "Order",
                column: "ProgramId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Program_ProgramId",
                schema: "ordering",
                table: "Order",
                column: "ProgramId",
                principalSchema: "config",
                principalTable: "Program",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Program_ProgramId",
                schema: "ordering",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_ProgramId",
                schema: "ordering",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ProgramId",
                schema: "ordering",
                table: "Order");

            migrationBuilder.AlterColumn<int>(
                name: "DeliveryProviderId",
                schema: "catalog",
                table: "ProgramProduct",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
