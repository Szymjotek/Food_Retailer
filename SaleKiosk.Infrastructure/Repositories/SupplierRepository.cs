using SaleKiosk.Domain.Contracts;
using SaleKiosk.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SaleKiosk.Infrastructure.Repositories
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        private readonly FoodWarehouseDbContext _kioskDbContext;

        public SupplierRepository(FoodWarehouseDbContext context)
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
