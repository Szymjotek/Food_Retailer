﻿using FoodWarehouse.SharedKernel.Dto;

namespace FoodWarehouse.Application.Services
{
    public interface ISupplierService
    {
        Task<List<SupplierDto>> GetAllAsync();
        List<SupplierDto> GetAll();
        SupplierDto GetById(int id);
        int Create(CreateSupplierDto dto);
        void Update(UpdateSupplierDto dto);
        void Delete(int id);
    }
}
