using SaleKiosk.SharedKernel.Dto;
using System.ComponentModel.DataAnnotations;

namespace SaleKiosk.BlazorClient.ViewModels
{
    public class CartItem
    {
        public ProductDto Product { get; set; }
        public int Count { get; set; }
    }
}
