﻿using AutoMapper;
using FoodWarehouse.Domain.Models;
using FoodWarehouse.SharedKernel.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodWarehouse.Application.Mappings
{
    public class KioskMappingProfile : Profile
    {
        public KioskMappingProfile()
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
