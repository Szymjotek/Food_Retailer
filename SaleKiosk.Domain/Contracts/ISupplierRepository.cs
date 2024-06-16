

using SaleKiosk.Domain.Models;

namespace SaleKiosk.Domain.Contracts
{
    // interfejsy repozytoriów specyficznych
    public interface ISupplierRepository : IRepository<Supplier>
    {
        int GetMaxId();
    }
}
