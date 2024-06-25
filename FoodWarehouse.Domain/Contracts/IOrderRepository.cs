

using FoodWarehouse.Domain.Models;

namespace FoodWarehouse.Domain.Contracts
{
    public interface IOrderRepository : IRepository<Order>
    {
        int GetMaxId();
        Order GetByIdWithDetails(int id);
    }
}
