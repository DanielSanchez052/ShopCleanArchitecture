using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCartTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Cart");

            migrationBuilder.CreateTable(
                name: "Cart",
                schema: "Cart",
                columns: table => new
                {
                    Guid = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "CartItem",
                schema: "Cart",
                columns: table => new
                {
                    Guid = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    CartGuid = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    ReferenceGuid = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItem", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_CartItem_Cart_CartGuid",
                        column: x => x.CartGuid,
                        principalSchema: "Cart",
                        principalTable: "Cart",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItem_ProgramProductReference_ReferenceGuid",
                        column: x => x.ReferenceGuid,
                        principalSchema: "catalog",
                        principalTable: "ProgramProductReference",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_CartGuid",
                schema: "Cart",
                table: "CartItem",
                column: "CartGuid");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_ReferenceGuid",
                schema: "Cart",
                table: "CartItem",
                column: "ReferenceGuid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItem",
                schema: "Cart");

            migrationBuilder.DropTable(
                name: "Cart",
                schema: "Cart");
        }
    }
}
