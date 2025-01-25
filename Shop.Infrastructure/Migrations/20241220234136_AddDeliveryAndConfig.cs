using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDeliveryAndConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "delivery");

            migrationBuilder.AddColumn<int>(
                name: "DeliveryProviderId",
                schema: "catalog",
                table: "ProgramProduct",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Config",
                schema: "catalog",
                table: "ProductType",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "DeliveryProvider",
                schema: "delivery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(155)", maxLength: 155, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Config = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryProvider", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProgramProduct_DeliveryProviderId",
                schema: "catalog",
                table: "ProgramProduct",
                column: "DeliveryProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramProduct_DeliveryProvider_DeliveryProviderId",
                schema: "catalog",
                table: "ProgramProduct",
                column: "DeliveryProviderId",
                principalSchema: "delivery",
                principalTable: "DeliveryProvider",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgramProduct_DeliveryProvider_DeliveryProviderId",
                schema: "catalog",
                table: "ProgramProduct");

            migrationBuilder.DropTable(
                name: "DeliveryProvider",
                schema: "delivery");

            migrationBuilder.DropIndex(
                name: "IX_ProgramProduct_DeliveryProviderId",
                schema: "catalog",
                table: "ProgramProduct");

            migrationBuilder.DropColumn(
                name: "DeliveryProviderId",
                schema: "catalog",
                table: "ProgramProduct");

            migrationBuilder.AlterColumn<string>(
                name: "Config",
                schema: "catalog",
                table: "ProductType",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
