﻿using SaleKiosk.Domain.Contracts;
using SaleKiosk.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace SaleKiosk.Infrastructure.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly FoodWarehouseDbContext _kioskDbContext;

        public ProductRepository(FoodWarehouseDbContext context)
            : base(context)
        {
            _kioskDbContext = context;
        }

        public int GetMaxId()
        {
            return _kioskDbContext.Products.Max(x => x.Id);
        }

        public bool IsInUse(string name)
        {
            var result = _kioskDbContext.Products.Any(x => x.Name == name);
            return result;
        }

        public override Product Get(int id)
        {
            return _kioskDbContext.Products
                                  .Include(p => p.Supplier)
                                  .FirstOrDefault(p => p.Id == id);
        }

        public override IList<Product> GetAll()
        {
            return _kioskDbContext.Products
                                  .Include(p => p.Supplier)
                                  .AsNoTracking()
                                  .ToList();
        }

        public IList<Product> GetProductsBySupplierId(int supplierId)
        {
            return _kioskDbContext.Products
                                  .Where(p => p.SupplierId == supplierId)
                                  .Include(p => p.Supplier)
                                  .AsNoTracking()
                                  .ToList();
        }
    }
}
