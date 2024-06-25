

using FoodWarehouse.Domain.Models;

namespace FoodWarehouse.Domain.Contracts
{
    // interfejsy repozytoriów specyficznych
    public interface ISupplierRepository : IRepository<Supplier>
    {
        int GetMaxId();
        Supplier GetSupplierWithProducts(int supplierId);
        Task<List<Supplier>> GetAllAsync();
    }
}
