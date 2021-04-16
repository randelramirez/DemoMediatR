using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain;

namespace Application
{
    public interface IProductsService
    {
        Task<IEnumerable<Product>> GetAll();
        
        Task<Product> GetOne(Guid productId);
        
        Task<Product> GetByName(string name);

        Task<IEnumerable<Product>> SearchByCritera(Expression<Func<Product, bool>> searchCritera);
    }
}