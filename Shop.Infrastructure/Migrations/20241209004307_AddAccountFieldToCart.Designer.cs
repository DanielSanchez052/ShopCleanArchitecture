﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shop.Infrastructure;

#nullable disable

namespace Shop.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241209004307_AddAccountFieldToCart")]
    partial class AddAccountFieldToCart
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Shop.Entities.Catalog.Category", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<int>("ProgramId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.HasIndex("ProgramId");

                    b.ToTable("Category", "catalog");
                });

            modelBuilder.Entity("Shop.Entities.Catalog.Product", b =>
                {
                    b.Property<string>("Guid")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Conditions")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Instructions")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LongDescription")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("NominalValue")
                        .HasMaxLength(55)
                        .HasColumnType("nvarchar(55)");

                    b.Property<string>("ProductCode")
                        .IsRequired()
                        .HasMaxLength(55)
                        .HasColumnType("nvarchar(55)");

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("int");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Terms")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Guid");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("Product", "catalog");
                });

            modelBuilder.Entity("Shop.Entities.Catalog.ProductImage", b =>
                {
                    b.Property<string>("Guid")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("BaseUrl")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSmall")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ProductGuid")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.HasKey("Guid");

                    b.HasIndex("ProductGuid");

                    b.ToTable("ProductImage", "catalog");
                });

            modelBuilder.Entity("Shop.Entities.Catalog.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Config")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("ProductType", "catalog");
                });

            modelBuilder.Entity("Shop.Entities.Catalog.ProgramProduct", b =>
                {
                    b.Property<string>("Guid")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<decimal>("BaseCost")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("BasePrice")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Conditions")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Instructions")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<decimal>("Iva")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("LongDescription")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("NominalValue")
                        .HasMaxLength(55)
                        .HasColumnType("nvarchar(55)");

                    b.Property<string>("ProductGuid")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<int>("ProgramId")
                        .HasColumnType("int");

                    b.Property<string>("Segment")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Terms")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Guid");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ProductGuid");

                    b.HasIndex("ProgramId");

                    b.ToTable("ProgramProduct", "catalog");
                });

            modelBuilder.Entity("Shop.Entities.Catalog.ProgramProductReference", b =>
                {
                    b.Property<string>("Guid")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("AditionalData")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("Available")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Inventory")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(155)
                        .HasColumnType("nvarchar(155)");

                    b.Property<string>("ProgramProductGuid")
                        .IsRequired()
                        .HasColumnType("nvarchar(36)");

                    b.HasKey("Guid");

                    b.HasIndex("ProgramProductGuid");

                    b.ToTable("ProgramProductReference", "catalog");
                });

            modelBuilder.Entity("Shop.Entities.Config.Program", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Config")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Program", "config");
                });

            modelBuilder.Entity("Shop.Entities.Customer.Account", b =>
                {
                    b.Property<string>("Guid")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasMaxLength(155)
                        .HasColumnType("nvarchar(155)");

                    b.Property<string>("Name")
                        .HasMaxLength(155)
                        .HasColumnType("nvarchar(155)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(155)
                        .HasColumnType("nvarchar(155)");

                    b.HasKey("Guid");

                    b.ToTable("Account", "customer");
                });

            modelBuilder.Entity("Shop.Entities.Customer.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AccountGuid")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("City")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Country")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("HouseNumber")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("bit");

                    b.Property<string>("RawValue")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("State")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Street")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("ZipCode")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("AccountGuid");

                    b.ToTable("Address", "customer");
                });

            modelBuilder.Entity("Shop.Entities.Digital.Code", b =>
                {
                    b.Property<string>("Guid")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DigitalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Expiration")
                        .IsRequired()
                        .HasMaxLength(55)
                        .HasColumnType("nvarchar(55)");

                    b.Property<int>("ExpirationTypeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ProductReferenceGuid")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<bool>("Used")
                        .HasColumnType("bit");

                    b.Property<DateTime>("UsedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Guid");

                    b.HasIndex("ExpirationTypeId");

                    b.HasIndex("ProductReferenceGuid");

                    b.ToTable("Code", "digital");
                });

            modelBuilder.Entity("Shop.Entities.Digital.ExpirationType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Config")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("ExpirationType", "digital");
                });

            modelBuilder.Entity("Shop.Entities.Ordering.Order", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(55)
                        .HasColumnType("nvarchar(55)");

                    b.Property<string>("AccountGuid")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<int?>("AddressId")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("int");

                    b.Property<DateTime?>("AproveDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PaymentTypeId")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AccountGuid");

                    b.HasIndex("AddressId");

                    b.HasIndex("PaymentTypeId");

                    b.HasIndex("StatusId");

                    b.ToTable("Order", "ordering");
                });

            modelBuilder.Entity("Shop.Entities.Ordering.OrderDetail", b =>
                {
                    b.Property<string>("Guid")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Discount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("OrderDetailStatusId")
                        .HasColumnType("int");

                    b.Property<string>("OrderId")
                        .IsRequired()
                        .HasMaxLength(55)
                        .HasColumnType("nvarchar(55)");

                    b.Property<string>("ProductReferenceGuid")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Guid");

                    b.HasIndex("OrderDetailStatusId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductReferenceGuid");

                    b.ToTable("OrderDetail", "ordering");
                });

            modelBuilder.Entity("Shop.Entities.Ordering.OrderDetailStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("OrderDetailStatus", "ordering");
                });

            modelBuilder.Entity("Shop.Entities.Ordering.OrderStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("OrderStatus", "ordering");
                });

            modelBuilder.Entity("Shop.Entities.Ordering.PaymentType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Config")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Provider")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.ToTable("PaymentType", "ordering");
                });

            modelBuilder.Entity("Shop.Entities.ShopCart.Cart", b =>
                {
                    b.Property<string>("Guid")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("AccountGuid")
                        .IsRequired()
                        .HasColumnType("nvarchar(36)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("Guid");

                    b.HasIndex("AccountGuid");

                    b.ToTable("Cart", "Cart");
                });

            modelBuilder.Entity("Shop.Entities.ShopCart.CartItem", b =>
                {
                    b.Property<string>("Guid")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("CartGuid")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("ReferenceGuid")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.HasKey("Guid");

                    b.HasIndex("CartGuid");

                    b.HasIndex("ReferenceGuid");

                    b.ToTable("CartItem", "Cart");
                });

            modelBuilder.Entity("Shop.Entities.Catalog.Category", b =>
                {
                    b.HasOne("Shop.Entities.Catalog.Category", "Parent")
                        .WithMany("ChildCategories")
                        .HasForeignKey("ParentId");

                    b.HasOne("Shop.Entities.Config.Program", "Program")
                        .WithMany("Categories")
                        .HasForeignKey("ProgramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parent");

                    b.Navigation("Program");
                });

            modelBuilder.Entity("Shop.Entities.Catalog.Product", b =>
                {
                    b.HasOne("Shop.Entities.Catalog.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shop.Entities.Catalog.ProductType", "ProductType")
                        .WithMany("Products")
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("ProductType");
                });

            modelBuilder.Entity("Shop.Entities.Catalog.ProductImage", b =>
                {
                    b.HasOne("Shop.Entities.Catalog.ProgramProduct", "Product")
                        .WithMany("ProductImages")
                        .HasForeignKey("ProductGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Shop.Entities.Catalog.ProgramProduct", b =>
                {
                    b.HasOne("Shop.Entities.Catalog.Category", "Category")
                        .WithMany("ProgramProducts")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Shop.Entities.Catalog.Product", "Product")
                        .WithMany("ProgramProducts")
                        .HasForeignKey("ProductGuid")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Shop.Entities.Config.Program", "Program")
                        .WithMany("ProgramProducts")
                        .HasForeignKey("ProgramId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");

                    b.Navigation("Program");
                });

            modelBuilder.Entity("Shop.Entities.Catalog.ProgramProductReference", b =>
                {
                    b.HasOne("Shop.Entities.Catalog.ProgramProduct", "ProgramProduct")
                        .WithMany("ProgramProductReferences")
                        .HasForeignKey("ProgramProductGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProgramProduct");
                });

            modelBuilder.Entity("Shop.Entities.Customer.Address", b =>
                {
                    b.HasOne("Shop.Entities.Customer.Account", "Account")
                        .WithMany("Addresses")
                        .HasForeignKey("AccountGuid")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Shop.Entities.Digital.Code", b =>
                {
                    b.HasOne("Shop.Entities.Digital.ExpirationType", "ExpirationType")
                        .WithMany("Codes")
                        .HasForeignKey("ExpirationTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shop.Entities.Catalog.ProgramProductReference", "ProgramProductReference")
                        .WithMany("Codes")
                        .HasForeignKey("ProductReferenceGuid")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("ExpirationType");

                    b.Navigation("ProgramProductReference");
                });

            modelBuilder.Entity("Shop.Entities.Ordering.Order", b =>
                {
                    b.HasOne("Shop.Entities.Customer.Account", "Account")
                        .WithMany("Orders")
                        .HasForeignKey("AccountGuid")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Shop.Entities.Customer.Address", "Address")
                        .WithMany("Orders")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Shop.Entities.Ordering.PaymentType", "PaymentType")
                        .WithMany("Orders")
                        .HasForeignKey("PaymentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shop.Entities.Ordering.OrderStatus", "Status")
                        .WithMany("Orders")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Address");

                    b.Navigation("PaymentType");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Shop.Entities.Ordering.OrderDetail", b =>
                {
                    b.HasOne("Shop.Entities.Ordering.OrderDetailStatus", "OrderDetailStatus")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderDetailStatusId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Shop.Entities.Ordering.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Shop.Entities.Catalog.ProgramProductReference", "ProgramProductReference")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductReferenceGuid")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("OrderDetailStatus");

                    b.Navigation("ProgramProductReference");
                });

            modelBuilder.Entity("Shop.Entities.ShopCart.Cart", b =>
                {
                    b.HasOne("Shop.Entities.Customer.Account", "Account")
                        .WithMany("Carts")
                        .HasForeignKey("AccountGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Shop.Entities.ShopCart.CartItem", b =>
                {
                    b.HasOne("Shop.Entities.ShopCart.Cart", "Cart")
                        .WithMany("CartItems")
                        .HasForeignKey("CartGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shop.Entities.Catalog.ProgramProductReference", "Reference")
                        .WithMany("Items")
                        .HasForeignKey("ReferenceGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Reference");
                });

            modelBuilder.Entity("Shop.Entities.Catalog.Category", b =>
                {
                    b.Navigation("ChildCategories");

                    b.Navigation("Products");

                    b.Navigation("ProgramProducts");
                });

            modelBuilder.Entity("Shop.Entities.Catalog.Product", b =>
                {
                    b.Navigation("ProgramProducts");
                });

            modelBuilder.Entity("Shop.Entities.Catalog.ProductType", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Shop.Entities.Catalog.ProgramProduct", b =>
                {
                    b.Navigation("ProductImages");

                    b.Navigation("ProgramProductReferences");
                });

            modelBuilder.Entity("Shop.Entities.Catalog.ProgramProductReference", b =>
                {
                    b.Navigation("Codes");

                    b.Navigation("Items");

                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("Shop.Entities.Config.Program", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("ProgramProducts");
                });

            modelBuilder.Entity("Shop.Entities.Customer.Account", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Carts");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Shop.Entities.Customer.Address", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Shop.Entities.Digital.ExpirationType", b =>
                {
                    b.Navigation("Codes");
                });

            modelBuilder.Entity("Shop.Entities.Ordering.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("Shop.Entities.Ordering.OrderDetailStatus", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("Shop.Entities.Ordering.OrderStatus", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Shop.Entities.Ordering.PaymentType", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Shop.Entities.ShopCart.Cart", b =>
                {
                    b.Navigation("CartItems");
                });
#pragma warning restore 612, 618
        }
    }
}
