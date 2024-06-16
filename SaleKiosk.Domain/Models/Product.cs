﻿namespace SaleKiosk.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ImageUrl { get; set; } = "/images/no-image-icon.png";
    }


}