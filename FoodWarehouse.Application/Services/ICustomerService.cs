using FoodWarehouse.SharedKernel.Dto;

namespace FoodWarehouse.Application.Services
{
    public interface ICustomerService
    {
        List<CustomerDto> GetAll();
        CustomerDto GetById(int id);
        int Create(CreateCustomerDto dto);
        void Update(UpdateCustomerDto dto);
        void Delete(int id);
    }
}
