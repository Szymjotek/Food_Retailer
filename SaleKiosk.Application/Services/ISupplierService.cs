using SaleKiosk.SharedKernel.Dto;

namespace SaleKiosk.Application.Services
{
    public interface ISupplierService
    {
        List<SupplierDto> GetAll();
        SupplierDto GetById(int id);
        int Create(CreateSupplierDto dto);
        void Update(UpdateSupplierDto dto);
        void Delete(int id);
    }
}
