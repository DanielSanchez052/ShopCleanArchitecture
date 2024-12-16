using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPointSupport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "payment");

            migrationBuilder.RenameTable(
                name: "PaymentType",
                schema: "ordering",
                newName: "PaymentType",
                newSchema: "payment");

            migrationBuilder.AddColumn<int>(
                name: "PointValue",
                schema: "catalog",
                table: "ProgramProduct",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                schema: "config",
                table: "Program",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "PaymentRules",
                schema: "payment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Factor = table.Column<decimal>(type: "decimal(10,5)", precision: 10, scale: 5, nullable: false),
                    AutoCalulated = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ProgramId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentRules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentRules_Program_ProgramId",
                        column: x => x.ProgramId,
                        principalSchema: "config",
                        principalTable: "Program",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentRules_ProgramId",
                schema: "payment",
                table: "PaymentRules",
                column: "ProgramId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentRules",
                schema: "payment");

            migrationBuilder.DropColumn(
                name: "PointValue",
                schema: "catalog",
                table: "ProgramProduct");

            migrationBuilder.DropColumn(
                name: "Slug",
                schema: "config",
                table: "Program");

            migrationBuilder.RenameTable(
                name: "PaymentType",
                schema: "payment",
                newName: "PaymentType",
                newSchema: "ordering");
        }
    }
}
