using System;

namespace Domain
{
    public class Product
    {
        public Product() : this(Guid.NewGuid())
        {
        }

        public Product(Guid id) => Id = id;
        
        public Guid Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }
    }
}