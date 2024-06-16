

using SaleKiosk.Domain.Models;

namespace SaleKiosk.Domain.Contracts
{
    // interfejsy repozytoriów specyficznych
    public interface ICustomerRepository : IRepository<Customer>
    {
        int GetMaxId();
    }
}
