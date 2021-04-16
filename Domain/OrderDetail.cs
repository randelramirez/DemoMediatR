using System;

namespace Domain
{
    public class OrderDetail
    {
        public OrderDetail() : this(Guid.NewGuid())
        {
        }

        public OrderDetail(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }

        public Guid OrderId { get; set; }

        public Order Order { get; set; }

        public Guid ProductId { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}