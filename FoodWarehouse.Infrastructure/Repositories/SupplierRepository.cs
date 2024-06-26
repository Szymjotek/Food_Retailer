﻿using FoodWarehouse.Domain.Contracts;
using FoodWarehouse.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FoodWarehouse.Infrastructure.Repositories
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        private readonly KioskDbContext _kioskDbContext;

        public SupplierRepository(KioskDbContext context)
            : base(context)
        {
            _kioskDbContext = context;
        }

        public int GetMaxId()
        {
            return _kioskDbContext.Suppliers.Max(x => x.Id);
        }

        public override Supplier Get(int id)
        {
            return _kioskDbContext.Suppliers
                                  .Include(s => s.Products)
                                  .FirstOrDefault(s => s.Id == id);
        }

        public override IList<Supplier> GetAll()
        {
            return _kioskDbContext.Suppliers
                                  .Include(s => s.Products)
                                  .AsNoTracking()
                                  .ToList();
        }

        public Supplier GetSupplierWithProducts(int id)
        {
            return _kioskDbContext.Suppliers
                                  .Include(s => s.Products)
                                  .FirstOrDefault(s => s.Id == id);
        }

        public async Task<List<Supplier>> GetAllAsync()
        {
            return await _kioskDbContext.Suppliers.ToListAsync();
        }
    }
}
