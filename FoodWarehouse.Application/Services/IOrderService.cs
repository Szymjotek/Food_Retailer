using FoodWarehouse.SharedKernel.Dto;

namespace FoodWarehouse.Application.Services
{
    public interface IOrderService
    {
        int Create(OrderDto dto);
        List<OrderDto> GetAll();
        OrderDto GetByIdWithDetails(int id);
    }
}
