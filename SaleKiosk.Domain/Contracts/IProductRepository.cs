using SaleKiosk.Domain.Models;
using System.Collections.Generic;

namespace SaleKiosk.Domain.Contracts
{
    public interface IProductRepository : IRepository<Product>
    {
        int GetMaxId();
        bool IsInUse(string name);
        IList<Product> GetProductsBySupplierId(int supplierId); 
    }
}
