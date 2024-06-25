using AutoMapper;
using SaleKiosk.Domain.Models;
using SaleKiosk.SharedKernel.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleKiosk.Application.Mappings
{
    public class FoodWarehouseMappingProfile : Profile
    {
        public FoodWarehouseMappingProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<CreateProductDto, Product>()
                .ForMember(m => m.Description, c => c.MapFrom(s => s.Desc))
                .ForMember(m => m.SupplierId, c => c.MapFrom(s => s.SupplierId));

            CreateMap<Customer, CustomerDto>();
            CreateMap<CreateCustomerDto, Customer>()
             .ForMember(m => m.CustomerName, c => c.MapFrom(s => s.CustomerName));

            CreateMap<Supplier, SupplierDto>();
            CreateMap<CreateSupplierDto, Supplier>()
             .ForMember(m => m.SupplierName, c => c.MapFrom(s => s.SupplierName));


            CreateMap<OrderStatusEnum, OrderStatusEnumDto>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();

        }
    }
}
