using AutoMapper;
using OrderManagementSystem.Application.Common;
using OrderManagementSystem.Application.DTOs;
using OrderManagementSystem.Application.Interfaces;
using OrderManagementSystem.Domain.Entities;
using OrderManagementSystem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Application.Service
{
    public class ProductService:IProductService
    {
        #region Fields 
        private readonly IProductRepo _productRepo;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public ProductService(IProductRepo productRepo,IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }
        #endregion

        #region CRUD Operation
        // Get All Products
        public async Task<IEnumerable<ProductDisplayDto>> GetAllAsync(string? search)
        {
            var products = await _productRepo.GetAllAsync(search);
            if(!products.Any())
                return Enumerable.Empty<ProductDisplayDto>();

            var productDtos = _mapper.Map<IEnumerable<ProductDisplayDto>>(products);
            return productDtos;
        }
        // Get Details of specific product by Id
        public async Task<ProductDisplayDto?> GetByIdAsync(int id)
        {
            var product = await _productRepo.GetByIdAsync(id);
            if (product == null)
                return null;
            var productDto = _mapper.Map<ProductDisplayDto>(product);
            return productDto;
        } 
        // Add a new product  => (Admin only)
        public async Task<Result>UpdateAsync(int id , ProductDto dto)
        {
            var product = await _productRepo.GetByIdAsync (id);
            if (product == null)
                return Result.Failure("Product not found.");
            _mapper.Map(dto, product);
            _productRepo.Update(product);
            var saved = await _productRepo.SaveChangesAsync();
            if (!saved)
                return Result.Failure("Can't update product.");
            return Result.Success("Product Updated.");
        }
        public async Task<Result> CreateAsync(ProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            await _productRepo.CreateAsync(product);
            var saved = await _productRepo.SaveChangesAsync();

            if (!saved)
                return Result.Failure("Product not created.");

            return Result.Success("product Created.");
        }

        // Update product details  => (Admin only)
        #endregion
    }
}
