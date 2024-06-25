

using FoodWarehouse.Domain.Models;

namespace FoodWarehouse.Domain.Contracts
{
    // interfejsy repozytoriów specyficznych
    public interface ICustomerRepository : IRepository<Customer>
    {
        int GetMaxId();
    }
}
