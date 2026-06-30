using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Domain.Interfaces
{
    public interface IProductRepo
    {
        Task<IEnumerable<Product>> GetAllAsync(string? search);
        Task<Product?> GetByIdAsync(int id);
        // Add a new product  => (Admin only)
        Task CreateAsync(Product product);
        void Update(Product product);
        Task<bool> SaveChangesAsync();
    }
}
