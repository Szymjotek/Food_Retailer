using Newtonsoft.Json;
using SaleKiosk.BlazorClient.ViewModels;
using SaleKiosk.SharedKernel.Dto;
using System.Text;

namespace SaleKiosk.BlazorClient.Services
{
    public interface IOrderService
    {
        Task SubmitOrder(List<CartItem> cart, string orderMessage, int CustomerId);
    }

    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;

        public OrderService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task SubmitOrder(List<CartItem> cart, string orderMessage, int customerId)
        {
            try
            {
                OrderDto createOrderDto = new OrderDto()
                {
                    CreatedAt = DateTime.Now,
                    Status = OrderStatusEnumDto.Submitted,
                    OrderMessage = orderMessage,
                    CustomerId = customerId,
                    Details = new List<OrderDetailDto>()
                };
                foreach (var item in cart)
                {
                    var orderDetailDto = new OrderDetailDto()
                    {
                        ProductId = item.Product.Id,
                        ProductName = item.Product.Name,
                        ProductPrice = item.Product.UnitPrice,
                        ImageUrl = item.Product.ImageUrl,
                        Count = item.Count,
                    };

                    createOrderDto.Details.Add(orderDetailDto);
                    createOrderDto.OrderTotal += orderDetailDto.ProductPrice * orderDetailDto.Count;
                }


                var content = JsonConvert.SerializeObject(createOrderDto);
                var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("order", bodyContent);
                if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    throw new ApplicationException();

                }
                    response.EnsureSuccessStatusCode();
            }
            catch (ApplicationException ex)
            {

                throw new ApplicationException("An error occurred while submitting the order. Is your Customer Id correct? If you want to register as a new customer, please contact our support.", ex);
            }
            catch (HttpRequestException ex)
            {
                
                throw new Exception("Failed to submit order. Check your internet connection.", ex);
            }
           
        }
    }

}
