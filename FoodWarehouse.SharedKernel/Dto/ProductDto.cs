namespace FoodWarehouse.SharedKernel.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public string ImageUrl { get; set; }

        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
    }

}
