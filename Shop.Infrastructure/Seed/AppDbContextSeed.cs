using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Shop.Entities.Catalog;
using Shop.Entities.Config;
using Shop.Entities.Digital;
using Shop.Entities.Ordering;

namespace Shop.Infrastructure.Seed;

public class AppDbContextSeed
{
    private int DefaultProgramId => 1;
    private string DefaultProgramName => "Default program name";

    public async Task SeedAsync(AppDbContext context, IOptions<ShopSettings> settings, ILogger<AppDbContextSeed> logger)
    {
        //await context.Database.EnsureCreatedAsync();

        var transaction = await context.Database.BeginTransactionAsync();
        try
        {
            // Program
            var program = GetProgram();

            if (!context.Programs.Any())
            {
                logger.LogInformation("Seeding program: {ProgramName}", program.Name);
                
                context.Programs.Add(program);
                await context.SaveChangesAsync();
            }

            // categories
            var categories = GetCategories();

            if (!context.Categories.Any())
            {
                logger.LogInformation("Seeding categories: {CategoriesCount}", categories.Count());

                context.Categories.AddRange(categories);
                await context.SaveChangesAsync();
            }

            // product types
            var productTypes = GetProductTypes();

            if (!context.ProductTypes.Any())
            {
                logger.LogInformation("Seeding product types: {ProductTypesCount}", productTypes.Count());
            
                context.ProductTypes.AddRange(productTypes);
                await context.SaveChangesAsync();
            }

            // expiration types
            var expirationTypes = GetExpirationTypes();

            if (!context.ExpirationTypes.Any())
            {
                logger.LogInformation("Seeding expiration types: {ExpirationTypesCount}", expirationTypes.Count());
            
                context.ExpirationTypes.AddRange(expirationTypes);
                await context.SaveChangesAsync();
            }

            // payment types
            var paymentTypes = GetPaymentTypes();

            if (!context.PaymentTypes.Any())
            {
                logger.LogInformation("Seeding payment types: {PaymentTypesCount}", paymentTypes.Count());
            
                context.PaymentTypes.AddRange(paymentTypes);
                await context.SaveChangesAsync();
            }

            // order status
            var orderStatuses = GetOrderStatuses();

            if (!context.OrderStatus.Any())
            {
                logger.LogInformation("Seeding order statuses: {OrderStatusesCount}", orderStatuses.Count());
            
                context.OrderStatus.AddRange(orderStatuses);
                await context.SaveChangesAsync();
            }

            // order detail status
            var orderDetailStatuses = GetOrderDetailStatus();

            if (!context.OrderDetailStatus.Any())
            {
                logger.LogInformation("Seeding order detail statuses: {OrderDetailStatusesCount}", orderDetailStatuses.Count());
            
                context.OrderDetailStatus.AddRange(orderDetailStatuses);
                await context.SaveChangesAsync();
            }

            // products
            var products = GetProducts();

            if (!context.Products.Any())
            {
                logger.LogInformation("Seeding products: {ProductsCount}", products.Count());
            
                context.Products.AddRange(products);
                
                await context.SaveChangesAsync();

                if (!context.ProgramProducts.Any())
                {
                    logger.LogInformation("Seeding program products: {ProgramProductsCount}", products.Count());

                    var programProducts = products.Select(p =>
                        new ProgramProduct(
                            Guid.NewGuid().ToString(), p.Guid, DefaultProgramId, p.Name, p.ShortDescription, p.LongDescription, p.Terms, p.Conditions, p.Instructions, p.NominalValue, null, 10000, 0.16M, 10000, 1, DateTime.Now, true
                            )
                        ).ToList();

                    context.ProgramProducts.AddRange(programProducts);
                    await context.SaveChangesAsync();

                    if (!context.ProgramProductReferences.Any())
                    {
                        logger.LogInformation("Seeding program product references: {ProgramProductReferencesCount}", products.Count());

                        var programProductReferences = programProducts.Select(pr =>
                            new ProgramProductReference(Guid.NewGuid().ToString(), pr.Guid, 0, 0, true));

                        context.ProgramProductReferences.AddRange(programProductReferences);

                        await context.SaveChangesAsync();
                    }

                }

            }

            await transaction.CommitAsync();

        }catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while seeding the database.");
            await transaction.RollbackAsync();
        }
        
    }


    private Program GetProgram() => new Program(DefaultProgramId, DefaultProgramName, true, null, DateTime.Now, DateTime.Now.AddDays(30), DateTime.Now);

    private IEnumerable<Category> GetCategories() =>
        new List<Category> { 
            new Category(1, "GiftCard", null, null, DefaultProgramId, null, true),
            new Category(2, "Home", null, null, DefaultProgramId, null, true),
            new Category(3, "Food", null, null, DefaultProgramId, null, true),
        };

    private IEnumerable<ProductType> GetProductTypes() => 
        new List<ProductType> { 
            new ProductType(1, "Digital", null, true),
        };

    private IEnumerable<ExpirationType> GetExpirationTypes() =>
        new List<ExpirationType> {
            new ExpirationType("Exact Date", null, true),
        };

    private IEnumerable<PaymentType> GetPaymentTypes() =>
        new List<PaymentType> {
            new PaymentType("Points", null, "", "", true),
        };

    private IEnumerable<OrderStatus> GetOrderStatuses() =>
        new List<OrderStatus> {
            new OrderStatus("Pending", true),
            new OrderStatus("Approved", true),
            new OrderStatus("Canceled", true),
        };

    private IEnumerable<OrderDetailStatus> GetOrderDetailStatus() =>
       new List<OrderDetailStatus> {
            new OrderDetailStatus("Pending", true),
            new OrderDetailStatus("Approved", true),
            new OrderDetailStatus("Canceled", true),
       };

    private IEnumerable<Product> GetProducts() =>
        new List<Product>
        {
            new Product(Guid.NewGuid().ToString(), "1001", "GiftCard $10.000", 1, "a gift card for $10.000", null, null, null, null, "10000", null, 1, DateTime.Now, true)
        };
}
