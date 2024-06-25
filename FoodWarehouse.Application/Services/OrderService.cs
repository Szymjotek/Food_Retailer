﻿using AutoMapper;
using FoodWarehouse.Domain.Contracts;
using FoodWarehouse.Domain.Exceptions;
using FoodWarehouse.Domain.Models;
using FoodWarehouse.SharedKernel.Dto;

namespace FoodWarehouse.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IKioskUnitOfWork _uow;
        private readonly IMapper _mapper;

        public OrderService(IKioskUnitOfWork unitOfWork, IMapper mapper)
        {
            this._uow = unitOfWork;
            this._mapper = mapper;
       
        }

        public int Create(OrderDto dto)
        {
            if (dto == null)
            {
                throw new BadRequestException("Order is null");
            }
            
            var id = _uow.OrderRepository.GetMaxId() + 1;
            var order = _mapper.Map<Order>(dto);
            order.Id = id;

            if (dto.CustomerId > _uow.CustomerRepository.GetMaxId())
            {
                throw new ApplicationException("CustomerID doesn't exist");
            }

            _uow.OrderRepository.Insert(order);
            _uow.Commit();

            return id;
        }

        public List<OrderDto> GetAll()
        {
            var orders = _uow.OrderRepository.GetAll();

            List<OrderDto> result = _mapper.Map<List<OrderDto>>(orders);
            return result;
        }

        public OrderDto GetByIdWithDetails(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException("Id is less than zero");
            }

            var order = _uow.OrderRepository.GetByIdWithDetails(id);
            if (order == null)
            {
                throw new NotFoundException("Order not found");
            }

            var result = _mapper.Map<OrderDto>(order);
            return result;
        }
    }


}