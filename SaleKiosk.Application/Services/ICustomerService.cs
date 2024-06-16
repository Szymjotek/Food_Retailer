using SaleKiosk.SharedKernel.Dto;

namespace SaleKiosk.Application.Services
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
