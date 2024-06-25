using FoodWarehouse.SharedKernel.Dto;

namespace FoodWarehouse.Application.Services
{
    public interface IProductService
    {
        List<ProductDto> GetAll();
        ProductDto GetById(int id);
        int Create(CreateProductDto dto);
        void Update(UpdateProductDto dto);
        void Delete(int id);
    }
}
