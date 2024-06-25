using FoodWarehouse.Domain.Contracts;

namespace FoodWarehouse.Infrastructure
{
    public class KioskUnitOfWork : IKioskUnitOfWork, IDisposable
    {
        private readonly KioskDbContext _context;

        public IProductRepository ProductRepository { get; }
        public IOrderRepository OrderRepository { get; }
        public ICustomerRepository CustomerRepository { get; }
        public ISupplierRepository SupplierRepository { get; }

        public KioskUnitOfWork(
            KioskDbContext context,
            IProductRepository productRepository,
            IOrderRepository orderRepository,
            ICustomerRepository customerRepository,
            ISupplierRepository supplierRepository)
        {
            _context = context;
            ProductRepository = productRepository;
            OrderRepository = orderRepository;
            SupplierRepository = supplierRepository;
            CustomerRepository = customerRepository;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}