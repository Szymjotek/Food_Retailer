﻿using System.ComponentModel.DataAnnotations;

namespace SaleKiosk.SharedKernel.Dto
{
    public class CreateSupplierDto
    {
        public string SupplierName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }



    //public class CreateProductDto
    //{
    //    [Required]
    //    [MinLength(2)]
    //    [MaxLength(20)]
    //    public string Name { get; set; }

    //    [Required]
    //    [MinLength(2)]
    //    [MaxLength(20)]
    //    public string Desc { get; set; }


    //    [Range(0.01, double.MaxValue)]
    //    public decimal UnitPrice { get; set; }
    //}
}