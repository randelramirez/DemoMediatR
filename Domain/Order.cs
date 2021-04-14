using System;
using System.Collections.Generic;

namespace Domain
{
    public class Order
    {
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public Guid CustomerId { get; set; }

        public Customer Customer { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}