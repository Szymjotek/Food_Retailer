using Newtonsoft.Json;
using SaleKiosk.SharedKernel.Dto;

namespace SaleKiosk.BlazorClient.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAll();
    }

    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _saleKioskServerUrl;

        public ProductService(HttpClient httpClient, IConfiguration configuration)
        {
            this._httpClient = httpClient;
            this._configuration = configuration;
            this._saleKioskServerUrl = _configuration.GetSection("SaleKioskServerUrl").Value;
        }

        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            var response = await _httpClient.GetAsync("/product");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(content);
                foreach (var p in products)
                {
                    p.ImageUrl = _saleKioskServerUrl + p.ImageUrl;
                }

                return products;
            }

            return new List<ProductDto>();
        }
    }


}
