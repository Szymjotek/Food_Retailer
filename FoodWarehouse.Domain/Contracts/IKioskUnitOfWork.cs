namespace FoodWarehouse.Domain.Contracts
{
    public interface IKioskUnitOfWork : IDisposable
    {
        IProductRepository ProductRepository { get; }
        IOrderRepository OrderRepository { get; }

        ISupplierRepository SupplierRepository { get; }

        ICustomerRepository CustomerRepository { get; }

        void Commit();
    }
}
