using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Services
{
    public class ProductsService : IProductsService
    {
        private readonly DataContext dataContext;

        public ProductsService(DataContext dataContext) => 
            this.dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await dataContext.Products.AsNoTracking().ToListAsync();
        }

        public async Task<Product> GetAsync(Guid productId)
        {
            return await dataContext.Products.FindAsync(productId);
        }

        public async Task<Product> GetByNameAsync(string name)
        {
            return await dataContext.Products.SingleOrDefaultAsync(p => p.Name == name);
        }

        public async Task<IEnumerable<Product>> SearchByCriteraAsync(Expression<Func<Product, bool>> searchCritera)
        {
            return await dataContext.Products.Where(searchCritera).ToListAsync();
        }

        public async Task AddAsync(Product product)
        {
            await this.dataContext.Products.AddAsync(product);
            await this.dataContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            var exists = await this.dataContext.Products.FindAsync(product.Id);
            this.dataContext.Entry(exists).CurrentValues.SetValues(product);
            await this.dataContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var existing = await this.dataContext.Products.FindAsync(id);

            if (existing == null)
            {
                return;
            }

            this.dataContext.Products.Remove(existing);
            await this.dataContext.SaveChangesAsync();
        }

        public async Task<bool> IsExistingAsync(Guid id)
        {
            var product = await this.dataContext.Products.FindAsync(id);
            return product != null;
        }
    }
}