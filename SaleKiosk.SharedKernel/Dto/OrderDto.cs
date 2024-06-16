namespace SaleKiosk.SharedKernel.Dto
{
    public enum OrderStatusEnumDto
    {
        Submitted,
        Completed,
    }

    public class OrderDto
    {
        public int Id { get; set; }
        public decimal OrderTotal { get; set; }
        public DateTime CreatedAt { get; set; }
        public OrderStatusEnumDto Status { get; set; }
        public string OrderMessage { get; set; } = string.Empty;
        public List<OrderDetailDto> Details { get; set; } = new List<OrderDetailDto>();
    }



}
