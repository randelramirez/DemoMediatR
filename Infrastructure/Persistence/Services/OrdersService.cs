using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly DataContext context;

        public OrdersService(DataContext context) => this.context = context;


        public async Task<IEnumerable<Order>> GetAll(bool includeOrderDetails)
        {
            return await context.Orders.Include(o => o.OrderDetails).ToListAsync();
        }

        public async Task<Order> GetOne(Guid orderId, bool includeOrderDetails)
        {
            return await context.Orders.AsNoTracking()
                .Include(o => o.OrderDetails)
                .SingleAsync(o => o.Id == orderId);
        }
    }
}