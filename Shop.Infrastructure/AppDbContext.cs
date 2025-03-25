using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces;
using Shop.Entities.Catalog;
using Shop.Entities.Config;
using Shop.Entities.Customer;
using Shop.Entities.Delivery;
using Shop.Entities.Digital;
using Shop.Entities.Ordering;
using Shop.Entities.Payment;
using Shop.Entities.ShopCart;

namespace Shop.Infrastructure;

public class AppDbContext : DbContext, IDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public AppDbContext() 
    {
    }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
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
    public DbSet<DeliveryProvider> DeliveryProviders { get; set; } = null!;

    public new DbSet<TEntity> Set<TEntity>()
       where TEntity : class
       => base.Set<TEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    
        base.OnModelCreating(modelBuilder);
    }
}
 