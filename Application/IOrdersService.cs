using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;

namespace Application
{
    public interface IOrdersService
    {

        Task<IEnumerable<Order>> GetAll(bool includeOrderDetails = true);
        
        Task<Order> GetOne(Guid orderId, bool includeOrderDetails = true);
    }
}