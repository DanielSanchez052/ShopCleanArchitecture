using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "customer");

            migrationBuilder.EnsureSchema(
                name: "catalog");

            migrationBuilder.EnsureSchema(
                name: "digital");

            migrationBuilder.EnsureSchema(
                name: "ordering");

            migrationBuilder.EnsureSchema(
                name: "config");

            migrationBuilder.CreateTable(
                name: "Account",
                schema: "customer",
                columns: table => new
                {
                    Guid = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "ExpirationType",
                schema: "digital",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Config = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpirationType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetailStatus",
                schema: "ordering",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetailStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatus",
                schema: "ordering",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentType",
                schema: "ordering",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Provider = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Config = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductType",
                schema: "catalog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Config = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Program",
                schema: "config",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Config = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Program", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                schema: "customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountGuid = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    City = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    State = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    HouseNumber = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Account_AccountGuid",
                        column: x => x.AccountGuid,
                        principalSchema: "customer",
                        principalTable: "Account",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "catalog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ProgramId = table.Column<int>(type: "int", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Category_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "catalog",
                        principalTable: "Category",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Category_Program_ProgramId",
                        column: x => x.ProgramId,
                        principalSchema: "config",
                        principalTable: "Program",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                schema: "ordering",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    AddressId = table.Column<int>(type: "int", maxLength: 36, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AproveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AccountGuid = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    PaymentTypeId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Account_AccountGuid",
                        column: x => x.AccountGuid,
                        principalSchema: "customer",
                        principalTable: "Account",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_Order_Address_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "customer",
                        principalTable: "Address",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Order_OrderStatus_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "ordering",
                        principalTable: "OrderStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_PaymentType_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalSchema: "ordering",
                        principalTable: "PaymentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "catalog",
                columns: table => new
                {
                    Guid = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    ProductCode = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ProductTypeId = table.Column<int>(type: "int", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LongDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Terms = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Conditions = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Instructions = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    NominalValue = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "catalog",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_ProductType_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalSchema: "catalog",
                        principalTable: "ProductType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProgramProduct",
                schema: "config",
                columns: table => new
                {
                    Guid = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    ProductGuid = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    ProgramId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LongDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Terms = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Conditions = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Instructions = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    NominalValue = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: true),
                    Segment = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    BasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Iva = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BaseCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramProduct", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_ProgramProduct_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "catalog",
                        principalTable: "Category",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProgramProduct_Product_ProductGuid",
                        column: x => x.ProductGuid,
                        principalSchema: "catalog",
                        principalTable: "Product",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_ProgramProduct_Program_ProgramId",
                        column: x => x.ProgramId,
                        principalSchema: "config",
                        principalTable: "Program",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductImage",
                schema: "catalog",
                columns: table => new
                {
                    Guid = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    BaseUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsSmall = table.Column<bool>(type: "bit", nullable: false),
                    ProductGuid = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImage", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_ProductImage_ProgramProduct_ProductGuid",
                        column: x => x.ProductGuid,
                        principalSchema: "config",
                        principalTable: "ProgramProduct",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProgramProductReference",
                schema: "catalog",
                columns: table => new
                {
                    Guid = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    ProgramProductGuid = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    Inventory = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Available = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramProductReference", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_ProgramProductReference_ProgramProduct_ProgramProductGuid",
                        column: x => x.ProgramProductGuid,
                        principalSchema: "config",
                        principalTable: "ProgramProduct",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Code",
                schema: "digital",
                columns: table => new
                {
                    Guid = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    ProductReferenceGuid = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    DigitalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Used = table.Column<bool>(type: "bit", nullable: false),
                    UsedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationTypeId = table.Column<int>(type: "int", nullable: false),
                    Expiration = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Code", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Code_ExpirationType_ExpirationTypeId",
                        column: x => x.ExpirationTypeId,
                        principalSchema: "digital",
                        principalTable: "ExpirationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Code_ProgramProductReference_ProductReferenceGuid",
                        column: x => x.ProductReferenceGuid,
                        principalSchema: "catalog",
                        principalTable: "ProgramProductReference",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                schema: "ordering",
                columns: table => new
                {
                    Guid = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    OrderDetailStatusId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    ProductReferenceGuid = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_OrderDetail_OrderDetailStatus_OrderDetailStatusId",
                        column: x => x.OrderDetailStatusId,
                        principalSchema: "ordering",
                        principalTable: "OrderDetailStatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderDetail_Order_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "ordering",
                        principalTable: "Order",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderDetail_ProgramProductReference_ProductReferenceGuid",
                        column: x => x.ProductReferenceGuid,
                        principalSchema: "catalog",
                        principalTable: "ProgramProductReference",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_AccountGuid",
                schema: "customer",
                table: "Address",
                column: "AccountGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Category_ParentId",
                schema: "catalog",
                table: "Category",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_ProgramId",
                schema: "catalog",
                table: "Category",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_Code_ExpirationTypeId",
                schema: "digital",
                table: "Code",
                column: "ExpirationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Code_ProductReferenceGuid",
                schema: "digital",
                table: "Code",
                column: "ProductReferenceGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Order_AccountGuid",
                schema: "ordering",
                table: "Order",
                column: "AccountGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Order_AddressId",
                schema: "ordering",
                table: "Order",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_PaymentTypeId",
                schema: "ordering",
                table: "Order",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_StatusId",
                schema: "ordering",
                table: "Order",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderDetailStatusId",
                schema: "ordering",
                table: "OrderDetail",
                column: "OrderDetailStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderId",
                schema: "ordering",
                table: "OrderDetail",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_ProductReferenceGuid",
                schema: "ordering",
                table: "OrderDetail",
                column: "ProductReferenceGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                schema: "catalog",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductTypeId",
                schema: "catalog",
                table: "Product",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImage_ProductGuid",
                schema: "catalog",
                table: "ProductImage",
                column: "ProductGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramProduct_CategoryId",
                schema: "config",
                table: "ProgramProduct",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramProduct_ProductGuid",
                schema: "config",
                table: "ProgramProduct",
                column: "ProductGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramProduct_ProgramId",
                schema: "config",
                table: "ProgramProduct",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramProductReference_ProgramProductGuid",
                schema: "catalog",
                table: "ProgramProductReference",
                column: "ProgramProductGuid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Code",
                schema: "digital");

            migrationBuilder.DropTable(
                name: "OrderDetail",
                schema: "ordering");

            migrationBuilder.DropTable(
                name: "ProductImage",
                schema: "catalog");

            migrationBuilder.DropTable(
                name: "ExpirationType",
                schema: "digital");

            migrationBuilder.DropTable(
                name: "OrderDetailStatus",
                schema: "ordering");

            migrationBuilder.DropTable(
                name: "Order",
                schema: "ordering");

            migrationBuilder.DropTable(
                name: "ProgramProductReference",
                schema: "catalog");

            migrationBuilder.DropTable(
                name: "Address",
                schema: "customer");

            migrationBuilder.DropTable(
                name: "OrderStatus",
                schema: "ordering");

            migrationBuilder.DropTable(
                name: "PaymentType",
                schema: "ordering");

            migrationBuilder.DropTable(
                name: "ProgramProduct",
                schema: "config");

            migrationBuilder.DropTable(
                name: "Account",
                schema: "customer");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "catalog");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "catalog");

            migrationBuilder.DropTable(
                name: "ProductType",
                schema: "catalog");

            migrationBuilder.DropTable(
                name: "Program",
                schema: "config");
        }
    }
}
