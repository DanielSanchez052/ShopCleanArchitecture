﻿using Shop.Application.Interfaces;
using Shop.Entities.Catalog;
using Shop.Infrastructure.Persistence;

namespace Shop.Infrastructure.Catalog.Repository;

public class ProductRepository : BaseRepository<Product>, IRepository<Product>
{
    public ProductRepository(IDbContext dbContext) : base(dbContext)
    {
    }
}
