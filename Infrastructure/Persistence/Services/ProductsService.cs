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
        
        public async Task<IEnumerable<Product>> GetAll()
        {
            return await this.dataContext.Products.AsNoTracking().ToListAsync();
        }

        public async Task<Product> GetOne(Guid productId)
        {
            return await this.dataContext.Products.FindAsync(productId.ToString());
        }

        public async Task<Product> GetByName(string name)
        {
            return await this.dataContext.Products.SingleOrDefaultAsync(p => p.Name == name);
        }

        public async Task<IEnumerable<Product>> SearchByCritera(Expression<Func<Product, bool>> searchCritera)
        {
            return await this.dataContext.Products.Where(searchCritera).ToListAsync();
        }
    }
}