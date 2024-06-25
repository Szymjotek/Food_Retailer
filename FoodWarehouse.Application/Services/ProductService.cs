using AutoMapper;
using FoodWarehouse.Domain.Contracts;
using FoodWarehouse.Domain.Exceptions;
using FoodWarehouse.Domain.Models;
using FoodWarehouse.SharedKernel.Dto;

namespace FoodWarehouse.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IKioskUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ProductService(IKioskUnitOfWork unitOfWork, IMapper mapper)
        {
            this._uow = unitOfWork;
            this._mapper = mapper;
        }

        public int Create(CreateProductDto dto)
        {
            if (dto == null)
            {
                throw new BadRequestException("Product is null");
            }

            // Check if the supplier exists
            var supplier = _uow.SupplierRepository.Get(dto.SupplierId);
            if (supplier == null)
            {
                throw new NotFoundException("Supplier not found");
            }

            var id = _uow.ProductRepository.GetMaxId() + 1;
            var product = _mapper.Map<Product>(dto);
            product.Id = id;
            product.SupplierId = dto.SupplierId;

            // set default image url if user did not support its own
            product.ImageUrl = String.IsNullOrEmpty(dto.ImageUrl)
                ? "/images/no-image-icon.png"
                : dto.ImageUrl;

            _uow.ProductRepository.Insert(product);
            _uow.Commit();

            return id;
        }

        public void Delete(int id)
        {
            var product = _uow.ProductRepository.Get(id);
            if (product == null)
            {
                throw new NotFoundException("Product not found");
            }

            _uow.ProductRepository.Delete(product);
            _uow.Commit();
        }

        public List<ProductDto> GetAll()
        {
            var products = _uow.ProductRepository.GetAll();

            var productDtos = products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                UnitPrice = p.UnitPrice,
                ImageUrl = p.ImageUrl,
                SupplierId = p.SupplierId,
                SupplierName = p.Supplier.SupplierName  
            }).ToList();

            return productDtos;
        }
            public ProductDto GetById(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException("Id is less than zero");
            }

            var product = _uow.ProductRepository.Get(id);
            if (product == null)
            {
                throw new NotFoundException("Product not found");
            }

            var result = _mapper.Map<ProductDto>(product);
            return result;
        }

        public void Update(UpdateProductDto dto)
        {
            if (dto == null)
            {
                throw new BadRequestException("No product data");
            }

            var product = _uow.ProductRepository.Get(dto.Id);
            if (product == null)
            {
                throw new NotFoundException("Product not found");
            }

            // Check if the supplier exists
            var supplier = _uow.SupplierRepository.Get(dto.SupplierId);
            if (supplier == null)
            {
                throw new NotFoundException("Supplier not found");
            }

            product.Name = dto.Name;
            product.Description = dto.Desc;
            product.UnitPrice = dto.UnitPrice;
            product.SupplierId = dto.SupplierId;

            // set default image url if user did not support its own
            product.ImageUrl = String.IsNullOrEmpty(dto.ImageUrl)
                ? "/images/no-image-icon.png"
                : dto.ImageUrl;

            _uow.Commit();
        }
    }
}
