using AutoMapper;
using FoodWarehouse.Domain.Contracts;
using FoodWarehouse.Domain.Exceptions;
using FoodWarehouse.Domain.Models;
using FoodWarehouse.SharedKernel.Dto;

namespace FoodWarehouse.Application.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly IKioskUnitOfWork _uow;
        private readonly IMapper _mapper;

        public SupplierService(IKioskUnitOfWork unitOfWork, IMapper mapper)
        {
            this._uow = unitOfWork;
            this._mapper = mapper;
        }

        public int Create(CreateSupplierDto dto)
        {
            if (dto == null)
            {
                throw new BadRequestException("Supplier is null");
            }

            var id = _uow.SupplierRepository.GetMaxId() + 1;
            var supplier = _mapper.Map<Supplier>(dto);
            supplier.Id = id;
            
            _uow.SupplierRepository.Insert(supplier);
            _uow.Commit();

            return id;
        }

        public void Delete(int id)
        {
            var supplier = _uow.SupplierRepository.Get(id);
            if (supplier == null)
            {
               throw new NotFoundException("supplier not found");
            }

            _uow.SupplierRepository.Delete(supplier);
            _uow.Commit();
        }

        public List<SupplierDto> GetAll()
        {
            var suppliers = _uow.SupplierRepository.GetAll();

            List<SupplierDto> result = _mapper.Map<List<SupplierDto>>(suppliers);
            return result;
        }

        public async Task<List<SupplierDto>> GetAllAsync()
        {
            var suppliers = await _uow.SupplierRepository.GetAllAsync();
            return _mapper.Map<List<SupplierDto>>(suppliers);
        }

        public SupplierDto GetById(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException("Id is less than zero");
            }

            var supplier = _uow.SupplierRepository.Get(id);
            if (supplier == null)
            {
                throw new NotFoundException("Supplier not found");
            }

            var result = _mapper.Map<SupplierDto>(supplier);
            return result;
        }

        public void Update(UpdateSupplierDto dto)
        {
            if (dto == null)
            {
                throw new BadRequestException("No supplier data");
            }

            var supplier = _uow.SupplierRepository.Get(dto.Id);
            if (supplier == null)
            {
                throw new NotFoundException("Supplier not found");
            }

            supplier.SupplierName = dto.SupplierName;
            supplier.Address = dto.Address;
            supplier.PhoneNumber = dto.PhoneNumber;

         

            _uow.Commit();
        }
    }


}
