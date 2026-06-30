using OrderManagementSystem.Application.Common;
using OrderManagementSystem.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDisplayDto>> GetAllAsync(string? search);
        Task<ProductDisplayDto?> GetByIdAsync(int id);
        Task<Result> UpdateAsync(int id, ProductDto dto);
        Task<Result> CreateAsync(ProductDto dto);
    }
}
