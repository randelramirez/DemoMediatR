using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain;

namespace Application
{
    public interface IProductsService
    {
        Task<IEnumerable<Product>> GetAllAsync();

        Task<Product> GetAsync(Guid productId);

        Task<Product> GetByNameAsync(string name);

        Task<IEnumerable<Product>> SearchByCriteraAsync(Expression<Func<Product, bool>> searchCritera);

        Task AddAsync(Product product);

        Task UpdateAsync(Product product);
        
        Task DeleteAsync(Guid id);

        Task<bool> IsExistingAsync(Guid id);
    }
}