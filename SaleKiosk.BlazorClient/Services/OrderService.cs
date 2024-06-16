using Newtonsoft.Json;
using SaleKiosk.BlazorClient.ViewModels;
using SaleKiosk.SharedKernel.Dto;
using System.Text;

namespace SaleKiosk.BlazorClient.Services
{
    public interface IOrderService
    {
        Task SubmitOrder(List<CartItem> cart, string orderMessage);
    }

    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;

        public OrderService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task SubmitOrder(List<CartItem> cart, string orderMessage)
        {
            OrderDto createOrderDto = new OrderDto()
            {
                CreatedAt = DateTime.Now,
                Status = OrderStatusEnumDto.Submitted,
                OrderMessage = orderMessage,
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
            string responseResult = response.Content.ReadAsStringAsync().Result;
            if (response.IsSuccessStatusCode)
            {
                return;
            }
            else
            {
                throw new Exception(responseResult);
            }
        }
    }

}
