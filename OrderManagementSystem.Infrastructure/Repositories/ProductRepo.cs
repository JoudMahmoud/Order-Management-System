using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Domain.Entities;
using OrderManagementSystem.Domain.Interfaces;
using OrderManagementSystem.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Infrastructure.Repositories
{
    public class ProductRepo:IProductRepo
    {
        #region Fields 
        private readonly OrderManagementDbContext _dbContext;
        #endregion

        #region Constructor
        public ProductRepo(OrderManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region CRUD Operation
        // Get All Products
        public async Task<IEnumerable<Product>> GetAllAsync(string? search)
        {
            IQueryable<Product> query = _dbContext.Products.AsNoTracking();
            if(!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(p=> 
                p.Name.Contains(search));
            }
            return await query.ToListAsync();
        }
        // Get Details of specific product by Id
        public async Task<Product?>GetByIdAsync(int id)
        {
            return await _dbContext.Products.FindAsync(id);
        }
        // Add a new product  => (Admin only)
        public async Task CreateAsync(Product product)
        {
            await _dbContext.Products.AddAsync(product);
        }

        public void Update(Product product)
        {
            _dbContext.Products.Update(product);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }
        #endregion
    }
}
