using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces;
using Shop.Entities.Catalog;

namespace Shop.Infrastructure.Catalog.Repository;

public class ProductRepository : IRepository<Product>
{
    private readonly AppDbContext _context;
    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> AddAsync(Product entity)
    {
        await _context.Products.AddAsync(entity);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> DeleteAsync(Product entity)
    {
        _context.Remove(entity);
        return await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public Task<Product?> GetByInt(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Product?> GetByString(string id)
    {
        var product = await _context.Products.FindAsync(id);

        return product;
    }

    public Task<int> UpdateAsync(Product entity)
    {
        _context.Products.Update(entity);
        return _context.SaveChangesAsync();
    }
}
