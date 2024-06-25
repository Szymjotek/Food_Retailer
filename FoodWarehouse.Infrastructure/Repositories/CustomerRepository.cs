using FoodWarehouse.Domain.Contracts;
using FoodWarehouse.Domain.Models;

namespace FoodWarehouse.Infrastructure.Repositories
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
            return _kioskDbContext.Customers.Max(x => x.CustomerId);
        }

    }

}
