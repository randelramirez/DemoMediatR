using System;

namespace Domain
{
    public class Customer
    {
        public Customer() : this(Guid.NewGuid())
        {
        }
        
        public Customer(Guid id)
        {
            this.Id = id;
        }
        
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }
    }
}