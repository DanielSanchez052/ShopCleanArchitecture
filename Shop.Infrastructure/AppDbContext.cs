﻿using Microsoft.EntityFrameworkCore;
using Shop.Entities.Accounts;
using Shop.Entities.Catalog;
using Shop.Entities.Config;
using Shop.Entities.Digital;
using Shop.Entities.Ordering;

namespace Shop.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductImage> ProductImages { get; set; }
    public DbSet<ProductType> ProductTypes { get; set; }
    public DbSet<ProgramProduct> ProgramProducts { get; set; }
    public DbSet<ProgramProductReference> ProgramProductReferences { get; set; }
    public DbSet<Program> Programs { get; set; }
    public DbSet<Code> Codes { get; set; }
    public DbSet<ExpirationType> ExpirationTypes { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<OrderStatus> OrderStatus { get; set; }
    public DbSet<OrderDetailStatus> OrderDetailStatus { get; set; }
    public DbSet<PaymentType> PaymentTypes { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    
        base.OnModelCreating(modelBuilder);
    }
}
 