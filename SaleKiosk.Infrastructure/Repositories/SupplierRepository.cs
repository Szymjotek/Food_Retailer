using SaleKiosk.Domain.Contracts;
using SaleKiosk.Domain.Models;

namespace SaleKiosk.Infrastructure.Repositories
{
    // Implementacja repozytoriów specyficznych
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
            return _kioskDbContext.Products.Max(x => x.Id);
        }

       
    }

}
