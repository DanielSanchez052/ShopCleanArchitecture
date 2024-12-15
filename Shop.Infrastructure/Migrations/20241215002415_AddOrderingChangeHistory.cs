using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderingChangeHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderChangeHistory",
                schema: "ordering",
                columns: table => new
                {
                    Guid = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    OrderGuid = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: true),
                    OrderDetailGuid = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    PaymentTypeId = table.Column<int>(type: "int", nullable: true),
                    Source = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderChangeHistory", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_OrderChangeHistory_OrderDetail_OrderDetailGuid",
                        column: x => x.OrderDetailGuid,
                        principalSchema: "ordering",
                        principalTable: "OrderDetail",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_OrderChangeHistory_Order_OrderGuid",
                        column: x => x.OrderGuid,
                        principalSchema: "ordering",
                        principalTable: "Order",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderChangeHistory_OrderDetailGuid",
                schema: "ordering",
                table: "OrderChangeHistory",
                column: "OrderDetailGuid");

            migrationBuilder.CreateIndex(
                name: "IX_OrderChangeHistory_OrderGuid",
                schema: "ordering",
                table: "OrderChangeHistory",
                column: "OrderGuid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderChangeHistory",
                schema: "ordering");
        }
    }
}
