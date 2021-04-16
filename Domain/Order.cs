using System;
using System.Collections.Generic;

namespace Domain
{
    public class Order
    {
        public Order() : this(Guid.NewGuid())
        {
        }

        public Order(Guid id)
        {
            Id = id;
            OrderDetails = new List<OrderDetail>();
        }

        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public Guid CustomerId { get; set; }

        public Customer Customer { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}