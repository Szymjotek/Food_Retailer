using SaleKiosk.Domain.Contracts;
using SaleKiosk.Domain.Models;

namespace SaleKiosk.Infrastructure.Repositories
{
    // Implementacja repozytoriów specyficznych
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly KioskDbContext _kioskDbContext;

        public CustomerRepository(KioskDbContext context)
            : base(context)
        {
            _kioskDbContext = context;
        }

        public int GetMaxId()
        {
            return _kioskDbContext.Customers.Max(x => x.Id);
        }

    }

}
