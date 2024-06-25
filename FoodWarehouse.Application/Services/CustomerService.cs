using AutoMapper;
using FoodWarehouse.Domain.Contracts;
using FoodWarehouse.Domain.Exceptions;
using FoodWarehouse.Domain.Models;
using FoodWarehouse.SharedKernel.Dto;

namespace FoodWarehouse.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IKioskUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CustomerService(IKioskUnitOfWork unitOfWork, IMapper mapper)
        {
            this._uow = unitOfWork;
            this._mapper = mapper;
        }

        public int Create(CreateCustomerDto dto)
        {
            if (dto == null)
            {
                throw new BadRequestException("Customer is null");
            }

            var id = _uow.CustomerRepository.GetMaxId() + 1;
            var customer = _mapper.Map<Customer>(dto);
            customer.CustomerId = id;

    
            _uow.CustomerRepository.Insert(customer);
            _uow.Commit();

            return id;
        }

        public void Delete(int id)
        {
            var customer = _uow.CustomerRepository.Get(id);
            if (customer == null)
            {
               throw new NotFoundException("Customer not found");
            }

            _uow.CustomerRepository.Delete(customer);
            _uow.Commit();
        }

        public List<CustomerDto> GetAll()
        {
            var customers = _uow.CustomerRepository.GetAll();

            List<CustomerDto> result = _mapper.Map<List<CustomerDto>>(customers);
            return result;
        }
  
        public CustomerDto GetById(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException("Id is less than zero");
            }

            var customer = _uow.ProductRepository.Get(id);
            if (customer == null)
            {
                throw new NotFoundException("Customer not found");
            }

            var result = _mapper.Map<CustomerDto>(customer);
            return result;
        }

        public void Update(UpdateCustomerDto dto)
        {
            if (dto == null)
            {
                throw new BadRequestException("No customer data");
            }

            var customer = _uow.CustomerRepository.Get(dto.Id);
            if (customer == null)
            {
                throw new NotFoundException("Customer not found");
            }

            customer.CustomerName = dto.CustomerName;
            customer.Address = dto.Address;
            customer.PhoneNumber = dto.PhoneNumber;

     

            _uow.Commit();
        }
    }


}
