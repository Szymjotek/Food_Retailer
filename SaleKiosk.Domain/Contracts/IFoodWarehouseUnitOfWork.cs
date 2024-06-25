namespace SaleKiosk.Domain.Contracts
{
    public interface IFoodWarehouseUnitOfWork : IDisposable
    {
        IProductRepository ProductRepository { get; }
        IOrderRepository OrderRepository { get; }

        ISupplierRepository SupplierRepository { get; }

        ICustomerRepository CustomerRepository { get; }

        void Commit();
    }
}
